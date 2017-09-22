using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighHotels.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighHotels
{
    public class PortfolioPageController : PageController<PortfolioPage>
    {
        public ActionResult Index(PortfolioPage currentPage, string q)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighHotels/Pages/PortfolioPage/Index.cshtml", model);
        }
    }
}