using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.Industries.Pages;

namespace High.Net.Web.Controllers.Industries
{
    public class ContentPageController : IndustriesController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Industries/Pages/ContentPage/Index.cshtml", model);
        }
    }
}