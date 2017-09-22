using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.Rollover.Pages;

namespace High.Net.Web.Controllers.Rollover
{
    public class FindAnApartmentPageController : RolloverController<FindAnApartmentPage>
    {
        public ActionResult Index(FindAnApartmentPage currentPage, string q)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            ViewBag.Location = q;
            return View("~/Views/Rollover/Pages/FindAnApartmentPage/Index.cshtml", model);
       
        }
    }
}