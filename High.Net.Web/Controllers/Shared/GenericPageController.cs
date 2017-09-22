using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Shared
{
    public class GenericPageController : PageController<GenericPage>
    {
        public ActionResult Index(GenericPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Shared/Pages/GenericPage/Index.cshtml",model);
        }
    }
}