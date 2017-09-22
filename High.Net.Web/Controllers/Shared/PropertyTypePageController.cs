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
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;

namespace High.Net.Web.Controllers.Commercial
{
    public class PropertyTypePageController : BasePageController<PropertyTypePage>
    {
        public ActionResult Index(PropertyTypePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Commercial/Pages/PropertyTypePage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Associates
{
    [TemplateDescriptor(Name = SiteGroups.HA)]
    public class PropertyTypePageController : BasePageController<PropertyTypePage>
    {
        public ActionResult Index(PropertyTypePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            string PropertySearchUrl = (Url.ContentUrl(currentPage.ParentLink) + "?RootPage=" + PageReference.RootPage + "&PropertyType=" + currentPage.Name);

            return Redirect(PropertySearchUrl);
        }
    }
}