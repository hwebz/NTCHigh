using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using High.Net.Models.Constants;
using High.Net.Models.HighHotels.Pages;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.ViewModels;
using High.Net.Web.Business;
using High.Net.Web.Business.Helpers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.HighHotels
{
    [TemplateDescriptor(Name = SiteGroups.HH)]
    public class ContactUsPageController : PageController<ContactUsPage>
    {
        public ActionResult Index(ContactUsPage currentPage)
        {
            var model = new ContactUsPageModel(currentPage);
            return View("~/Views/HighHotels/Pages/ContactUsPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsPage currentPage, ContactUsForm contactUsForm)
        {
            var _contentRepo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var homePage = _contentRepo.Get<HomePage>(PageReference.StartPage);

            var model = new ContactUsPageModel(currentPage)
            {
            };
            if (ModelState.IsValid)
            {
                string businessMail = MailHelpers.GetBusinessMail(currentPage.BusinessRecipientsEmail);

                // send mail to high
                var businessMailContentModel = MailHelpers.CreateEmailContentModel(currentPage, contactUsForm, homePage, true);
                model.ContactUsForm.IsContactSubmitted = MailHelpers.SendEmailToAdmin(currentPage, contactUsForm, homePage, businessMailContentModel);

                //send mail to end user
                var userMailContentModel = MailHelpers.CreateEmailContentModel(currentPage, contactUsForm, homePage, false);
                var isSentSuccessfully = MailHelpers.SendEmailToUser(currentPage, contactUsForm, homePage, userMailContentModel);

                // Thank you message functionality
                model.ContactUsForm.ThankYouMessageText = String.Format(Convert.ToString(currentPage.ThankYouMessage), homePage.Name, businessMail);
            }
            if (contactUsForm.IsJsonRequest)
            {
                if (ModelState.IsValid)
                {
                    return Json(model.ContactUsForm.ThankYouMessageText, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var allErrors = ModelState.Values.Where(x => x.Errors.Count > 0).Select(x => x.Errors.Select(c => c.ErrorMessage));
                    return Json(allErrors, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return View("~/Views/HighHotels/Pages/ContactUsPage/Index.cshtml", model);
            }
        }
    }
}