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
    public class VideoListingPageController : PageController<VideoListingPage>
    {
        public ActionResult Index(VideoListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/VideoListingPage/Index.cshtml", model);
        }
    }
}