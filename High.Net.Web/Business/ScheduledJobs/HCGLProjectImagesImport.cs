using EPiServer;
using EPiServer.Core;
using EPiServer.Logging;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.RootPage;
using ImageVault.Client;
using ImageVault.Common.Data;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - HCGL Project Images", SortIndex = 950)]
    public class HCGLProjectImagesImport : ScheduledJobBase
    {

        #region Ctor

        public HCGLProjectImagesImport()
        {
            IsStoppable = true;
        }

        #endregion

        #region Variables

        private bool _stopSignaled;
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        Client _client = ImageVault.Client.ClientFactory.GetSdkClient();
        DataLocator _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
        ContentLocator _contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HCGLProjectImagesImport));

        #endregion

        #region Methods

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

                string status = ImportImages();
                //string status = GetProjectItemPageIds();

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

        public string ImportImages()
        {
            Logger.Error(", Page Id, Page Name, Total Images Imported, Page Image Name, Image Update Status");

            var parentCategory = _client.Query<Category>().Where(c => c.Name.Equals("HCGL")).FirstOrDefault();
            string importedPageId = String.Empty;

            if (parentCategory != null && parentCategory.Categories.Count > 0)
            {
                var HCGLProjectImageCat = parentCategory.Categories.Where(x => x.Name.Equals("HCGL Project Images")).FirstOrDefault();

                if (HCGLProjectImageCat != null && HCGLProjectImageCat.Categories.Count > 0)
                {
                    foreach (var CurrCat in HCGLProjectImageCat.Categories)
                    {
                        var currPageImages = _client.Query<MediaItem>().Where(x => x.Categories.Contains(CurrCat.Id)).ToList();
                        int pageId = 0;
                        var currPageId = int.TryParse(CurrCat.Name, out pageId) ? pageId : 0;
                        var currPage = new PageData();
                        var IsPageExist = _contentRepo.TryGet<PageData>(new ContentReference(pageId), out currPage);

                        if (currPageImages.Count() > 0 && IsPageExist)
                        {
                            try
                            {
                                if (currPage.GetType().BaseType == typeof(ProjectItemPage))
                                {
                                    OnStatusChanged(String.Format("Replacing images of  {0}", currPage.Name));
                                    var currPageClone = (ProjectItemPage)currPage.CreateWritableClone();
                                    var productImages = new List<MediaReference>();

                                    foreach (var item in currPageImages.OrderBy(x => x.Name))
                                    {
                                        productImages.Add(new MediaReference() {Id = item.Id});
                                    }

                                    currPageClone.Images = new MediaReferenceList<MediaReference>(productImages);
                        
                                    currPageClone.PageImage = productImages.Where(x => x.Id == currPageImages.OrderBy(img => img.Name).Select(img => img.Id).FirstOrDefault()).FirstOrDefault();

                                    _contentRepo.Save((IContent)currPageClone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                                    importedPageId += currPageClone.ContentLink.ID.ToString() + ",";
                                    Logger.Error(string.Format(", {0}, {1}, {2}, {3}, {4}", currPageClone.ContentLink.ID, currPageClone.Name, currPageImages.Count, currPageImages.OrderBy(img => img.Name).FirstOrDefault().Name, "Success"));
                                }
                                else if (currPage.GetType().BaseType == typeof(ProductItemPage))
                                {
                                    OnStatusChanged(String.Format("Replacing images of  {0}", currPage.Name));
                                    var currPageClone = (ProductItemPage)currPage.CreateWritableClone();
                                    var productImages = new List<MediaReference>();

                                    foreach (var item in currPageImages.OrderBy(x => x.Name))
                                    {
                                        productImages.Add(new MediaReference() { Id = item.Id });
                                    }

                                    currPageClone.Images = new MediaReferenceList<MediaReference>(productImages);
                                    currPageClone.PageImage = productImages.Where(x => x.Id == currPageImages.OrderBy(img => img.Name).Select(img => img.Id).FirstOrDefault()).FirstOrDefault();

                                    _contentRepo.Save((IContent)currPageClone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                                    importedPageId += currPageClone.ContentLink.ID.ToString() + ",";
                                    Logger.Error(string.Format(", {0}, {1}, {2}, {3}, {4}", currPageClone.ContentLink.ID, currPageClone.Name, currPageImages.Count, currPageImages.OrderBy(img => img.Name).FirstOrDefault().Name, "Success"));
                                }
                                else
                                {
                                    Logger.Error(string.Format(", {0}, {1}, {2}, {3}, {4}", CurrCat.Name,
                                        currPage != null ? currPage.Name : "N/A",
                                        currPageImages.Count,
                                        "N/A",
                                        "Page type mismatch"));
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(string.Format(", {0}, {1}, {2}, {3}, {4}", CurrCat.Name, ex.Message, 0, "N/A", "Error"));
                            }
                        }
                        else
                        {
                            Logger.Error(string.Format(", {0}, {1}, {2}, {3}, {4}", CurrCat.Name,
                                currPage != null ? currPage.Name : "N/A",
                                currPageImages.Count() > 0 ? currPageImages.Count() : 0,
                                "N/A",
                                currPage != null ? "No images to upload" : "No cms page found"));
                        }
                    }
                }
                else
                {
                    return "No 'HCGL Project Images' category or page id's found under HCGL Project Images.";
                }
                return String.Format("HCGL project images imported successfully for following pages {0}",importedPageId);
            }
            else
            {
                return "'HCGL Project Images' or Sub Category not found.";
            }
        }

        public string GetProjectItemPageIds()
        {
            Logger.Error(", PageId, PageName, PageType, NumberOfImagesOnPage, PageShortcutType");

            var concreteHomePage = new HomePage();
            var IsConcreteHomePage = _contentRepo.TryGet<HomePage>(PageReference.StartPage, out concreteHomePage);

            if (IsConcreteHomePage)
            {
                var projectItemPage = _contentLocator.GetAll<ProjectItemPage>(concreteHomePage.ContentLink);
                foreach (var _projectPage in projectItemPage)
                {
                    Logger.Error(", {0}, {1}, {2}, {3}, {4}",
                        _projectPage.ContentLink.ID,
                        _projectPage.Name,
                        _projectPage.GetType().BaseType.Name,
                        (_projectPage.Images != null) ? _projectPage.Images.Count : 0,
                        _projectPage.LinkType == PageShortcutType.Shortcut ? "Shortcut" :
                        _projectPage.LinkType == PageShortcutType.FetchData ? "FetchData" :
                        _projectPage.LinkType == PageShortcutType.External ? "External" : "Normal");
                }

                var productItemPage = _contentLocator.GetAll<ProductItemPage>(concreteHomePage.ContentLink);
                foreach (var _productPage in productItemPage)
                {
                    Logger.Error(", {0}, {1}, {2}, {3}, {4}",
                        _productPage.ContentLink.ID,
                        _productPage.Name,
                        _productPage.GetType().BaseType.Name,
                        _productPage.Images != null ? _productPage.Images.Count : 0,
                        _productPage.LinkType == PageShortcutType.Shortcut ? "Shortcut" :
                        _productPage.LinkType == PageShortcutType.FetchData ? "FetchData" :
                        _productPage.LinkType == PageShortcutType.External ? "External" : "Normal");
                }
                return "HCGL page id's captured successfully.";
            }
            else
            {
                return "HCGL Home page not found.";
            }
        }

        #endregion
    }
}
