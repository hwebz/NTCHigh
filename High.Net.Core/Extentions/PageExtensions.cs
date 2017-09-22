using EPiServer;
using EPiServer.Configuration;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace High.Net.Core.Extentions
{
    public static class PageExtensions 
    {
        public static PageData CurrentPageFromHttpContext
        {
            get
            {
                var page = HttpContext.Current.Handler as PageBase;

                if (page == null)
                {
                    return null;
                }

                return page.CurrentPage;
            }
        }

        public static bool InSection(this PageData currentPage, PageData sectionPage)
        {
            bool insection = false;
            PageData counterPage = currentPage;
            while (counterPage != null && counterPage.PageLink != PageReference.StartPage)
            {
                if (sectionPage.PageLink == counterPage.PageLink)
                {
                    insection = true;
                    break;
                }
                counterPage = counterPage.GetParentPage();
            }
            return insection;
        }

        public static Type GetPageTypeType(this PageData page)
        {
            var contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var content = contentRepo.Get<IContent>(page.PageLink);
            var contentType = content.GetOriginalType();
            return contentType;
        }

        public static PageDataCollection GetAllChildPagesOfType(this PageData rootPage, Type[] pageTypesToInclude)
        {
            PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();
            return GetAllChildPagesOfType(rootPage.PageLink, pageTypesToInclude, criterias, false);
        }

        public static PageDataCollection GetAllChildPagesOfTypeIncludingDeleted(this PageData rootPage, Type[] pageTypesToInclude)
        {
            PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();
            return GetAllChildPagesOfType(rootPage.PageLink, pageTypesToInclude, criterias, true);
        }

        public static PageDataCollection GetAllChildPagesOfType(this PageReference rootPageRef, Type[] pageTypesToInclude, PropertyCriteriaCollection withCriteria, bool includeDeleted)
        {
            return GetAllChildPagesOfType(rootPageRef, pageTypesToInclude, withCriteria, null, includeDeleted);
        }

        public static PageDataCollection GetAllChildPagesOfType(this PageReference rootPageRef, Type[] pageTypesToInclude, PropertyCriteriaCollection withCriteria, TimeSpan? timeSpan, bool includeDeleted)
        {
            var pageTypeRep = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            PropertyCriteria pc = new PropertyCriteria();

            bool singlePageType = (pageTypesToInclude.Count() == 1);
            var pageTypesToIncludeString = TypeExtensions.GetPageTypeNameList(pageTypesToInclude);
            foreach (string pageTypeName in pageTypesToIncludeString)
            {
                string pageTypeId = pageTypeRep.Load(pageTypeName).ID.ToString();
                pc = new PropertyCriteria();
                pc.Type = PropertyDataType.PageType;
                pc.Value = pageTypeId;
                pc.Condition = CompareCondition.Equal;
                pc.Required = singlePageType;
                pc.Name = "PageTypeID";
                withCriteria.Add(pc);
            }

            if (timeSpan.HasValue)
            {
                pc = new PropertyCriteria();
                pc.Condition = CompareCondition.GreaterThan;
                pc.Value = (DateTime.Now - timeSpan.Value).ToString();
                pc.Type = PropertyDataType.Date;
                pc.Required = true;
                pc.Name = "PageStartPublish";
                withCriteria.Add(pc);
            }

            PageDataCollection childPages = DataFactory.Instance.FindPagesWithCriteria(
                rootPageRef, withCriteria);

            childPages = childPages.FilterPages(includeDeleted);

            return childPages.SortByPageChildOrderRule(rootPageRef);
        }

        public static PageDataCollection SortByPageChildOrderRule(this PageDataCollection childPages, PageReference rootPageRef)
        {
            PageData rootPage = DataFactory.Instance.Get<PageData>(rootPageRef);
            FilterSortOrder filter = (FilterSortOrder)rootPage.Property["PageChildOrderRule"].Value;

            FilterPropertySort sorter;
            switch (filter.ToString())
            {
                case ("Alphabetical"):
                    sorter = new FilterPropertySort("PageName", (FilterSortDirection.Ascending));
                    sorter.Filter(childPages);
                    break;
                case ("CreatedDescending"):
                    sorter = new FilterPropertySort("PageCreated", (FilterSortDirection.Descending));
                    sorter.Filter(childPages);
                    break;
                case ("CreatedAscending"):
                    sorter = new FilterPropertySort("PageCreated", (FilterSortDirection.Ascending));
                    sorter.Filter(childPages);
                    break;
                case ("ChangedDescending"):
                    sorter = new FilterPropertySort("PageChanged", (FilterSortDirection.Descending));
                    sorter.Filter(childPages);
                    break;
                case ("Rank"):
                    sorter = new FilterPropertySort("PagePeerOrder", (FilterSortDirection.Ascending));
                    sorter.Filter(childPages);
                    break;
                case ("PublishedAscending"):
                    sorter = new FilterPropertySort("PageStartPublish", (FilterSortDirection.Ascending));
                    sorter.Filter(childPages);
                    break;
                case ("PublishedDescending"):
                    sorter = new FilterPropertySort("PageStartPublish", (FilterSortDirection.Descending));
                    sorter.Filter(childPages);
                    break;
                case ("Index"):
                    sorter = new FilterPropertySort("PagePeerOrder", (FilterSortDirection.Ascending));
                    sorter.Filter(childPages);
                    break;
                default:
                    break;
            }

            return childPages;
        }

        public static PageDataCollection GetAllChildPagesOfTypeAndCategory(this PageReference rootPageRef, Type[] pageTypesToInclude, CategoryList category)
        {
            return GetAllChildPagesOfTypeAndCategory(rootPageRef, pageTypesToInclude, category, null);
        }

        public static PageDataCollection GetAllChildPagesOfTypeAndCategory(this PageReference rootPageRef, Type[] pageTypesToInclude, CategoryList category, TimeSpan? timeSpan)
        {
            CategoryList childcategories = new CategoryList();
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            foreach (int cid in category)
            {
                GetChildCategories(categoryRepository.Get(cid), ref childcategories);
            }

            if (childcategories.Count == 0)
            {
                return new PageDataCollection();
            }

            PropertyCriteriaCollection propertyCriterias = new PropertyCriteriaCollection();

            PropertyCriteria pc = new PropertyCriteria();
            pc.Condition = CompareCondition.Equal;
            pc.Value = childcategories.ToString();
            pc.Type = PropertyDataType.Category;
            pc.Required = true;
            pc.Name = "PageCategory";
            propertyCriterias.Add(pc);

            return GetAllChildPagesOfType(rootPageRef, pageTypesToInclude, propertyCriterias, timeSpan, false);
        }

        private static void GetChildCategories(Category category, ref CategoryList categories)
        {
            categories.Add(category.ID);
            foreach (Category subcategory in category.Categories)
            {
                GetChildCategories(subcategory, ref categories);
            }
        }

        public static int Level(this PageData pageData)
        {
            int returnValue;
            if (pageData.PageLink.ID == PageReference.RootPage.ID)
            {
                returnValue = 0;
            }
            else
            {
                returnValue = 1 + DataFactory.Instance.Get<PageData>(pageData.ParentLink).Level();
            }
            return returnValue;
        }

        public static bool IsPageInEditMode(this PageData page)
        {
            return page.WorkPageID != 0;
        }

        #region Get Published / Saved Versions
        public static PageData GetPreviouslyPublishedVersion(this PageReference pageRef)
        {
            var contentVersionRepo = ServiceLocator.Current.GetInstance<IContentVersionRepository>();
            ContentVersion previousVersion = contentVersionRepo.List(pageRef)
                                                     .FirstOrDefault(pv => pv.Status == VersionStatus.PreviouslyPublished || pv.Status == VersionStatus.Published);

            return previousVersion != null ? DataFactory.Instance.Get<PageData>(previousVersion.ContentLink, LanguageSelector.AutoDetect(true)) : null;
        }

        public static PageData GetPreviouslySavedVersion(this PageReference pageRef)
        {
            var contentVersionRepo = ServiceLocator.Current.GetInstance<IContentVersionRepository>();
            ContentVersion previousVersion = contentVersionRepo.List(pageRef).FirstOrDefault();

            return previousVersion != null ? DataFactory.Instance.Get<PageData>(previousVersion.ContentLink, LanguageSelector.AutoDetect(true)) : null;
        }

        public static IEnumerable<PageData> GetPreviousVersions(this PageReference pageRef)
        {
            var contentVersionRepo = ServiceLocator.Current.GetInstance<IContentVersionRepository>();
            IEnumerable<ContentVersion> previousVersions = contentVersionRepo.List(pageRef);

            foreach (PageVersion previousVersion in previousVersions)
            {
                yield return DataFactory.Instance.Get<PageData>(previousVersion.ContentLink, LanguageSelector.AutoDetect(true));
            }
        }
        #endregion

        #region Get Parent Pages

        /// <summary>
        /// Gets the parent page data of the current page
        /// </summary>
        /// <param name="rootPage"></param>
        /// <returns></returns>
        public static PageData GetParentPage(this PageData rootPage)
        {
            if (rootPage != null && !PageReference.IsNullOrEmpty(rootPage.ParentLink))
            {
                return DataFactory.Instance.Get<PageData>(rootPage.ParentLink);
            }
            return null;
        }

        public static PageData GetParentPage(this PageData rootPage, string language)
        {
            if (rootPage != null && !PageReference.IsNullOrEmpty(rootPage.ParentLink))
            {
                return DataFactory.Instance.Get<PageData>(rootPage.ParentLink, new EPiServer.Core.LanguageSelector(language));
            }
            return null;
        }

        /// <summary>
        /// Recursively looks for parent pages with matching PageTypName
        /// </summary>
        public static PageData GetParentOfType(this PageData rootPage, Type pageType, bool includeRootPage)
        {
            string pageTypeName = pageType.GetPageTypeName();
            var page = rootPage;
            if (!includeRootPage)
            {
                page = page.GetParentPage();
            }
            while (page != null)
            {
                if (page.PageTypeName == pageTypeName)
                {
                    return page;
                }
                page = page.GetParentPage();
            }

            return null;
        }

        public static PageData GetParentOfType(this PageData rootPage, Type pageType, bool includeRootPage, string language)
        {
            string pageTypeName = pageType.GetPageTypeName();
            var page = rootPage;
            if (!includeRootPage)
            {
                page = page.GetParentPage(language);
            }
            while (page != null)
            {
                if (page.PageTypeName == pageTypeName)
                {
                    return page;
                }
                page = page.GetParentPage(language);
            }

            return null;
        }

        /// <summary>
        /// Recursively looks for parent pages which implement the specified interface
        /// </summary>
        public static PageData GetParentImplementingInterface(this PageData rootPage, Type interfaceType, bool includeRootPage)
        {
            var page = rootPage;
            if (!includeRootPage)
            {
                page = page.GetParentPage();
            }
            while (page != null)
            {
                if (page.ImplementsInterface(interfaceType))
                {
                    return page;
                }
                page = page.GetParentPage();
            }

            return null;
        }

        /// <summary>
        /// checks if a page implements the specified interface
        /// </summary>
        /// <param name="rootPage"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static bool ImplementsInterface(this PageData pageData, Type interfaceType)
        {
            var type = GetPageTypeType(pageData);
            if (type != null)
            {
                return interfaceType.IsAssignableFrom(type);
            }

            return false;
        }

        /// <summary>
        /// Gets all parents from the current page up to the root
        /// </summary>
        /// <param name="rootPage"></param>
        /// <returns></returns>
        public static PageDataCollection GetAllParents(this PageData rootPage)
        {
            return rootPage.GetAllParents(PageReference.EmptyReference);
        }

        public static PageDataCollection GetAllParents(this PageData rootPage, PageReference stopPageReference)
        {
            PageDataCollection parents = new PageDataCollection();
            PageData page = rootPage;

            PageReference stopReference = PageReference.IsNullOrEmpty(stopPageReference)
                                              ? PageReference.StartPage
                                              : stopPageReference;

            while (page != null && page.PageLink != stopReference && !PageReference.IsNullOrEmpty(page.ParentLink))
            {
                page = DataFactory.Instance.Get<PageData>(page.ParentLink);
                parents.Add(page);
            }
            return parents;
        }

        #endregion

        #region Get Sibling Pages

        /// <summary>
        /// Gets all pages at the same level as current page
        /// </summary>
        /// <param name="rootPage"></param>
        /// <returns></returns>
        public static PageDataCollection GetAllSiblings(this PageData rootPage, bool excludeSourcePage)
        {
            if (rootPage.ParentLink == PageReference.RootPage)
            {
                var pageCollection = new PageDataCollection();
                pageCollection.Add(rootPage);
                return pageCollection;
            }
            var siblings = rootPage.GetParentPage().GetAllChildren();
            if (excludeSourcePage)
            {
                siblings = new PageDataCollection((from s in siblings where s.PageLink != rootPage.PageLink select s));
            }
            return siblings;
        }


        #endregion

        #region Page Properties

        /// <summary>
        /// Gets a LinkItemCollection from the specified property
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        //public static LinkItemCollection GetLinkItemCollection(this PageData pData, string propertyName)
        //{
        //    if (pData == null)
        //    {
        //        return null;
        //    }

        //    var lic = pData[propertyName] as LinkItemCollection ?? new LinkItemCollection();
        //    var result = new LinkItemCollection();
        //    foreach (var linkItem in lic)
        //    {
        //        PageData pd;
        //        if (linkItem.TryParseToPageData(out pd) && pd.IsDeleted)
        //        {
        //            continue;
        //        }
        //        result.Add(linkItem);
        //    }
        //    return result;
        //}


        //public static PageDataCollection GetPageDataCollectionFromLinkItemCollection(this PageData pData, string propertyName)
        //{
        //    return GetPageDataCollection(pData.GetLinkItemCollection(propertyName));
        //}

        //public static PageDataCollection GetPageDataCollectionFromLinkItemCollection(this LinkItemCollection linkCollection)
        //{
        //    return GetPageDataCollection(linkCollection);
        //}

        //private static PageDataCollection GetPageDataCollection(LinkItemCollection linkCollection)
        //{
        //    PageDataCollection pDC = new PageDataCollection();
        //    foreach (LinkItem linkItem in linkCollection)
        //    {
        //        Guid guid = PermanentLinkUtility.GetGuid(linkItem.Href);
        //        PageReference pRef = PermanentLinkUtility.FindPageReference(guid);

        //        if (pRef.IsNullOrEmptyPageReference())
        //        {
        //            continue;

        //        }
        //        pDC.Add(DataFactory.Instance.Get<PageData>(pRef));
        //    }
        //    return pDC;

        //}


        public static string GetLinkProperty(this PageData pData, string propertyName)
        {
            var pr = pData[propertyName] as PageReference;

            return PageReference.IsNullOrEmpty(pr)
                       ? pData[propertyName] as string
                       : DataFactory.Instance.Get<PageData>(pr).LinkURL;
        }

        /// <summary>
        /// Gets a string property.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns>Returns the value or an empty string if it is null</returns>
        public static string GetStringProperty(this PageData pData, string propertyName)
        {
            return pData.GetStringProperty(propertyName, String.Empty);
        }

        /// <summary>
        /// Gets a string property.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the value or a default value if it is null</returns>
        public static string GetStringProperty(this PageData pData, string propertyName, string defaultValue)
        {
            return pData[propertyName] as string ?? defaultValue;
        }

        /// <summary>
        /// Gets an integer property.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns>The value or 0 if it is null</returns>
        public static int GetIntProperty(this PageData pData, string propertyName)
        {
            return pData.GetIntProperty(propertyName, 0);
        }

        /// <summary>
        /// Gets an integer property. 
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the value or a default value if it is null.</returns>
        public static int GetIntProperty(this PageData pData, string propertyName, int defaultValue)
        {
            object data = pData[propertyName];

            if (data is string)
            {
                int val = new int();

                if (int.TryParse((string)data, out val))
                {
                    return val;
                }
                else
                {
                    return defaultValue;
                }
            }

            return data as int? ?? defaultValue;
        }

        /// <summary>
        /// Gets a double property
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns>Returns the value or 0.0 if null.</returns>
        public static double GetDoubleProperty(this PageData pData, string propertyName)
        {
            return pData.GetDoubleProperty(propertyName, 0.0);
        }

        /// <summary>
        /// Gets a double property
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the value or a default value if null.</returns>
        public static double GetDoubleProperty(this PageData pData, string propertyName, double defaultValue)
        {
            object data = pData[propertyName];

            if (data is string)
            {
                double val = new double();
                if (double.TryParse((string)data, out val))
                {
                    return val;
                }
                else
                {
                    return defaultValue;
                }
            }

            return data as double? ?? defaultValue;
        }

        /// <summary>
        /// Gets a bool value.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns>Returns the value or false if it is null</returns>
        public static bool GetBoolProperty(this PageData pData, string propertyName)
        {
            return pData.GetBoolProperty(propertyName, false);
        }

        /// <summary>
        /// Gets a bool value.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the value or a default value if it is null</returns>
        public static bool GetBoolProperty(this PageData pData, string propertyName, bool defaultValue)
        {
            return pData[propertyName] as bool? ?? defaultValue;
        }

        /// <summary>
        /// Gets a datetime property
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns>Returns the value or DateTime.Now if it is null</returns>
        public static DateTime? GetDateTimeProperty(this PageData pData, string propertyName)
        {
            return pData.GetDateTimeProperty(propertyName, DateTime.Now);
        }

        /// <summary>
        /// Gets a datetime property
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the value or a default value if it is null</returns>
        public static DateTime? GetDateTimeProperty(this PageData pData, string propertyName, DateTime? defaultValue)
        {
            return pData[propertyName] as DateTime? ?? defaultValue;
        }

        public static DateTime? GetDateTimeProperty(this PageData pData, string propertyName, bool returnNullable)
        {
            return returnNullable ? pData[propertyName] as DateTime? : pData.GetDateTimeProperty(propertyName);
        }

        /// <summary>
        /// Gets a PageReference from a property
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <returns>Returns PageReference or null if there was a problem</returns>
        public static PageReference GetPageReferenceProperty(this PageData pData, string propertyName)
        {
            return pData[propertyName] as PageReference;
        }

        /// <summary>
        /// Gets an EPiServer property of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pData"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns the value or null if it cannot be cast or does not exist</returns>
        public static T GetProperty<T>(this PageData pData, string propertyName, T defaultValue) where T : class
        {
            return pData[propertyName] as T ?? defaultValue;
        }

        /// <summary>
        /// Gets the link for the page
        /// </summary>
        public static string GetPageUrl(this PageData pData)
        {
            return pData.LinkURL;
        }

        /// <summary>
        /// Get the link target _blank or _top
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public static string GetLinkTarget(this PageData pData)
        {
            if (pData["PageTargetFrame"] != null)
            {
                return (pData["PageTargetFrame"].ToString() == "1") ? "_blank" : "_top";
            }
            return string.Empty;
        }
        #endregion

        #region Sorting and Filtering Methods

        /// <summary>
        /// Sorts pages by Rank (Asc) then Main_Title page property (Asc)
        /// </summary>
        /// <param name="pages"></param>
        /// <returns></returns>
        public static PageDataCollection SortPagesDefault(this PageDataCollection pages)
        {
            var sortedPages = from p in pages
                              where p.IsDeleted == false
                              orderby p["PagePeerOrder"], p["Main_Title"]
                              select p;

            return new PageDataCollection(sortedPages);
        }

        /// <summary>
        /// Sorts pages by the StartPublish property
        /// </summary>
        /// <param name="pages"></param>
        /// <returns></returns>
        public static PageDataCollection SortPagesByDate(this PageDataCollection pages)
        {
            IEnumerable<PageData> sorted =
                from page in pages
                orderby page.StartPublish descending
                select page;
            return new PageDataCollection(sorted);
        }


        public static PageDataCollection SortPagesByLastModified(this PageDataCollection pages)
        {
            FilterSort indexSorter = new FilterSort(FilterSortOrder.ChangedDescending);
            indexSorter.Sort(pages);
            return pages;
        }

        /// <summary>
        /// Filters pages, includes unpublished versions, does not include deleted pages
        /// This is needed when we use FindPagesWithCriteria
        /// </summary>
        /// <param name="pages"></param>
        /// <returns></returns>
        public static PageDataCollection FilterPages(this PageDataCollection pages)
        {
            return FilterPages(pages, false);
        }

        /// <summary>
        /// /// Filters pages, includes unpublished versions, optionally includes deleted pages
        /// This is needed when we use FindPagesWithCriteria
        /// </summary>
        /// <param name="pages">Input PageDataCollection</param>
        /// <param name="includeDeleted">Include deleted pages?</param>
        /// <returns>New filtered PageDataCollection</returns>
        public static PageDataCollection FilterPages(this PageDataCollection pages, bool includeDeleted)
        {
            PageDataCollection retVal = new PageDataCollection();

            new FilterAccess().Filter(pages);

            foreach (var page in pages)
            {
                retVal.Add(page.Status != VersionStatus.Published ? DataFactory.Instance.Get<PageData>(new PageReference(page.PageLink.ID, true)) : page);
            }

            return (includeDeleted) ? retVal : new PageDataCollection(retVal.Where(p => !p.IsDeleted));
        }

        #endregion

        #region Friendly URL Methods

        /// <summary>
        /// Gets the friendly URL for a page
        /// </summary>
        /// <param name="page">The PageData object of the page</param>
        /// <returns>The friendly url of the specified page</returns>
        /// <remarks>Extension method</remarks>
        public static string GetFriendlyUrl(this PageData page)
        {
            string url = GetFriendlyUrl(page, false);

            return url;
        }

        /// <summary>
        /// Gets the friendly URL for a page with nessary protocol
        /// </summary>
        /// <param name="page">The PageData object of the page</param>
        /// <param name="securedList">List of secured pages</param>
        /// <param name="isCurrentPageSecured">Current page is secured or not</param>
        /// <returns></returns>
        public static string GetSmartFriendlyUrl(this PageData page)
        {
            string returnUrl = page.GetFriendlyUrl();
            /*
            log.DebugFormat("GetSmartFriendlyUrl: returnUrl {0} page.PageLink.ID {1}", returnUrl, page.PageLink.ID);

            List<int> securedList = RedirectModuleHelper.GetSslIdCollection();
            HttpRequest request = HttpContext.Current.Request;

            if (request.IsSecureConnection)
            {
                if (!securedList.Contains(page.PageLink.ID))
                {
                    returnUrl = string.Concat(Uri.UriSchemeHttp, Uri.SchemeDelimiter,
                               request.Url.Authority, page.GetFriendlyUrl());
                }
            }
            else
            {
                if (securedList.Contains(page.PageLink.ID))
                {
                    returnUrl = string.Concat(Uri.UriSchemeHttps, Uri.SchemeDelimiter,
                               request.Url.Authority, page.GetFriendlyUrl());
                }

            }
            log.DebugFormat("GetSmartFriendlyUrl: returnUrl {0} ", returnUrl);
            */
            return returnUrl;
        }

        /// <summary>
        /// Gets the friendly URL for a page
        /// </summary>
        /// <param name="page">The PageData object of the page</param>
        /// <returns>The friendly url of the specified page</returns>
        /// <param name="absolute">True to return an absolute URL</param>
        /// <remarks>Extension method</remarks>
        public static string GetFriendlyUrl(this PageData page, bool absolute)
        {
            return page != null ? GetFriendlyUrlString(page.PageLink, page.LinkURL, absolute) : string.Empty;
        }

        /// <summary>
        /// Gets the friendly URL for the page using provided language id.
        /// </summary>
        /// <param name="page">The page data.</param>
        /// <param name="languageId">The language id.</param>
        /// <param name="absolute">True to return an absolute URL</param>
        /// <returns></returns>
        public static string GetFriendlyUrl(this PageData page, string languageId, bool absolute)
        {
            const string languageQueryStringKey = "&epslanguage=";
            string linkUrl = UriSupport.AddLanguageSelection(page.LinkURL, languageId);
            if (linkUrl.Contains(languageQueryStringKey))
            {
                linkUrl = linkUrl.Remove(linkUrl.IndexOf(languageQueryStringKey));
                linkUrl = string.Concat(linkUrl, languageQueryStringKey, languageId);
            }

            return GetFriendlyUrlString(page.PageLink, linkUrl, absolute);
        }

        /// <summary>
        /// Gets the friendly URL for a page
        /// </summary>
        /// <param name="pageReference">The PageReference</param>
        /// <param name="url">The LinkUrl of the page</param>
        /// <param name="absolute">True to return an absolute URL</param>
        /// <returns>The friendly url of the specified page</returns>
        private static string GetFriendlyUrlString(PageReference pageReference, string url, bool absolute)
        {
            UrlBuilder friendlyUrl;

            if (absolute)
            {
                Uri uri = new Uri(SiteDefinition.Current.SiteUrl, url);
                friendlyUrl = new UrlBuilder(uri.AbsoluteUri.ToString());
            }
            else
            {
                friendlyUrl = new UrlBuilder(url);
            }

            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(friendlyUrl, pageReference, UTF8Encoding.UTF8);
            return friendlyUrl.ToString();
        }


        public static string GetFriendlyUrl(this string url)
        {
            return new Uri(SiteDefinition.Current.SiteUrl, url).ToString();
        }



        #endregion

        #region Get Children

        public static PageDataCollection GetAsPageData(this IList<PageReference> pageReferences)
        {
            var pdc = new PageDataCollection();
            {
                foreach (var pr in pageReferences)
                {
                    var pd = DataFactory.Instance.Get<PageData>(pr);
                    pdc.Add(pd);
                }
            }
            return pdc;
        }

        public static PageDataCollection GetAllChildren(this PageData rootPage)
        {
            return GetAllChildren(rootPage, false);
        }

        public static PageDataCollection GetAllChildren(this PageData rootPage, bool recursive)
        {
            return GetAllChildren(rootPage, recursive, true);
        }

        public static IEnumerable<T> GetChildren<T>(this PageData rootPage, bool bVisible, LoaderOptions selector = null)
        {
            if (selector == null) selector = new LoaderOptions() { LanguageLoaderOption.Specific(ContentLanguage.PreferredCulture) };

            var childPages = DataFactory.Instance.GetChildren(rootPage.PageLink, selector);
            var filteredList = childPages.Where(childItem => childItem.VisibleInMenu == bVisible && childItem.StopPublish > DateTime.Now);
            var typedPages = filteredList.Cast<T>().ToList();

            return typedPages;
        }

        public static PageDataCollection ToPageDataCollection(this IEnumerable<PageData> collection)
        {
            return new PageDataCollection(collection);
        }

        public static PageDataCollection GetDescendantsForRestaurants<T>(this PageData rootPage)
        {
            int? pageTypeID = rootPage.PageTypeID;
            if (pageTypeID.HasValue)
            {
                PropertyCriteria pageTypeCriteria = new PropertyCriteria();
                pageTypeCriteria.Condition = CompareCondition.Equal;
                pageTypeCriteria.Name = "PageTypeID";
                pageTypeCriteria.Type = PropertyDataType.PageType;
                pageTypeCriteria.Value = pageTypeID.Value.ToString();
                PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();
                criterias.Add(pageTypeCriteria);

                PageDataCollection descendants =
                    DataFactory.Instance.FindPagesWithCriteria(rootPage.PageLink, criterias);

                FilterSort SortFilter = new FilterSort((FilterSortOrder)rootPage["PageChildOrderRule"]);
                SortFilter.Sort(descendants);

                return descendants;
            }

            throw new Exception("Could not find PageTypeID for class " + typeof(T).ToString());
        }

        public static IEnumerable<T> GetDescendants<T>(this PageData rootPage)
        {
            var repository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var contentType = repository.Load(typeof(T));

            int? pageTypeID = contentType.ID; //rootPage.PageTypeID;
            if (pageTypeID.HasValue)
            {
                PropertyCriteria pageTypeCriteria = new PropertyCriteria();
                pageTypeCriteria.Condition = CompareCondition.Equal;
                pageTypeCriteria.Name = "PageTypeID";
                pageTypeCriteria.Type = PropertyDataType.PageType;
                pageTypeCriteria.Value = pageTypeID.Value.ToString();
                PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();
                criterias.Add(pageTypeCriteria);

                var descendants =
                    DataFactory.Instance.FindPagesWithCriteria(rootPage.PageLink, criterias, ContentLanguage.PreferredCulture.Name).SortByPageChildOrderRule(rootPage.PageLink);

                return FilterForVisitor.Filter(descendants).Cast<T>();
            }

            throw new Exception("Could not find PageTypeID for class " + typeof(T).ToString());
        }

        public static PageDataCollection GetAllChildren(this PageData rootPage, bool recursive, bool filterAccess)
        {
            if (rootPage != null)
            {
                PageDataCollection children;
                if (recursive)
                {
                    children = DataFactory.Instance.GetDescendents(rootPage.PageLink).GetAsPageData();
                }
                else
                {
                    children = rootPage.GetChildren<PageData>(true).ToPageDataCollection();
                }
                if (filterAccess)
                {
                    new FilterAccess().Filter(children);
                }
                return children;
            }

            return null;
        }

        /// <summary>
        /// Returns child pages excluding certain page types
        /// </summary>
        /// <param name="excludingPageTypes">A string array of excluded page types</param>
        /// <returns>PageDataCollection</returns>
        public static PageDataCollection GetChildrenIgnoringTypes(Type[] excludingPageTypes, PageDataCollection allChildren)
        {
            return GetChildrenIgnoringTypes(excludingPageTypes, allChildren, false);
        }

        /// <summary>
        /// Returns child pages excluding certain page types
        /// </summary>
        /// <param name="excludingPageTypes">A string array of excluded page types</param>
        /// <returns>PageDataCollection</returns>
        public static PageDataCollection GetChildrenIgnoringTypes(Type[] excludingPageTypes, PageDataCollection allChildren, bool showPagesInMenu)
        {
            var excludingPageTypesString = TypeExtensions.GetPageTypeNameList(excludingPageTypes);
            var childPages = from page in allChildren
                             where !excludingPageTypesString.Contains(page.PageTypeName)
                             select page;

            if (!showPagesInMenu)
            {
                childPages = childPages.Where(x => x.VisibleInMenu);
            }

            var pdcChildPages = new PageDataCollection(childPages.ToList());
            new FilterAccess().Filter(pdcChildPages);
            return pdcChildPages;
        }

        #endregion

        public static string DisplayName(this PageData pageData)
        {
            var repo = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var pageType = repo.Load(pageData.GetOriginalType());
            return pageType.DisplayName;
        }

        public static bool IsPublishedAndNotDeleted(this PageData pageData)
        {
            return !pageData.IsDeleted && pageData.IsPublished();
        }

        public static bool IsPublished(this PageData pageData)
        {
            return pageData.Status == VersionStatus.Published && pageData.StartPublish <= DateTime.Now &&
                     pageData.StopPublish > DateTime.Now;
        }


        #region Episerver Ext
        public static PageDataCollection GetPagesByPageType<T>(this PageReference page) where T : PageData
        {
            var pageTypeRepo = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var pageCriteria = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();

            var contentType = pageTypeRepo.Load<T>();
            var criteria = new PropertyCriteria();
            criteria.Condition = CompareCondition.Equal;
            criteria.Name = "PageTypeID";
            criteria.Required = true;
            criteria.Type = PropertyDataType.PageType;
            criteria.Value = contentType.ID.ToString();

            var criteriaCollection = new PropertyCriteriaCollection();
            criteriaCollection.Add(criteria);
            var langSelector = new LanguageSelectorFactory();

            return pageCriteria.FindAllPagesWithCriteria(page, criteriaCollection, CultureInfo.CurrentUICulture.Name, langSelector.AutoDetect(true));
        }
        #endregion
    }
}
