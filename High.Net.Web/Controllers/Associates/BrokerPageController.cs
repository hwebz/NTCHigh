using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Associates.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Associates
{
    public class BrokerPageController : AssociatesController<BrokerPage>
    {
        public ActionResult Index(BrokerPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/BrokerPage/Index.cshtml", model);
        }
    }
}