using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.RealEstateGroup.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.RealEstateGroup
{
    public class ProfileListingPageController : RealEstateGroupController<ProfileListingPage>
    {
        public ActionResult Index(ProfileListingPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/RealEstateGroup/Pages/ProfileListingPage/Index.cshtml", model);
        }
    }
}