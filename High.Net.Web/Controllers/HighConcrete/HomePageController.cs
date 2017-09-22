using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Core;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using System;
using System.Text.RegularExpressions;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class HomePageController : HighConcreteController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/HomePage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(HomePage currentPage, string Email)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
            var newLetterPage = contentLocator.GetAll<NewsLetterPage>(PageReference.StartPage).FirstOrDefault();
            if (IsValidEmail(Email))
            {
                string mailBody = string.Format(Convert.ToString(newLetterPage.MailBody), null, Email, null, null, null);
                dataLocator.sendMail(newLetterPage.Subject
                    , mailBody, newLetterPage.ToEmailID, null, "", true, null);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        private static bool IsValidEmail(string emailAddress)
        {
            const string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase).IsMatch(emailAddress);
        }
    }
}