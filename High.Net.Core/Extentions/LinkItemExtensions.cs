using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using EPiServer.Web.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using EPiServer.Web.Mvc.Html;

namespace High.Net.Core.Extentions
{
    public static class LinkItemExtensions
    {
        public static bool TryParseToPageData(this LinkItem self, out PageData result)
        {
            return self.TryParseToPageData(out result, null);
        }

        /// <summary>
        /// Tries to parse a LinkItem to a PageData object
        /// </summary>
        /// <param name="self">LinkItem object</param>
        /// <param name="result">The PageData object if it can be parsed - otherwise null</param>
        /// <param name="languageBranch">The language code to return page data's from</param>
        /// <returns>If the LinkItem can be parsed to PageData</returns>
        public static bool TryParseToPageData(this LinkItem self, out PageData result, string languageBranch)
        {
            result = null;

            Guid guid = PermanentLinkUtility.GetGuid(self.Href);

            if (guid == Guid.Empty)
            {
                return false;
            }
            else
            {
                try
                {
                    PageReference pRef = PermanentLinkUtility.FindPageReference(guid);
                    if (languageBranch != null)
                    {
                        result = DataFactory.Instance.Get<PageData>(pRef, new LanguageSelector(languageBranch));
                        if (result == null)
                            return false;
                    }
                    else
                    {
                        result = DataFactory.Instance.Get<PageData>(pRef);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool TryParseToUnifiedFile(this LinkItem self, out UnifiedFile result)
        {
            return TryParseToUnifiedFile(self.Href, out result);
        }

        public static bool TryParseToUnifiedFile(string linkUrl, out UnifiedFile result)
        {
            result = null;

            string virtualPath;
            if (PermanentLinkMapStore.TryToMapped(linkUrl, out virtualPath))
            {
                try
                {
                    result = HostingEnvironment.VirtualPathProvider.GetFile(virtualPath) as UnifiedFile;

                    if (result != null)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public static PageDataCollection GetAsPageData(this LinkItemCollection self)
        {
            return self.GetAsPageData(null);
        }

        /// <summary>
        /// Gets the LinkItemCollection as a PageDataCollection
        /// Removes any links that are not PageData
        /// </summary>
        /// <param name="self">LinkItemCollection</param>
        /// <returns>PageDataCollection</returns>
        public static PageDataCollection GetAsPageData(this LinkItemCollection self, string languageBranch)
        {
            PageDataCollection pdc = new PageDataCollection();
            if (self != null)
            {
                foreach (LinkItem linkItem in self)
                {
                    PageData pData = null;
                    if (linkItem.TryParseToPageData(out pData, languageBranch) && pData.IsDeleted == false)
                    {
                        pdc.Add(pData);
                    }
                }
            }
            return pdc;
        }

        public static List<PageData> ToPages(this LinkItemCollection linkItemCollection)
        {
            List<PageData> pages = new List<PageData>();

            foreach (LinkItem linkItem in linkItemCollection)
            {
                string linkUrl;
                if (!PermanentLinkMapStore.TryToMapped(linkItem.Href, out linkUrl))
                    continue;
                if (string.IsNullOrEmpty(linkUrl))
                    continue;

                PageReference pageReference = PageReference.ParseUrl(linkUrl);

                if (PageReference.IsNullOrEmpty(pageReference))
                    continue;

                pages.Add(DataFactory.Instance.Get<PageData>((pageReference)));
            }
            return pages;
        }

        public static bool IsAPublishedPageOrExternalPage(this LinkItem link)
        {

            string linkUrl;
            if (!PermanentLinkMapStore.TryToMapped(link.Href, out linkUrl))
                return true;

            if (string.IsNullOrEmpty(linkUrl))
                return false;

            PageReference pageReference = PageReference.ParseUrl(linkUrl);

            if (PageReference.IsNullOrEmpty(pageReference))
                return true;

            var page = DataFactory.Instance.GetPage((pageReference));
            if (page.IsPublished())
                return true;
            else
            {
                return false;
            }



        }

        /// <summary>
        /// Detects wether it is an internal or external Url and returns the correct Url accordingly.
        /// </summary>
        /// <param name="link"></param>
        /// <param name="urlHelper"></param>
        /// <returns></returns>
        public static string ToMappedUrl(this LinkItem link, UrlHelper urlHelper)
        {
            if (link == null) return "";
            var url = new UrlBuilder(link.Href);

            return PermanentLinkMapStore.ToMapped(url)
                ? urlHelper.PageUrl(url.ToString()).ToHtmlString()
                : link.Href;
        }

        public static PageReference ToPageReference(this LinkItem linkItem)
        {
            string linkUrl;
            if (!PermanentLinkMapStore.TryToMapped(linkItem.Href, out linkUrl))
                return null;
            if (string.IsNullOrEmpty(linkUrl))
                return null;

            var pageReference = PageReference.ParseUrl(linkUrl);

            if (PageReference.IsNullOrEmpty(pageReference))
                return null;

            return pageReference;
        }

        public static PageData ToPageData(this LinkItem linkItem)
        {
            PageReference pageReference = linkItem.ToPageReference();
            if (pageReference != null)
            {
                return DataFactory.Instance.GetPage(pageReference);
            }

            return null;
        }
    }
}
