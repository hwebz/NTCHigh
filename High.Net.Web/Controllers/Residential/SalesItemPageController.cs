using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Residential.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Residential
{
    public class SalesItemPageController : ResidentialController<SalesItemPage>
    {
        public ActionResult Index(SalesItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Residential/Pages/SalesItemPage/Index.cshtml", model);
        }
    }
}