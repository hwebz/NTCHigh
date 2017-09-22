using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighNet.Pages;
using High.Net.Models.HighNet.ViewModels;
using EPiServer.ServiceLocation;
using System;
using High.Net.Web.Business;
using High.Net.Models.Shared.ViewModels;
using High.Net.Models.Business.Solve360;

namespace High.Net.Web.Controllers.HighNet
{
    public class SustainabilityDownloadPageController : PageController<SustainabilityDownloadPage>
    {
        public ActionResult Index(SustainabilityDownloadPage currentPage)
        {
            var model = new SustainabilityDownloadModel(currentPage);
            return View("~/Views/HighNet/Pages/SustainabilityDownloadPage/Index.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SustainabilityDownloadPage currentPage, SustainabilityDownloadForm sustainabilityDownloadForm)
        {
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var homePage = contentLoader.Get<HomePage>(PageReference.StartPage);
            string signupStatus = sustainabilityDownloadForm.SignUpForMail ? currentPage.Solve360SignupMailMessage : currentPage.Solve360UnsubscribeMailMessage;
            var model = new SustainabilityDownloadModel(currentPage) { SustainabilityDownloadForm = sustainabilityDownloadForm };
            if (ModelState.IsValid)
            {
                ContactUsForm contactForm = new ContactUsForm();
                contactForm.Name = sustainabilityDownloadForm.FirstName + " " + sustainabilityDownloadForm.LastName;
                contactForm.Email = sustainabilityDownloadForm.EmailAddress;
                contactForm.Solve360SelectedCategory = homePage.Solve360CategoryTag;
                var contactId = Solve360Helper.SearchContact(contactForm.Email.Trim());
                var contactStatus = contactId != 0 ? Solve360Helper.UpdateContacts(contactId, String.Format("<request><firstname>{0}</firstname><businessemail>{1}</businessemail><categories><add><category>{2}</category></add></categories></request>", contactForm.Name, contactForm.Email, contactForm.Solve360SelectedCategory), signupStatus + contactForm.Message) :
                    Solve360Helper.AddContacts(String.Format("<request><firstname>{0}</firstname><businessemail>{1}</businessemail><categories><add><category>{2}</category></add></categories></request>", contactForm.Name, contactForm.Email, contactForm.Solve360SelectedCategory), signupStatus + contactForm.Message);
                sustainabilityDownloadForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighNet/Pages/SustainabilityDownloadPage/Index.cshtml", model);
        }

    }
}