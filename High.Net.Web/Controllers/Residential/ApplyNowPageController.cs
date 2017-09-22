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
    public class ApplyNowPageController : PageController<ApplyNowPage>
    {
        public ActionResult Index(ApplyNowPage currentPage)
        {
            var model = PageViewModel.Create<ApplyNowPage>(currentPage);
            return View("~/Views/Residential/Pages/ApplyNowPage/Index.cshtml", model);
        }
    }
}