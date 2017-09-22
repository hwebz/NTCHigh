using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighHotels.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighHotels
{
    public class VideoItemPageController : HighHotelsController<VideoItemPage>
    {
        public ActionResult Index(VideoItemPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighHotels/Pages/VideoItemPage/Index.cshtml", model);

        }
    }
}