using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Web.Controllers.Commercial
{
    [TemplateDescriptor(Name = SiteGroups.B2B)]
    public class PropertyPageController : BasePageController<PropertyPage>
    {
        public ActionResult Index(PropertyPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Commercial/Pages/PropertyPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Associates
{
    [TemplateDescriptor(Name = SiteGroups.HA)]
    public class PropertyPageController : BasePageController<PropertyPage>
    {
        public ActionResult Index(PropertyPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/PropertyPage/Index.cshtml", model);
        }
    }
}