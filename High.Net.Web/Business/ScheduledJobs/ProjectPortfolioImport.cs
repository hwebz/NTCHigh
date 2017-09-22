using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using High.Net.Models.Shared.Pages;
using EPiServer.ServiceLocation;
using EPiServer;
using High.Net.Core;
using EPiServer.Web.Routing;
using ImageVault.Client;
using EPiServer.Web;
using System.Web;
using System.IO;
using CsvHelper;
using High.Net.Models.RealEstateGroup.Blocks;
using EPiServer.DataAccess;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Project Portfolio Report Import", SortIndex = 200)]
    public class ProjectPortfolioImport : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        ContentLocator _contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
        Client _client = ImageVault.Client.ClientFactory.GetSdkClient();
        UrlResolver _resolver = ServiceLocator.Current.GetInstance<UrlResolver>();
        ContentAssetHelper _contentAssetHelper = ServiceLocator.Current.GetInstance<ContentAssetHelper>();
        DataLocator _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

        private bool _stopSignaled;

        public ProjectPortfolioImport()
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
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                string status = ReadExcelData();

                if (_stopSignaled)
                {
                    return "Stop of job was called";
                }

                return status;
            }
            else
            {
                return "You do not have the permission";
            }
        }
        public string ReadExcelData()
        {
            try
            {
                var realEstateGroupHomePage = _contentRepo.Get<High.Net.Models.RealEstateGroup.Pages.HomePage>(SiteDefinition.Current.StartPage);

                var projectPortfolioListingPage = _contentRepo.GetDefault<ProjectPortfolioListingPage>(realEstateGroupHomePage.ContentLink);
                projectPortfolioListingPage.Name = "Portfolio";
                _contentRepo.Save(projectPortfolioListingPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);

                var writableTargetBlock = (ProjectPortfolioListingPage)projectPortfolioListingPage.CreateWritableClone();
                var projectPortfolioFolder = _dataLocator.GetOrCreateFolder(ContentReference.SiteBlockFolder, "Project Portfolio");

                var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"import\{0}.csv", realEstateGroupHomePage.Name));
                using (TextReader textReader = File.OpenText(filePath))
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        while (csvReader.Read())
                        {
                            var projectPortfolioBlock = _contentRepo.GetDefault<ProjectPortfolioBlock>(projectPortfolioFolder.ContentLink);
                            projectPortfolioBlock.BuildingId = csvReader.GetField<String>("Bldgid");
                            projectPortfolioBlock.BuildingNameAddress = csvReader.GetField<String>("Building Name Address");
                            projectPortfolioBlock.PortfolioProject = csvReader.GetField<String>("Portfolio Project");
                            projectPortfolioBlock.TotalSqft = csvReader.GetField<String>("Total Sqft");
                            projectPortfolioBlock.AssetManager = csvReader.GetField<String>("Asset Manager");

                            ((IContent)projectPortfolioBlock).Name = projectPortfolioBlock.BuildingId;
                            _contentRepo.Save((IContent)projectPortfolioBlock, SaveAction.Publish);

                            if (writableTargetBlock.PortfolioContentArea == null)
                            {
                                writableTargetBlock.PortfolioContentArea = new ContentArea();
                            }

                            writableTargetBlock.PortfolioContentArea.Items.Add(new ContentAreaItem
                            {
                                ContentLink = ((IContent)projectPortfolioBlock).ContentLink
                            });
                        }
                        _contentRepo.Save((IContent)writableTargetBlock, SaveAction.Publish);

                        return string.Format("{0}, Project Portfolio Items Improted Successfully.", realEstateGroupHomePage.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
