using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using log4net;

namespace High.Net.Core
{
    public class ContentLocator
    {
        private readonly IContentLoader _contentLoader;
        private readonly IContentProviderManager _providerManager;
        private readonly IPageCriteriaQueryService _pageCriteriaQueryService;
        private static readonly ILog log = LogManager.GetLogger(typeof(ContentLocator));
        private static readonly ILog logPerf = LogManager.GetLogger("Core.ContentLocator.Performance");

        public ContentLocator(IContentLoader contentLoader, IContentProviderManager providerManager, IPageCriteriaQueryService pageCriteriaQueryService)
        {
            _contentLoader = contentLoader;
            _providerManager = providerManager;
            _pageCriteriaQueryService = pageCriteriaQueryService;
        }

        public virtual IEnumerable<T> GetAll<T>(ContentReference rootLink)
            where T : PageData
        {
            var children = _contentLoader.GetChildren<PageData>(rootLink);
            foreach (var child in children)
            {
                var childOfRequestedTyped = child as T;
                if (childOfRequestedTyped != null && !childOfRequestedTyped.IsDeleted)
                {
                    yield return childOfRequestedTyped;
                }
                foreach (var descendant in GetAll<T>(child.ContentLink))
                {
                    if (!descendant.IsDeleted)
                    {
                        yield return descendant;
                    }
                }
            }
        }

        /// <summary>
        /// Returns pages of a specific page type
        /// </summary>
        /// <param name="pageLink"></param>
        /// <param name="recursive"></param>
        /// <param name="pageTypeId">ID of the page type to filter by</param>
        /// <returns></returns>
        public IEnumerable<PageData> FindPagesByPageType(PageReference pageLink, bool recursive, int pageTypeId)
        {
            DateTime perfStart = DateTime.Now;

            try
            {
                if (ContentReference.IsNullOrEmpty(pageLink))
                {
                    throw new ArgumentNullException("pageLink", "No page link specified, unable to find pages");
                }

                var pages = recursive
                            ? FindPagesByPageTypeRecursively(pageLink, pageTypeId)
                            : _contentLoader.GetChildren<PageData>(pageLink);
                logPerf.InfoFormat("PERFORMANCE '{0}' was {1} ms", "FindPagesByPageType", (DateTime.Now - perfStart).TotalMilliseconds);
                return pages;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("FindPagesByPageTypeRecursively: EXCEPTION  message='{0}' stack  {1}",
                  ex.Message,
                  ex.StackTrace);
                return null;
            }
        }

        // Type specified through page type ID
        private IEnumerable<PageData> FindPagesByPageTypeRecursively(PageReference pageLink, int pageTypeId)
        {
            DateTime perfStart = DateTime.Now;
            try
            {
                var criteria = new PropertyCriteriaCollection
                               {
                                    new PropertyCriteria
                                    {
                                        Name = "PageTypeID",
                                        Type = PropertyDataType.PageType,
                                        Condition = CompareCondition.Equal,
                                        Value = pageTypeId.ToString(CultureInfo.InvariantCulture)
                                    }
                               };

                // Include content providers serving content beneath the page link specified for the search
                if (_providerManager.ProviderMap.CustomProvidersExist)
                {
                    var contentProvider = _providerManager.ProviderMap.GetProvider(pageLink);

                    if (contentProvider.HasCapability(ContentProviderCapabilities.Search))
                    {
                        criteria.Add(new PropertyCriteria
                        {
                            Name = "EPI:MultipleSearch",
                            Value = contentProvider.ProviderKey
                        });
                    }
                }
                var pages = _pageCriteriaQueryService.FindPagesWithCriteria(pageLink, criteria);
                logPerf.InfoFormat("PERFORMANCE '{0}' was {1} ms", "FindPagesByPageTypeRecursively", (DateTime.Now - perfStart).TotalMilliseconds);
                return pages;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("FindPagesByPageTypeRecursively: EXCEPTION  message='{0}' stack  {1}",
                    ex.Message,
                    ex.StackTrace);
                return null;
            }
        }

        public Category GetCategories(string parent)
        {
            try
            {
                if (!string.IsNullOrEmpty(parent))
                {
                    var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
                    return categoryRepository.Get(parent);
                }
                return new Category();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("GetCategories: EXCEPTION  message='{0}' stack  {1}",
                ex.Message,
                ex.StackTrace);
                throw;
            }

        }
    }
}
