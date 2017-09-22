using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.SteelServiceCentre.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.SteelServiceCentre
{
    public class BrokerListPageController : SteelServiceCentreController<BrokerListPage>
    {
        public ActionResult Index(BrokerListPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/SteelServiceCentre/Pages/BrokerListPage/Index.cshtml",model);
        }
    }
}