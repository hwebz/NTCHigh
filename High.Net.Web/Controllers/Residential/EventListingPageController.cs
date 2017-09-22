using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Residential.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Residential
{
    public class EventListingPageController : ResidentialController<EventListingPage>
    {
        public ActionResult Index(EventListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Residential/Pages/EventListingPage/Index.cshtml", model);
        }
    }
}