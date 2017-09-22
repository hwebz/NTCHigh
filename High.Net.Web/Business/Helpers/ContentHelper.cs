using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Web.Business.Helpers
{
    public class ImageVaultData
    {
        public int UatId { get; set; }
        public int ProdId { get; set; }
    }

    public class MediaRef
    {
        public MediaReference Media { get; set; }
        public string MediaFieldName { get; set; }
    }

    public static class ContentHelper
    {
        private static readonly IContentRepository contentRepository;

        static ContentHelper()
        {
            contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
        }

        public static string GetGoogleTagManagerId()
        {
            var startPage =
                ServiceLocator.Current.GetInstance<IContentRepository>().Get<PageData>(ContentReference.StartPage);
            return startPage.Property.Contains("GoogleTagManagerId")
                ? startPage.Property["GoogleTagManagerId"].ToString()
                : string.Empty;
        }

        public static List<string> UpdateMediaItemsOfBlock(this ContentArea area, List<ImageVaultData> updateLinkRef)
        {
            var affectedMediaItems = new List<string>();
            if (area.Count <= 0)
                return new List<string>();
            foreach (var blockRef in area.Items)
            {
                var content = blockRef.GetContent();
                var block = content as BlockData;
                if (block != null)
                {
                    var imageVaultItems =
                        block.GetOriginalType().GetProperties().Where(x => x.PropertyType == typeof(MediaReference));
                    if (null != imageVaultItems && imageVaultItems.Any())
                    {
                        var imgCount = 0;
                        var clone = block.CreateWritableClone();
                        foreach (var imgVaultProp in imageVaultItems)
                        {
                            if (null == (MediaReference)imgVaultProp.GetValue(block))
                                continue;
                            var uatId = ((MediaReference)imgVaultProp.GetValue(block)).Id;
                            if (updateLinkRef.Any(x => x.UatId == uatId))
                            {
                                clone[imgVaultProp.Name] =
                                    new PropertyMedia(new MediaReference
                                    {
                                        Id = updateLinkRef.Single(x => x.UatId == uatId).ProdId
                                    }).ToRawProperty().Value;
                                contentRepository.Save(clone as IContent, SaveAction.Publish, AccessLevel.NoAccess);
                                imgCount += 1;
                                var message = string.Format("Found uat id: {0}, replace by prod id:{1} \n\n", uatId,
                                    updateLinkRef.Single(x => x.UatId == uatId).ProdId);
                                affectedMediaItems.Add(message);
                            }
                        }
                        affectedMediaItems.Add(string.Format("Update {0} image(s) of block: {1} \n", imgCount,
                            ((IContent)block).Name));
                    }

                    //Update image valault links for child items.
                    var childAreas =
                        block.GetOriginalType().GetProperties().Where(x => x.PropertyType == typeof(ContentArea));
                    if (childAreas != null && childAreas.Any())
                    {
                        foreach (var childAreaProp in childAreas)
                        {
                            var childArea = childAreaProp.GetValue(block) as ContentArea;
                            if (null == childArea)
                                continue;
                            var messageStatus = childArea.UpdateMediaItemsOfBlock(updateLinkRef);
                            if (messageStatus.Any())
                                affectedMediaItems.AddRange(messageStatus);
                        }
                    }
                }
            }
            return affectedMediaItems;
        }

        public static T GetContent<T>(this ContentReference contentRef) where T : ContentData
        {
            if (ContentReference.IsNullOrEmpty(contentRef))
            {
                return null;
            }
            var content = contentRepository.Get<ContentData>(contentRef);
            return content as T;
        }

        public static T GetHomePage<T>(this BasePageData currentPage) where T : BasePageData
        {
            if (currentPage == null) { return null; }

            //TODO: updated later when change to using sub-domain
            return SiteDefinition.Current.StartPage != null ? SiteDefinition.Current.StartPage.GetContent<T>() : null;
        }


        public static string GetSiteColor(this BasePageData currentPage) 
        {
            var homePage = currentPage.GetHomePage<BasePageData>();
            if(homePage is ICommonHome) { return ((ICommonHome)homePage).SiteColor; }            
            return string.Empty;
        }

        public static string GetSiteColor<T>(this T currentPage) where T : ICommonHome
        {
            if (currentPage == null) return string.Empty;
            return currentPage.SiteColor;
        }

    }
}