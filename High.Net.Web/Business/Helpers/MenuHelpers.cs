using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using High.Net.Core;
using High.Net.Web.ViewModels.Shared;
using System.Collections.Generic;
using System.Linq;
using System;

namespace High.Net.Web.Business.Helpers
{
    public static class MenuHelpers
    {
        private static readonly IContentRepository ContentRepository;

        static MenuHelpers()
        {
            ContentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
        }

        public static List<MenuItemViewModel> GetMenu(BasePageData currentPage, bool includeChildren = false, bool includeRoot = true)
        {
            var homePage = currentPage.GetHomePage<BasePageData>();
            if (homePage == null) return new List<MenuItemViewModel>();

            var urlHelper = new System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);

            var menuItems = ContentRepository.GetChildren<BasePageData>(homePage.ContentLink)
             .FilterForDisplay(true, true)
             .Select(page => CreateMenuItem(urlHelper, page, currentPage, includeChildren))
             .ToList();

            if (includeRoot)
            {
                menuItems.Insert(0, CreateMenuItem(urlHelper, homePage, currentPage, false, "Home"));
            }
            return menuItems;
        }

        private static MenuItemViewModel CreateMenuItem(System.Web.Mvc.UrlHelper urlHelper, BasePageData page, BasePageData currentPage, bool includeChildren = false, string defaultText = "")
        {
            if (page == null) return null;
            var menuItem = new MenuItemViewModel
            {
                PageRef = page.ContentLink,
                MenuText = string.IsNullOrEmpty(defaultText) ? page.Name : defaultText,
                Url = urlHelper.ContentUrl(page.ContentLink)
            };            
            if (includeChildren)
            {
                menuItem.Children = ContentRepository.GetChildren<BasePageData>(page.ContentLink)
                                 .FilterForDisplay(true, true)
                                 .Select(child => CreateMenuItem(urlHelper, child, currentPage))
                                 .ToList();
            }
            menuItem.IsActive = IsActive(menuItem.Children, page, currentPage);
            return menuItem;
        }

        private static bool IsActive(List<MenuItemViewModel> children, BasePageData page, BasePageData currentPage)
        {
            if (page == null || currentPage == null) return false;
            if (page.Equals(currentPage)) return true;
            if(children!=null && children.Any())
            {
                return children.FirstOrDefault(x =>currentPage.ContentLink.Equals(x.PageRef)) != null;
            }
            return false;
        }
    }
}