using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System.Linq;
using ImageVault.Client;
using ImageVault.Client.Query;
using EPiServer.Web.Routing;
using ImageVault.Common.Data;
using High.Net.Models.HighConcrete.Blocks;
using EPiServer.DataAccess;
using ImageVault.EPiServer;
using System.IO;
using CsvHelper;
using System.Web;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Color Finishes Import", SortIndex = 300)]
    public class ColorFinishesImport : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        ContentLocator _contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
        Client _client = ImageVault.Client.ClientFactory.GetSdkClient();
        UrlResolver _resolver = ServiceLocator.Current.GetInstance<UrlResolver>();
        ContentAssetHelper _contentAssetHelper = ServiceLocator.Current.GetInstance<ContentAssetHelper>();
        DataLocator _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
        

        private bool _stopSignaled;

        public ColorFinishesImport()
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
                var highConcreteHomePage = _contentRepo.Get<High.Net.Models.HighConcrete.Pages.HomePage>(SiteDefinition.Current.StartPage);

                var colorSelectorListingPage = _contentRepo.GetDefault<ColorSelectorListingPage>(highConcreteHomePage.ContentLink);
                colorSelectorListingPage.Name = "Color Selector";
                _contentRepo.Save(colorSelectorListingPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);

                var writableTargetBlock = (ColorSelectorListingPage)colorSelectorListingPage.CreateWritableClone();
                var colorFinishesFolder = _dataLocator.GetOrCreateFolder(ContentReference.SiteBlockFolder, "Color Finishes");

                var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"import\{0}.csv", highConcreteHomePage.Name));
                using (TextReader textReader = File.OpenText(filePath))
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        while (csvReader.Read())
                        {
                            var colorFinishesBlock = _contentRepo.GetDefault<ColorFinishesBlock>(colorFinishesFolder.ContentLink);
                            colorFinishesBlock.Id = csvReader.GetField<String>("Item");
                            colorFinishesBlock.Color = csvReader.GetField<String>("Color Family");
                            colorFinishesBlock.Texture = csvReader.GetField<String>("Texture/Exposure");
                            colorFinishesBlock.CastPattern = csvReader.GetField<String>("Cast Patterns");
                            colorFinishesBlock.SeeItem = csvReader.GetField<String>("See Item");
                            colorFinishesBlock.Logo = csvReader.GetField<String>("Logo");
                            colorFinishesBlock.Description = new XhtmlString(csvReader.GetField<String>("Description"));

                            string fName = csvReader.GetField<String>("Filename");
                            var fileSL = _client.Query<MediaItem>().SearchFor(fName + "_sl").ToList();
                            if (fileSL.Count > 0)
                            {
                                colorFinishesBlock.ColorImage = new MediaReference() { Id = fileSL.First().Id };
                            }
                            else
                            {
                                var fileST = _client.Query<MediaItem>().SearchFor(fName + "_st").ToList();
                                colorFinishesBlock.ColorImage = new MediaReference() { Id = (fileSL.Count() > 0) ? fileSL.First().Id : (fileST.Count() > 0) ? fileST.First().Id : 0 };
                            }

                            ((IContent)colorFinishesBlock).Name = colorFinishesBlock.Id;
                            _contentRepo.Save((IContent)colorFinishesBlock, SaveAction.Publish);

                            if (writableTargetBlock.mainContentArea == null)
                            {
                                writableTargetBlock.mainContentArea = new ContentArea();
                            }

                            writableTargetBlock.mainContentArea.Items.Add(new ContentAreaItem
                            {
                                ContentLink = ((IContent)colorFinishesBlock).ContentLink
                            });
                        }
                        _contentRepo.Save((IContent)writableTargetBlock, SaveAction.Publish);

                        return string.Format("{0}, Color Finishes Items Improted Successfully.", highConcreteHomePage.Name);
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
