using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Constants;

namespace High.Net.Web.Controllers.Associates
{
    [TemplateDescriptor(Name = SiteGroups.HA)]
    public class LocationPageController : AssociatesController<LocationPage>
    {
        public ActionResult Index(LocationPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/LocationPage/Index.cshtml", model);
        }
    }
}