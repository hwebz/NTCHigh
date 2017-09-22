using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Associates.Pages;
using High.Net.Core;
using High.Net.Models.Associates.ViewModels;
using System;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.Associates
{
    public class HowWeCanHelpYouPageController : PageController<HowWeCanHelpYouPage>
    {
        public ActionResult Index(HowWeCanHelpYouPage currentPage)
        {
            var model = new HelpPageModel(currentPage)
            {

            };

            return View("~/Views/Associates/Pages/HowWeCanHelpYouPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HowWeCanHelpYouPage currentPage, HelpPageForm _HelpPageForm)
        {
            string propertyTypeList = String.Empty;
            string serviceTypeList = String.Empty;
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new HelpPageModel(currentPage)
            {

            };
            if (ModelState.IsValid)
            {
                var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
                var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
                var homePage = repo.Get<HomePage>(PageReference.StartPage);

                //send mail to high
                string businessMail = String.Empty;
                foreach (string _businessRecipientsEmail in currentPage.ToEmailID.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    businessMail += " " + _businessRecipientsEmail;
                }
                foreach (var item in _HelpPageForm.propertyTypeList.Where(x => x.IsChecked))
                {
                    propertyTypeList += item.Property + ", ";
                }
                foreach (var item in _HelpPageForm.serviceTypeList.Where(x => x.IsChecked))
                {
                    serviceTypeList += item.Service + ", ";
                }
                string businessEmailSubject = String.Empty;
                if (!String.IsNullOrEmpty(currentPage.Subject))
                {
                    businessEmailSubject = string.Format(Convert.ToString(currentPage.Subject), homePage.Name);
                }
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), _HelpPageForm.Email, _HelpPageForm.FirstName + " " + _HelpPageForm.LastName, _HelpPageForm.Company, _HelpPageForm.ZipCode, _HelpPageForm.Phone, propertyTypeList, serviceTypeList, _HelpPageForm.HelpText);
                _contentRepo.sendMail(businessEmailSubject
                    , mailBody, currentPage.ToEmailID, null, "", true, null);
                model._HelpPageForm.IsMailSendSuccessfully = true;
                string emailConfirmationSubject = string.Empty;
               
                //send mail to end user
                if (currentPage.EmailConfirmationSubject != null)
                {
                    emailConfirmationSubject = string.Format(Convert.ToString(currentPage.EmailConfirmationSubject), homePage.Name);
                }
                string EmailConfimationMailBody = string.Format(Convert.ToString(currentPage.EmailConfirmationMessage), homePage.Name, homePage.LancasterNo, homePage.HarrisburgNo, businessMail);
                _dataLocator.sendMail(emailConfirmationSubject
                    , EmailConfimationMailBody, _HelpPageForm.Email, null, "", true, null);

                //Thank you Message
                model._HelpPageForm.ThankYouMessageText = string.Format(Convert.ToString(currentPage.ThankYouMessage), homePage.Name, businessMail);
            }

            return View("~/Views/Associates/Pages/HowWeCanHelpYouPage/Index.cshtml", model);
        }

    }
}