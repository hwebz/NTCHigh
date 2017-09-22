using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighAppraisal.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighAppraisal
{
    public class VideoListingPageController : HighAppraisalController<VideoListingPage>
    {
        public ActionResult Index(VideoListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighAppraisal/Pages/VideoListingPage/Index.cshtml",model);
        }
    }
}