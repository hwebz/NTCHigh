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
    public class ProfileItemPageController : RealEstateGroupController<ProfileItemPage>
    {
        public ActionResult Index(ProfileItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/RealEstateGroup/Pages/ProfileItemPage/Index.cshtml", model);
        }
    }
}