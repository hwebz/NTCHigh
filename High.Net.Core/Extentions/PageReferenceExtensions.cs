using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Core.Extentions
{
    public static partial class PageReferenceExtensions
    {
        /// <summary>
        /// Gets the page for a Pagereference.
        /// </summary>
        /// <param name="pageReference">The Pagereference</param>
        /// <returns>PageData object of a page</returns>
        public static PageData GetPage(this PageReference pageReference)
        {
            if (pageReference.IsNullOrEmptyPageReference())
            {
                return null;
            }

            return DataFactory.Instance.Get<PageData>(pageReference);
        }

        /// <summary>
        /// Gets the children of a Pagereference.
        /// </summary>
        /// <param name="pageReference">The Pagereference</param>
        /// <returns>PageDataDataCollection with the children of the page</returns>
        public static PageDataCollection GetChildren(this PageReference pageReference)
        {
            if (pageReference.IsNullOrEmptyPageReference())
            {
                return null;
            }

            return pageReference.GetPage().GetChildren<PageData>(true).ToPageDataCollection();
        }

        public static string GetFriendlyUrl(this PageReference pageReference)
        {
            if (pageReference.IsNullOrEmptyPageReference())
            {
                return string.Empty;
            }

            return pageReference.GetPage().GetFriendlyUrl();
        }

        public static string GetFriendlyGenericUrl(this PageReference pageLink)
        {
            return ServiceLocator.Current.GetInstance<UrlResolver>()
                                         .GetUrl(pageLink);
        }

        /// <summary>
        /// Gets the friendly URL for a page with nessary protocol
        /// </summary>
        /// <param name="page">The PageData object of the page</param>
        /// <param name="securedList">List of secured pages</param>
        /// <param name="isCurrentPageSecured">Current page is secured or not</param>
        /// <returns></returns>
        public static string GetSmartFriendlyUrl(this PageReference pageReference)
        {
            PageData page = pageReference.GetPage();
            string returnUrl = page.GetSmartFriendlyUrl();

            return returnUrl;
        }

        public static bool IsNullOrEmptyPageReference(this PageReference pageReference)
        {
            return PageReference.IsNullOrEmpty(pageReference);
        }

        public static string GetFallbackOnPreferredFailure(this PageReference pageReference)
        {
            string returnUrl = string.Empty;
            try
            {
                PageDataCollection pageLanguages = DataFactory.Instance.GetLanguageBranches(pageReference);
                new FilterPublished(PagePublishedStatus.Published).Filter(pageLanguages);

                foreach (PageData page in pageLanguages)
                {
                    if (page.LanguageBranch == ContentLanguage.PreferredCulture.Name)
                    {
                        returnUrl = page.GetFriendlyUrl();
                        break;
                    }
                }

                if (string.IsNullOrEmpty(returnUrl))
                {
                    CultureInfo originalCultureInfo = ContentLanguage.PreferredCulture;
                    PageData pageData = pageReference.GetPage();
                    ContentLanguage.PreferredCulture = new System.Globalization.CultureInfo(pageData.MasterLanguageBranch);
                    returnUrl = pageReference.GetFriendlyUrl();
                    ContentLanguage.PreferredCulture = originalCultureInfo;
                }
            }
            catch (Exception)
            {
                //die quietly
            }
            return returnUrl;
        }
    }
}
