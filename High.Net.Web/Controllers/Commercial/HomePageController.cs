using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.Commercial.Pages;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;


namespace High.Net.Web.Controllers.Commercial
{
    public class HomePageController : CommercialController<HomePage>
    {
        private Injected<DataLocator> DataLocator { get; set; }
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Commercial/Pages/HomePage/Index.cshtml", model);
        }
    }
}