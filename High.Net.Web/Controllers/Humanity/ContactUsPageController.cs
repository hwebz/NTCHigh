using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using High.Net.Models.Constants;
using High.Net.Models.Humanity.Pages;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.ViewModels;
using High.Net.Web.Business;
using High.Net.Web.Business.Helpers;
using System;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.Humanity
{
    [TemplateDescriptor(Name = SiteGroups.EOH)]
    public class ContactUsPageController : PageController<ContactUsPage>
    {
        public ActionResult Index(ContactUsPage currentPage)
        {
            return View("~/Views/Humanity/Pages/ContactUsPage/Index.cshtml", new ContactUsPageModel(currentPage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsPage currentPage, ContactUsForm ContactUsForm)
        {
            var _DataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var _IContentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var homePage = _IContentRepository.Get<HomePage>(currentPage.ParentLink);
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

            return View("~/Views/Humanity/Pages/ContactUsPage/Index.cshtml", model);
        }
    }
}