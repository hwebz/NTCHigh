using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.ViewModels;
using System;
using High.Net.Models.Business.Solve360;
using High.Net.Models.Constants;
using EPiServer.ServiceLocation;
using High.Net.Models.Commercial.Pages;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.Commercial
{
    [TemplateDescriptor(Name = SiteGroups.B2B)]
    public class ContactUsPageController : PageController<ContactUsPage>
    {
        public ActionResult Index(ContactUsPage currentPage)
        {
            var model = new ContactUsPageModel(currentPage)
            {

            };
            return View("~/Views/Commercial/Pages/ContactUsPage/Index.cshtml", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsPage currentPage, ContactUsForm ContactUsForm)
        {
            var model = new ContactUsPageModel(currentPage)
            {

            };
            if (ModelState.IsValid)
            {

                var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
                var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
                var homePage = repo.Get<HomePage>(PageReference.StartPage);

                int companyID = 0;
                if (!String.IsNullOrWhiteSpace(ContactUsForm.Company))
                {
                    companyID = Solve360Helper.SearchCompany(ContactUsForm.Company);

                }
                // Solve 360 functionality
                var contactId = Solve360Helper.SearchContact(ContactUsForm.Email.Trim());
                var contactStatus = contactId != 0 ? Solve360Helper.UpdateContacts(contactId, String.Format("<request><firstname>{0}</firstname><businessemail>{1}</businessemail><jobtitle>{2}</jobtitle><relateditems><add><relatedto><id>{3}</id></relatedto></add></relateditems><businessaddress>{4}</businessaddress><businessphonedirect>{5}</businessphonedirect><categories><add><category>{6}</category></add></categories></request>", ContactUsForm.Name, ContactUsForm.Email, ContactUsForm.Title, companyID, ContactUsForm.Address, ContactUsForm.PhoneNo, ContactUsForm.Solve360SelectedCategory), ContactUsForm.Message) :
                    Solve360Helper.AddContacts(String.Format("<request><firstname>{0}</firstname><businessemail>{1}</businessemail><jobtitle>{2}</jobtitle><relateditems><add><relatedto><id>{3}</id></relatedto></add></relateditems><businessaddress>{4}</businessaddress><businessphonedirect>{5}</businessphonedirect><categories><add><category>{6}</category></add></categories></request>", ContactUsForm.Name, ContactUsForm.Email, ContactUsForm.Title, companyID, ContactUsForm.Address, ContactUsForm.PhoneNo, ContactUsForm.Solve360SelectedCategory), ContactUsForm.Message);
                model.ContactUsForm.IsContactSubmitted = contactStatus;

                //send mail to end user
                String EmailConfirmationSubject = String.Empty;
                if (!String.IsNullOrEmpty(currentPage.EmailConfirmationSubject))
                {
                    EmailConfirmationSubject = string.Format(Convert.ToString(currentPage.EmailConfirmationSubject), homePage.Name);
                }
                string EmailConfimationMailBody = string.Format(Convert.ToString(currentPage.EmailConfirmationMessage), homePage.Name, homePage.ContactNumber, homePage.EmailId);
                _dataLocator.sendMail(EmailConfirmationSubject
                    , EmailConfimationMailBody, ContactUsForm.Email, null, "", true, null, currentPage.BusinessRecipientsEmail, homePage.Name);

                // Thank you message functionality
                model.ContactUsForm.ThankYouMessageText = String.Format(Convert.ToString(currentPage.ThankYouMessage), homePage.Name, homePage.EmailId);
            }
            return View("~/Views/Commercial/Pages/ContactUsPage/Index.cshtml", model);
        }

    }
}