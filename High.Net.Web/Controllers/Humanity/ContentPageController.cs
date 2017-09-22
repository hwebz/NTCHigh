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
    public class ContentPageController : HumanityController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Humanity/Pages/ContentPage/Index.cshtml", model);
        }
    }
}