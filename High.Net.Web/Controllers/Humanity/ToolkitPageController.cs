using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Humanity.Pages;
using High.Net.Core;
using High.Net.Models.Humanity.ViewModels;

namespace High.Net.Web.Controllers.Humanity
{
    public class ToolkitPageController : HumanityController<ToolkitPage>
    {
        public ActionResult Index(ToolkitPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            ViewBag.LoginStatus = false;
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Humanity/Pages/ToolkitPage/Index.cshtml", model);

        }

       
        public ActionResult Login(ToolkitPage currentPage, UserModel _user)
        {
            if (ModelState.IsValid)
            {
                if (currentPage.Username == _user.UserName && currentPage.Password == _user.Password)
                {
                    ViewBag.LoginStatus = true;
                }
                else {
                    ViewBag.LoginStatus = false;
                    ViewBag.ValidationMessage = "Invalid username or password!";
                }
            }
            else
            {
                ViewBag.LoginStatus = false;
            }
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Humanity/Pages/ToolkitPage/Index.cshtml", model);
        }

    }
}