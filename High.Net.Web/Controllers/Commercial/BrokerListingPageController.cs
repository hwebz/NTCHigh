using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Commercial.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Commercial
{
    public class BrokerListingPageController : CommercialController<BrokerListingPage>
    {
        public ActionResult Index(BrokerListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Commercial/Pages/BrokerListingPage/Index.cshtml", model);
        }
    }
}