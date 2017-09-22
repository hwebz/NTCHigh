using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighNet.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighNet
{
    public class MeasureItemPageController : PageController<MeasureItemPage>
    {
        public ActionResult Index(MeasureItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighNet/Pages/MeasureItemPage/Index.cshtml", model);
        }
    }
}