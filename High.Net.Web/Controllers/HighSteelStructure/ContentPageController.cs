using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class ContentPageController : HighSteelStructureController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighSteelStructure/Pages/ContentPage/Index.cshtml", model);
        }
    }
}