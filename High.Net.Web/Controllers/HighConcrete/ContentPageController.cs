using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class ContentPageController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/ContentPage/Index.cshtml", model);
        }
    }
}