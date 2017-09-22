using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class EventListingPageController : PageController<EventListingPage>
    {
        public ActionResult Index(EventListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/EventListingPage/Index.cshtml", model);
        }
    }
}