using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class ProjectListingPageController : PageController<ProjectListingPage>
    {
        public ActionResult Index(ProjectListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/ProjectListingPage/Index.cshtml", model);
        }
    }
}