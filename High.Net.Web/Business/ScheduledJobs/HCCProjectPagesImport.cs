using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer;
using EPiServer.Web.Routing;
using High.Net.Models.HighConstructionCo.Pages;
using System.Web;
using System.IO;
using CsvHelper;
using ImageVault.Common.Data;
using ImageVault.Client;
using System.Collections.Generic;
using System.Linq;
using ImageVault.EPiServer;
using System.Text;
using High.Net.Core;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Project List Import for High Construction Company", SortIndex = 500)]
    public class HCCProjectPagesImport : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;

        public HCCProjectPagesImport()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            SysRoot _sysRoot = _contentRepo.Get<SysRoot>(PageReference.RootPage);
            bool JobAccess = _sysRoot.ExecuteScheduleJobs;
            if (JobAccess)
            {
                var result = getExcelData();
                //Call OnStatusChanged to periodically notify progress of job for manually started jobs
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                //Add implementation

                //For long running jobs periodically check if stop is signaled and if so stop execution
                if (_stopSignaled)
                {
                    return "Stop of job was called";
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


                List<ProjectItemPage> _ProjectItemPageList = _contentLocator.GetAll<ProjectItemPage>(StartPage.ContentLink).ToList();



                ProjectCategoryListPage _ProjectCategoryListPage = new ProjectCategoryListPage();

                _ProjectCategoryListPage = _contentRepo.GetChildren<ProjectCategoryListPage>(StartPage.ContentLink).FirstOrDefault();
                if (_ProjectCategoryListPage == null)
                {
                    _ProjectCategoryListPage = _contentRepo.GetDefault<ProjectCategoryListPage>(StartPage.ContentLink);
                    _ProjectCategoryListPage.Name = "Experience";
                    _contentRepo.Save(_ProjectCategoryListPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.FullAccess);
                }

                ProjectListingPage _ProjectListingPage = _contentRepo.GetDefault<ProjectListingPage>(_ProjectCategoryListPage.ContentLink);

                // Read Csv
                var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"import\{0}.csv", StartPage.Name));
                String ProjectListingPage = String.Empty;

                using (StreamReader textReader = new StreamReader(filePath, Encoding.Default, true))
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        while (csvReader.Read())
                        {

                            MediaReferenceList<MediaReference> MList = new MediaReferenceList<MediaReference>();
                            MediaReference projectImage = new MediaReference();
                            MediaReference ProjectThumbnailImage = new MediaReference();
                            List<ProjectItemPage> _CsvProjectItemPageList = new List<ProjectItemPage>();

                            GetImagesfromVault(client, csvReader, MList, ref projectImage, ref ProjectThumbnailImage);

                            List<ProjectListingPage> _ProjectListingPageList = _contentLocator.GetAll<ProjectListingPage>(StartPage.ContentLink).ToList();
                            _ProjectListingPage = _ProjectListingPageList.Where(x => x.Name.Contains(csvReader.GetField<String>("Market Segment"))).FirstOrDefault();

                            if (_ProjectListingPage != null)
                            {
                                var checkProjectItemPage = _ProjectItemPageList.Where(x => x.Name.Contains(csvReader.GetField<String>("Project"))).FirstOrDefault();
                                if (checkProjectItemPage != null)
                                {
                                    //Update Project Item Page
                                    bool Update = true;
                                    BindProjectItemPage(_contentRepo, csvReader, MList, ProjectThumbnailImage, checkProjectItemPage, Update);

                                }
                                else
                                {
                                    //Create Project Item Page
                                    var _ProjectItemPage = _contentRepo.GetDefault<ProjectItemPage>(_ProjectListingPage.ContentLink);
                                    _ProjectItemPage.Name = csvReader.GetField<String>("Project");
                                    bool Update = false;
                                    BindProjectItemPage(_contentRepo, csvReader, MList, ProjectThumbnailImage, _ProjectItemPage, Update);
                                }
                            }
                            else
                            {
                                _ProjectListingPage = _contentRepo.GetDefault<ProjectListingPage>(_ProjectCategoryListPage.ContentLink);
                                _ProjectListingPage.Name = csvReader.GetField<String>("Market Segment");
                                _ProjectListingPage.PageBannerImage = projectImage;
                                ProjectListingPage = _ProjectListingPage.Name;
                                _contentRepo.Save(_ProjectListingPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.FullAccess);
                                var _ProjectItemPage = _contentRepo.GetDefault<ProjectItemPage>(_ProjectListingPage.ContentLink);
                                _ProjectItemPage.Name = csvReader.GetField<String>("Project");
                                bool Update = false;
                                BindProjectItemPage(_contentRepo, csvReader, MList, ProjectThumbnailImage, _ProjectItemPage, Update);
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
            string imageLocation = csvReader.GetField<String>("Images");
            string ImageName = imageLocation.Substring(imageLocation.LastIndexOf('\\') + 1);

            var FirstLevelCategories = client.Query<Category>().Where(c => c.Name.Contains("HCC-GAL"));

            foreach (ImageVault.Common.Data.Category firstitem in FirstLevelCategories)
            {


                var GreenFieldArchitects = firstitem.Categories.Where(x => x.Name.Contains("HCC")).FirstOrDefault();
                foreach (var item in GreenFieldArchitects.Categories.Where(x => x.Name.Contains("EXPERIENCE - MAIN IMAGES")))
                {
                    if (item != null)
                    {
                        var getimagesbycategories = client.Query<MediaItem>().Where(x => x.Categories.Contains(item.Id));
                        var MarketSegmentName = csvReader.GetField<String>("Market Segment").Replace("/", "").Replace(" ", "");
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

        private static void BindProjectItemPage(IContentRepository _contentRepo, CsvReader csvReader, MediaReferenceList<MediaReference> MList, MediaReference ProjectThumbnailImage, ProjectItemPage _ProjectItemPage, bool Update)
        {
            if (Update)
            {
                var _ProjectItemPageClone = (ProjectItemPage)_ProjectItemPage.CreateWritableClone();
                _ProjectItemPageClone.PageImage = null;
                _ProjectItemPageClone.PageBannerImage = null;
                _ProjectItemPageClone.ImageSlider = null;
                _ProjectItemPageClone.ProjectName = csvReader.GetField<String>("Project");
                _ProjectItemPageClone.Name = csvReader.GetField<String>("Project");
                _contentRepo.Save(_ProjectItemPageClone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);

                _ProjectItemPageClone.ProjectName = csvReader.GetField<String>("Project");
                _ProjectItemPageClone.facility = csvReader.GetField<String>("Facility");
                _ProjectItemPageClone.Size = csvReader.GetField<String>("Size");
                _ProjectItemPageClone.Architects = csvReader.GetField<String>("Architect");
                _ProjectItemPageClone.Location = csvReader.GetField<String>("Location");
                _ProjectItemPageClone.ServiceProvided = csvReader.GetField<String>("Services Provided");
                _ProjectItemPageClone.Description = new XhtmlString(csvReader.GetField<String>("Description"));
                _ProjectItemPageClone.MarketSegment = csvReader.GetField<String>("Market Segment");
                _ProjectItemPageClone.RepeatMarketSegment = csvReader.GetField<String>("REPEAT project in this Market Segment");
                _ProjectItemPageClone.PageImage = new MediaReference() { Id = ProjectThumbnailImage.Id };
                _ProjectItemPageClone.PageBannerImage = new MediaReference() { Id = ProjectThumbnailImage.Id };
                _ProjectItemPageClone.ImageSlider = new MediaReferenceList<MediaReference>(MList);
                _contentRepo.Save(_ProjectItemPageClone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
            }
            else
            {
                _ProjectItemPage.ProjectName = csvReader.GetField<String>("Project");
                _ProjectItemPage.facility = csvReader.GetField<String>("Facility");
                _ProjectItemPage.Size = csvReader.GetField<String>("Size");
                _ProjectItemPage.Location = csvReader.GetField<String>("Location");
                _ProjectItemPage.ServiceProvided = csvReader.GetField<String>("Services Provided");
                _ProjectItemPage.Architects = csvReader.GetField<String>("Architect");
                _ProjectItemPage.Description = new XhtmlString(csvReader.GetField<String>("Description"));
                _ProjectItemPage.MarketSegment = csvReader.GetField<String>("Market Segment");
                _ProjectItemPage.RepeatMarketSegment = csvReader.GetField<String>("REPEAT project in this Market Segment");
                _ProjectItemPage.PageImage = ProjectThumbnailImage;
                _ProjectItemPage.PageBannerImage = ProjectThumbnailImage;
                _ProjectItemPage.ImageSlider = new MediaReferenceList<MediaReference>(MList);
                _contentRepo.Save(_ProjectItemPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);
            }
        }

        #endregion
    }
}
