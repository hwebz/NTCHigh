using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Web.Controllers.HighConcrete
{
    [TemplateDescriptor(Name = SiteGroups.HC)]
    public class NewsListingPageController : PageController<NewsListingPage>
    {
        public ActionResult Index(NewsListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/NewsListingPage/Index.cshtml", model);
        }
    }
}