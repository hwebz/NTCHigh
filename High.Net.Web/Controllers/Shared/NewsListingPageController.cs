using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Humanity.Pages;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Constants;

namespace High.Net.Web.Controllers.Humanity
{
    [TemplateDescriptor(Name = SiteGroups.EOH)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Humanity/Pages/NewsListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Commercial
{
    [TemplateDescriptor(Name = SiteGroups.B2B)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Commercial/Pages/NewsListingPage/Index.cshtml", model);
        }
    }

}

namespace High.Net.Web.Controllers.StructureCareUs
{
    [TemplateDescriptor(Name = SiteGroups.SCU)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/StructureCareUs/Pages/NewsListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Industries
{
    [TemplateDescriptor(Name = SiteGroups.HII)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Industries/Pages/NewsListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.RealEstateGroup
{
    [TemplateDescriptor(Name = SiteGroups.REG)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/RealEstateGroup/Pages/NewsListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Rollover
{
    [TemplateDescriptor(Name = SiteGroups.RO, TagString = SiteGroups.RO)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Rollover/Pages/NewsListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.HighHotels
{
    [TemplateDescriptor(Name = SiteGroups.HH)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighHotels/Pages/NewsListingPage/Index.cshtml", model);
        }
    }

}

namespace High.Net.Web.Controllers.GreenfieldArchitects
{
    [TemplateDescriptor(Name = SiteGroups.GAL)]
    public class NewsListingPageController : BasePageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/GreenfieldArchitects/Pages/NewsListingPage/Index.cshtml", model);
        }
    }

}