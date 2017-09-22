using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.SteelServiceCentre.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.SteelServiceCentre
{
    public class ContentPageController : SteelServiceCentreController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/SteelServiceCentre/Pages/ContentPage/Index.cshtml", model);
        }
    }
}