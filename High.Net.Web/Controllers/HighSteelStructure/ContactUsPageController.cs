﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Constants;
using High.Net.Models.Shared.ViewModels;
using System;
using High.Net.Models.Business.Solve360;
using EPiServer.ServiceLocation;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    [TemplateDescriptor(Name = SiteGroups.HSS)]
    public class ContactUsPageController : PageController<ContactUsPage>
    {
        public ActionResult Index(ContactUsPage currentPage)
        {
            var model = new ContactUsPageModel(currentPage)
            {

            };
            return View("~/Views/HighSteelStructure/Pages/ContactUsPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsPage currentPage, ContactUsForm ContactUsForm)
        {
            var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var homePage = repo.Get<HomePage>(PageReference.StartPage);

            var model = new ContactUsPageModel(currentPage)
            {

            };
            if (ModelState.IsValid)
            {
                var contactId = Solve360Helper.SearchContact(ContactUsForm.Email.Trim());
                var contactStatus = contactId != 0 ? Solve360Helper.UpdateContacts(contactId, String.Format("<request><firstname>{0}</firstname><businessemail>{1}</businessemail><jobtitle>{2}</jobtitle><businessaddress>{3}</businessaddress><businessphonedirect>{4}</businessphonedirect><categories><add><category>{5}</category></add></categories></request>", ContactUsForm.Name, ContactUsForm.Email, ContactUsForm.Title, ContactUsForm.Address, ContactUsForm.PhoneNo, ContactUsForm.Solve360SelectedCategory), ContactUsForm.Message) :
                Solve360Helper.AddContacts(String.Format("<request><firstname>{0}</firstname><businessemail>{1}</businessemail><jobtitle>{2}</jobtitle><businessaddress>{3}</businessaddress><businessphonedirect>{4}</businessphonedirect><categories><add><category>{5}</category></add></categories></request>", ContactUsForm.Name, ContactUsForm.Email, ContactUsForm.Title, ContactUsForm.Address, ContactUsForm.PhoneNo, ContactUsForm.Solve360SelectedCategory), ContactUsForm.Message);

                model.ContactUsForm.IsContactSubmitted = contactStatus;

                //send mail to end user
                String EmailConfirmationSubject = String.Empty;
                if (!String.IsNullOrEmpty(currentPage.EmailConfirmationSubject))
                {
                    EmailConfirmationSubject = string.Format(Convert.ToString(currentPage.EmailConfirmationSubject), homePage.Name);
                }
                string EmailConfimationMailBody = string.Format(Convert.ToString(currentPage.EmailConfirmationMessage), homePage.Name, homePage.Contact, homePage.EmailAddress);
                _dataLocator.sendMail(EmailConfirmationSubject
                    , EmailConfimationMailBody, ContactUsForm.Email, null, "", true, null, currentPage.BusinessRecipientsEmail, homePage.Name);

                //Thank you Message
                model.ContactUsForm.ThankYouMessageText = string.Format(Convert.ToString(currentPage.ThankYouMessage), homePage.Name, homePage.EmailAddress);
            }

            return View("~/Views/HighSteelStructure/Pages/ContactUsPage/Index.cshtml", model);
        }
    }
}