using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Industries.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Industries
{
    public class CommonItemPageController : IndustriesController<CommonItemPage>
    {
        public ActionResult Index(CommonItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Industries/Pages/CommonItemPage/Index.cshtml", model);
        }
    }
}