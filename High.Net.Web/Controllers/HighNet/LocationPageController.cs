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

namespace High.Net.Web.Controllers.HighNet
{
    [TemplateDescriptor(Name = SiteGroups.HN)]
    public class LocationPageController : HighNetController<LocationPage>
    {
        public ActionResult Index(LocationPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighNet/Pages/LocationPage/Index.cshtml", model);
        }
    }
}