using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Residential.Pages;
using High.Net.Core;
using System.Text.RegularExpressions;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.Residential
{
    public class HomePageController : ResidentialController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Residential/Pages/HomePage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(HomePage currentPage, string email)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            var homePage = repo.Get<HomePage>(PageReference.StartPage);
            if (IsValidEmail(email))
            {
                string mailBody = string.Format(System.Convert.ToString(currentPage.SharePropertyMailBody));
                dataLocator.sendMail(currentPage.SharePropertySubject, mailBody, email, null, null, true, null,currentPage.ScheduleTourPropertyEmail,homePage.Name);
                return Json(new { success = true, message = currentPage.SharePropertyThankYouMessage });
            }
            return Json(new { success = false, message = "Please enter valid e-mail address." });
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