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
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Humanity/Pages/NewsItemPage/Index.cshtml", model);
        }
    }


}

namespace High.Net.Web.Controllers.Commercial
{
    [TemplateDescriptor(Name = SiteGroups.B2B)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Commercial/Pages/NewsItemPage/Index.cshtml", model);
        }
    }


}

namespace High.Net.Web.Controllers.StructureCareUs
{
    [TemplateDescriptor(Name = SiteGroups.SCU)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/StructureCareUs/Pages/NewsItemPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Industries
{
    [TemplateDescriptor(Name = SiteGroups.HII)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Industries/Pages/NewsItemPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.RealEstateGroup
{
    [TemplateDescriptor(Name = SiteGroups.REG)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/RealEstateGroup/Pages/NewsItemPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Rollover
{
    [TemplateDescriptor(Name = SiteGroups.RO, TagString = SiteGroups.RO)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Rollover/Pages/NewsItemPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.GreenfieldArchitects
{
    [TemplateDescriptor(Name = SiteGroups.GAL)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/GreenfieldArchitects/Pages/NewsItemPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.HighHotels
{
    [TemplateDescriptor(Name = SiteGroups.HH)]
    public class NewsItemPageController : BasePageController<NewsItemPage>
    {
        public ActionResult Index(NewsItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighHotels/Pages/NewsItemPage/Index.cshtml", model);
        }
    }
}