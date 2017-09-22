using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.RealEstateGroup
{
    public class ProjectPortfolioListingPageController : PageController<ProjectPortfolioListingPage>
    {
        public ActionResult Index(ProjectPortfolioListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/RealEstateGroup/Pages/ProjectPortfolioListingPage/Index.cshtml", model);
        }
    }
}