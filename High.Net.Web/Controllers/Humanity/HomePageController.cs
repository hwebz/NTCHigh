using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.Humanity.Pages;

namespace High.Net.Web.Controllers.Humanity
{
    public class HomePageController : HumanityController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Humanity/Pages/HomePage/Index.cshtml", model);
        }
    }
}