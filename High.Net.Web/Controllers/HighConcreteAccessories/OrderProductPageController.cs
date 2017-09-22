using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcreteAccessories.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighConcreteAccessories
{
    public class OrderProductPageController : HighConcreteAccessoriesController<OrderProductPage>
    {
        public ActionResult Index(OrderProductPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcreteAccessories/Pages/OrderProductPage/Index.cshtml", model);
        }
    }
}