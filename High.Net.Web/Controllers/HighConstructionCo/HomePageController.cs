using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConstructionCo.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighConstructionCo
{
    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConstructionCo/Pages/HomePage/Index.cshtml", model);
        }
    }
}