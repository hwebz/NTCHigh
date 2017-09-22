using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Constants;
using High.Net.Models.Shared.ViewModels;
using High.Net.Models.Business.Solve360;
using System;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using High.Net.Models.Residential.Pages;
using High.Net.Web.Business.Helpers;

namespace High.Net.Web.Controllers.Residential
{
    [TemplateDescriptor(Name=SiteGroups.BR)]
    public class ContactUsPageController : PageController<ContactUsPage>
    {
        public ActionResult Index(ContactUsPage currentPage)
        {
            var model = new ContactUsPageModel(currentPage);
            return View("~/Views/Residential/Pages/ContactUsPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsPage currentPage, ContactUsForm ContactUsForm)
        {
            var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var homePage = repo.Get<HomePage>(PageReference.StartPage);

            var model = new ContactUsPageModel(currentPage)
            {

            };
            if (ModelState.IsValid)
            {
                string businessMail = MailHelpers.GetBusinessMail(currentPage.BusinessRecipientsEmail);
                
                // send mail to high
                var businessMailContentModel = MailHelpers.CreateEmailContentModel(currentPage, ContactUsForm, homePage, true);
                model.ContactUsForm.IsContactSubmitted = MailHelpers.SendEmailToAdmin(currentPage, ContactUsForm, homePage, businessMailContentModel);

                //send mail to end user
                var userMailContentModel = MailHelpers.CreateEmailContentModel(currentPage, ContactUsForm, homePage, false);
                var isSentSuccessfully = MailHelpers.SendEmailToUser(currentPage, ContactUsForm, homePage, userMailContentModel);              

                // Thank you message functionality

                model.ContactUsForm.ThankYouMessageText = String.Format(Convert.ToString(currentPage.ThankYouMessage), homePage.Name, businessMail);
            }

            return View("~/Views/Residential/Pages/ContactUsPage/Index.cshtml", model);
        }
    }

        
}