using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer;
using EPiServer.Web.Routing;
using High.Net.Models.GreenfieldArchitects.Pages;
using System.Web;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using ImageVault.Client;
using ImageVault.EPiServer;
using ImageVault.Common.Data;
using System.Linq;
using System.Text;
using High.Net.Core;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Project Pages Import for GreenField Architects" , SortIndex = 400)]
    public class GAProjectPagesImport : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;

        public GAProjectPagesImport()
        {
            IsStoppable = true;
        }

       
        public override void Stop()
        {
            _stopSignaled = true;
        }


        public override string Execute()
        {
            SysRoot _sysRoot = _contentRepo.Get<SysRoot>(PageReference.RootPage);
            bool JobAccess = _sysRoot.ExecuteScheduleJobs;

            if (JobAccess)
            {
                string status = getExcelData();
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                if (_stopSignaled)
                {

                }

                return "Change to message that describes outcome of execution";
            }
            else 
            {
                return "You do not have the permission";
            }
        }

        #region Read Excel

        public string getExcelData()
        {
            try
            {
                var client = ClientFactory.GetSdkClient();
                var _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
                var _contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
                var _client = ImageVault.Client.ClientFactory.GetSdkClient();
                var resolver = ServiceLocator.Current.GetInstance<UrlResolver>();

                var StartPage = _contentRepo.Get<HomePage>(ContentReference.StartPage);


                List<PortfolioItemPage> _PortfolioItemPageList = _contentLocator.GetAll<PortfolioItemPage>(StartPage.ContentLink).ToList();



                PortfolioPage _PortfolioPage = new PortfolioPage();

                _PortfolioPage = _contentRepo.GetChildren<PortfolioPage>(StartPage.ContentLink).FirstOrDefault();
                if (_PortfolioPage == null)
                {
                    _PortfolioPage = _contentRepo.GetDefault<PortfolioPage>(StartPage.ContentLink);
                    _PortfolioPage.Name = "PortFolio";
                    _contentRepo.Save(_PortfolioPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                }

                PortfolioListingPage _PortfolioListingPage = _contentRepo.GetDefault<PortfolioListingPage>(_PortfolioPage.ContentLink);

                // Read Csv
                var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"import\{0}.csv", StartPage.Name));
                String PortfolioListingPage = String.Empty;

                using (StreamReader textReader = new StreamReader(filePath, Encoding.Default, true))
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        while (csvReader.Read())
                        {

                            MediaReferenceList<MediaReference> MList = new MediaReferenceList<MediaReference>();
                            MediaReference projectImage = new MediaReference();
                            MediaReference ProjectThumbnailImage = new MediaReference();
                            List<PortfolioItemPage> _CsvPortfolioItemPageList = new List<PortfolioItemPage>();

                            GetImagesfromVault(client, csvReader, MList, ref projectImage, ref ProjectThumbnailImage);

                            List<PortfolioListingPage> _PortfolioListingPageList = _contentLocator.GetAll<PortfolioListingPage>(StartPage.ContentLink).ToList();
                            _PortfolioListingPage = _PortfolioListingPageList.Where(x => x.Name.Contains(csvReader.GetField<String>("Market Segment"))).FirstOrDefault();

                            if (_PortfolioListingPage != null)
                            {
                                var checkPortfolioItemPage = _PortfolioItemPageList.Where(x => x.Name.Contains(csvReader.GetField<String>("Project Name"))).FirstOrDefault();
                                if (checkPortfolioItemPage != null)
                                {
                                    //Update Project Item Page
                                    bool Update = true;
                                    BindPortfolioItemPage(_contentRepo, csvReader, MList, ProjectThumbnailImage, checkPortfolioItemPage, Update);

                                }
                                else
                                {
                                    //Create Project Item Page
                                    var _PortfolioItemPage = _contentRepo.GetDefault<PortfolioItemPage>(_PortfolioListingPage.ContentLink);
                                    _PortfolioItemPage.Name = csvReader.GetField<String>("Project Name");
                                    bool Update = false;
                                    BindPortfolioItemPage(_contentRepo, csvReader, MList, ProjectThumbnailImage, _PortfolioItemPage,Update);
                                }
                            }
                            else
                            {
                                _PortfolioListingPage = _contentRepo.GetDefault<PortfolioListingPage>(_PortfolioPage.ContentLink);
                                _PortfolioListingPage.Name = csvReader.GetField<String>("Market Segment");
                                _PortfolioListingPage.PageImage = projectImage;
                                PortfolioListingPage = _PortfolioListingPage.Name;
                                _contentRepo.Save(_PortfolioListingPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                                var _PortfolioItemPage = _contentRepo.GetDefault<PortfolioItemPage>(_PortfolioListingPage.ContentLink);
                                _PortfolioItemPage.Name = csvReader.GetField<String>("Project Name");
                                bool Update = false;
                                BindPortfolioItemPage(_contentRepo, csvReader, MList, ProjectThumbnailImage, _PortfolioItemPage,Update);
                            }

                        }
                    }
                }
                return string.Format("{0}, Property Pages Imported Successfully.", StartPage.Name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void GetImagesfromVault(Client client, CsvReader csvReader, MediaReferenceList<MediaReference> MList, ref MediaReference projectImage, ref MediaReference ProjectThumbnailImage)
        {
            string imageLocation = csvReader.GetField<String>("Inner Project Images");
            string ImageName = imageLocation.Substring(imageLocation.LastIndexOf('/') + 1);

            var FirstLevelCategories = client.Query<Category>().Where(c => c.Name.Contains("HCC-GAL"));

            foreach (ImageVault.Common.Data.Category firstitem in FirstLevelCategories)
            {


                var GreenFieldArchitects = firstitem.Categories.Where(x => x.Name.Contains("GAL")).FirstOrDefault();
                foreach (var item in GreenFieldArchitects.Categories.Where(x => x.Name.Contains("04 PORTFOLIO_Main Images")))
                {
                    if (item != null)
                    {
                        var getimagesbycategories = client.Query<MediaItem>().Where(x => x.Categories.Contains(item.Id));
                        var MarketSegmentName = csvReader.GetField<String>("Market Segment").Replace("/", " ").Replace(" ", "");
                        var portfolioProjectImage = getimagesbycategories.Where(x => x.Name.Contains("MainImage_" + MarketSegmentName)).FirstOrDefault();
                        if (portfolioProjectImage != null)
                        {
                            projectImage = new MediaReference { Id = portfolioProjectImage.Id };
                        }
                    }
                }

                if (!String.IsNullOrWhiteSpace(ImageName))
                {
                    var ProjectImages = firstitem.Categories.Where(x => x.Name.Contains("Project Images"));
                    foreach (ImageVault.Common.Data.Category seconditem in ProjectImages)
                    {
                        var ThirdLevelCategories = seconditem.Categories.Where(c => c.Name.Contains(Convert.ToString(ImageName))).FirstOrDefault();

                        if (ThirdLevelCategories != null)
                        {

                            var MediaImages = client.Query<MediaItem>().Where(x => x.Categories.Contains(ThirdLevelCategories.Id)).ToList();

                            if (MediaImages.Count > 0)
                            {
                                foreach (var item in MediaImages)
                                {
                                    if (item.Name.StartsWith("1_") || item.Name.StartsWith("01") || item.Name.StartsWith("1"))
                                    {
                                        ProjectThumbnailImage = new MediaReference { Id = item.Id };
                                    }
                                    var Media = new MediaReference { Id = item.Id };
                                    MList.Add(Media);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void BindPortfolioItemPage(IContentRepository _contentRepo, CsvReader csvReader, MediaReferenceList<MediaReference> MList, MediaReference ProjectThumbnailImage, PortfolioItemPage _PortfolioItemPage, bool Update)
        {
            if (Update)
            {
                var _PortfolioItemPageClone = (PortfolioItemPage)_PortfolioItemPage.CreateWritableClone();
                _PortfolioItemPageClone.facility = csvReader.GetField<String>("Facility");
                _PortfolioItemPageClone.Size = csvReader.GetField<String>("Size");
                _PortfolioItemPageClone.Location = csvReader.GetField<String>("Location");
                _PortfolioItemPageClone.ServiceProvided = csvReader.GetField<String>("Services Provided");
                _PortfolioItemPageClone.Description = new XhtmlString(csvReader.GetField<String>("Description"));
                _PortfolioItemPageClone.MarketSegment = csvReader.GetField<String>("Market Segment");
                _PortfolioItemPageClone.PageImage = ProjectThumbnailImage;
                _PortfolioItemPageClone.PortfolioImages = new MediaReferenceList<MediaReference>(MList);
                _contentRepo.Save(_PortfolioItemPageClone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
            }
            else
            {
                _PortfolioItemPage.ProjectName = csvReader.GetField<String>("Project Name");
                _PortfolioItemPage.facility = csvReader.GetField<String>("Facility");
                _PortfolioItemPage.Size = csvReader.GetField<String>("Size");
                _PortfolioItemPage.Location = csvReader.GetField<String>("Location");
                _PortfolioItemPage.ServiceProvided = csvReader.GetField<String>("Services Provided");
                _PortfolioItemPage.Description = new XhtmlString(csvReader.GetField<String>("Description"));
                _PortfolioItemPage.MarketSegment = csvReader.GetField<String>("Market Segment");
                _PortfolioItemPage.PageImage = ProjectThumbnailImage;
                _PortfolioItemPage.PortfolioImages = new MediaReferenceList<MediaReference>(MList);
                _contentRepo.Save(_PortfolioItemPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
            }
        }

        #endregion
    }
}
