using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class EventItemPageController : PageController<EventItemPage>
    {
        public ActionResult Index(EventItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/EventItemPage/Index.cshtml", model);
        }
    }
}