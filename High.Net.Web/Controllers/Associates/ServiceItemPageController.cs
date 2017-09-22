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
    public class BrokerListPageController : PageController<BrokerListPage>
    {
        public ActionResult Index(BrokerListPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/BrokerListPage/Index.cshtml", model);
        }
    }
}