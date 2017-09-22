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
    public class PortfolioListPageController : PageController<PortfolioListPage>
    {
        public ActionResult Index(PortfolioListPage currentPage, string query)
        {
            var model = PageViewModel.Create(currentPage);
            ViewBag.FilterBy = query;
            return View("~/Views/HighHotels/Pages/PortfolioListPage/Index.cshtml", model);
        }
    }
}