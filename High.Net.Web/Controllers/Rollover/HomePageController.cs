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
    public class HomePageController : RolloverController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Rollover/Pages/HomePage/Index.cshtml", model);
        }
    }
}