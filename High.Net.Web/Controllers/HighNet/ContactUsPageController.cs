using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using High.Net.Models.Business.Solve360;
using High.Net.Models.Constants;
using High.Net.Models.HighNet.Pages;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.ViewModels;
using High.Net.Web.Business;
using High.Net.Web.Business.Helpers;
using System;
using System.Web.Mvc;
using High.Net.Web.Business.Attributes;

namespace High.Net.Web.Controllers.HighNet
{
    [TemplateDescriptor(Name = SiteGroups.HN)]
    public class ContactUsPageController : PageController<ContactUsPage>
    {
        public ActionResult Index(ContactUsPage currentPage)
        {
            var model = new ContactUsPageModel(currentPage);
            return View("~/Views/HighNet/Pages/ContactUsPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateRecaptcha]
        public ActionResult Index(ContactUsPage currentPage, ContactUsForm contactUsForm)
        {
            var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var homePage = repo.Get<HomePage>(PageReference.StartPage);

            var model = new ContactUsPageModel(currentPage);
            ViewBag.RecaptchaMessage = null;
            if (ModelState.IsValid)
            {
                //model.ContactUsForm.IsContactSubmitted = true;
                int companyID = 0;
                if (!String.IsNullOrWhiteSpace(contactUsForm.Company))
                {
                    companyID = Solve360Helper.SearchCompany(contactUsForm.Company);
                }
                var contactId = Solve360Helper.SearchContact(contactUsForm.Email.Trim());
                var contactStatus = contactId != 0
                    ? Solve360Helper.UpdateContacts(contactId,
                        String.Format(
                            "<request><firstname>{0}</firstname><businessemail>{1}</businessemail><jobtitle>{2}</jobtitle><relateditems><add><relatedto><id>{3}</id></relatedto></add></relateditems><businessaddress>{4}</businessaddress><businessphonedirect>{5}</businessphonedirect><categories><add><category>{6}</category></add></categories></request>",
                            contactUsForm.Name, contactUsForm.Email, contactUsForm.Title, companyID,
                            contactUsForm.Address, contactUsForm.PhoneNo, contactUsForm.Solve360SelectedCategory),
                        contactUsForm.Message)
                    : Solve360Helper.AddContacts(
                        String.Format(
                            "<request><firstname>{0}</firstname><businessemail>{1}</businessemail><jobtitle>{2}</jobtitle><relateditems><add><relatedto><id>{3}</id></relatedto></add></relateditems><businessaddress>{4}</businessaddress><businessphonedirect>{5}</businessphonedirect><categories><add><category>{6}</category></add></categories></request>",
                            contactUsForm.Name, contactUsForm.Email, contactUsForm.Title, companyID,
                            contactUsForm.Address, contactUsForm.PhoneNo, contactUsForm.Solve360SelectedCategory),
                        contactUsForm.Message);

                //model.ContactUsForm.IsContactSubmitted = contactStatus;

                //send mail to end user
                //String EmailConfirmationSubject = String.Empty;
                //if (!String.IsNullOrEmpty(currentPage.EmailConfirmationSubject))
                //{
                //    EmailConfirmationSubject = string.Format(Convert.ToString(currentPage.EmailConfirmationSubject), homePage.Name);
                //}
                //string EmailConfimationMailBody = string.Format(Convert.ToString(currentPage.EmailConfirmationMessage), homePage.Name, homePage.Contact, homePage.EmailID);
                //var isSentSuccessfully = _dataLocator.sendMail(EmailConfirmationSubject, EmailConfimationMailBody, contactUsForm.Email, null, "", true, null, currentPage.BusinessRecipientsEmail, homePage.Name);

                string businessMail = MailHelpers.GetBusinessMail(currentPage.BusinessRecipientsEmail, false);

                // send mail to high
                var businessMailContentModel = MailHelpers.CreateEmailContentModel(currentPage, contactUsForm, homePage,
                    true);
                model.ContactUsForm.IsContactSubmitted = MailHelpers.SendEmailToAdmin(currentPage, contactUsForm,
                    homePage, businessMailContentModel);

                //send mail to end user
                var userMailContentModel = MailHelpers.CreateEmailContentModel(currentPage, contactUsForm, homePage,
                    false);
                var isSentSuccessfully = MailHelpers.SendEmailToUser(currentPage, contactUsForm, homePage,
                    userMailContentModel);

                //Thank you Message
                model.ContactUsForm.ThankYouMessageText = string.Format(Convert.ToString(currentPage.ThankYouMessage),
                    homePage.Name, homePage.EmailID);

                model.ContactUsForm.IsSentSuccessfully = isSentSuccessfully;
                model.ContactUsForm.ErrorMessage = GetSendingMailErrorMessage();
            }
            else if(ModelState.ContainsKey("Recaptcha") && ModelState["Recaptcha"].Errors.Count > 0)
            {
                ViewBag.RecaptchaMessage = "Please verify that you are not a robot.";
            }

            return View("~/Views/HighNet/Pages/ContactUsPage/Index.cshtml", model);
        }

        private string GetSendingMailErrorMessage()
        {
            return "We're sorry, but your email could not be delivered due to a technical issue. Please try again later, or call us at 717.293.4444.";
        }
    }
}