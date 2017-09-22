using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighNet.Pages;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighNet
{
    [TemplateDescriptor(Name = SiteGroups.HN)]
    public class ReusableComponentPageController : PageController<ReusableComponentPage>
    {
        public ActionResult Index(ReusableComponentPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighNet/Pages/ReusableComponentPage/Index.cshtml", model);
        }
    }
}