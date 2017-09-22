using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Associates.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Associates
{
    public class SignUpPageController : PageController<SignUpPage>
    {
        public ActionResult Index(SignUpPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/SignUpPage/Index.cshtml",model);
        }

        [HttpPost]
        public ActionResult Index(SignUpPage currentPage, string Email)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["HighAssociatesSignUpUrl"];
            string FrameUrl = string.Format(value, Email);
            ViewBag.FrameUrl = FrameUrl;
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/SignUpPage/Index.cshtml",model);
        }
    }
}