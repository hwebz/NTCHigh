using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer;
using System.Collections.Generic;
using EPiServer.Web.Mvc.Html;

namespace High.Net.Core
{
    public static class UrlHelpers
    {
        /// <summary>
        /// Returns the target URL for a ContentReference. Respects the page's shortcut setting
        /// so if the page is set as a shortcut to another page or an external URL that URL
        /// will be returned.
        /// </summary>
        public static IHtmlString PageLinkUrl(this UrlHelper urlHelper, ContentReference contentLink)
        {
            if(ContentReference.IsNullOrEmpty(contentLink))
            {
                return MvcHtmlString.Empty;
            }

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var page = contentLoader.Get<PageData>(contentLink);

            return PageLinkUrl(urlHelper, page);
        }


        /// <summary>
        /// Returns the target URL for a page. Respects the page's shortcut setting
        /// so if the page is set as a shortcut to another page or an external URL that URL
        /// will be returned.
        /// </summary>
        public static IHtmlString PageLinkUrl(this UrlHelper urlHelper, PageData page)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            switch (page.LinkType)
            {
                case PageShortcutType.Normal:
                case PageShortcutType.FetchData:
                    return new MvcHtmlString(urlResolver.GetUrl(page.ContentLink));

                case PageShortcutType.Shortcut:
                    var shortcutProperty = page.Property["PageShortcutLink"] as PropertyPageReference;
                    if (shortcutProperty != null && !ContentReference.IsNullOrEmpty(shortcutProperty.ContentLink))
                    {
                        return urlHelper.PageLinkUrl(shortcutProperty.ContentLink);
                    }
                    break;

                case PageShortcutType.External:
                    return new MvcHtmlString(page.LinkURL);
            }
            return MvcHtmlString.Empty;
        }
        public static string AddParameter(string urlstr, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(urlstr);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri.ToString();
        }
        public static RouteValueDictionary GetPageRoute(this RequestContext requestContext, ContentReference contentLink)
        {
            var values = new RouteValueDictionary();
            values[RoutingConstants.NodeKey] = contentLink;
            values[RoutingConstants.LanguageKey] = ContentLanguage.PreferredCulture.Name;
            return values;
        }

        public static RouteValueDictionary ContentRoute(this UrlHelper urlHelper, ContentReference contentLink, object routeValues = null)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary(routeValues).Union(urlHelper.RequestContext.RouteData.Values);
            dictionary[RoutingConstants.ActionKey] = "index";
            dictionary[RoutingConstants.NodeKey] = contentLink;
            return dictionary;
        }

        public static string GetContentUrl(this UrlHelper urlHelper, EPiServer.Url contentUrl)
        {
            var url = urlHelper.ContentUrl(contentUrl);
            return string.IsNullOrEmpty(url) ? "#" : url;
        }

        private static RouteValueDictionary Union(this RouteValueDictionary first, RouteValueDictionary second)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary(second);
            foreach (KeyValuePair<string, object> pair in first)
            {
                if (pair.Value != null)
                {
                    dictionary[pair.Key] = pair.Value;
                }
            }
            return dictionary;
        }
    }
}
