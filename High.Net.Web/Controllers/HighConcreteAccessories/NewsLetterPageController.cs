using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcreteAccessories.Pages;
using High.Net.Core;
using High.Net.Models.HighConcreteAccessories.ViewModels;
using System.Net.Mail;
using System;
using High.Net.Web.Business;
using EPiServer.ServiceLocation;



namespace High.Net.Web.Controllers.HighConcreteAccessories
{
    public class NewsLetterPageController : HighConcreteAccessoriesController<NewsLetterPage>
    {
        public ActionResult Index(NewsLetterPage currentPage)
        {
            var model = new NewsLetterModel(currentPage)
            {

            };
            return View("~/Views/HighConcreteAccessories/Pages/NewsLetterPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NewsLetterPage currentPage, NewsLetterForm NewsLetterForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new NewsLetterModel(currentPage);
            if (ModelState.IsValid)
            {
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), NewsLetterForm.FirstName, NewsLetterForm.MiddleName,
                    NewsLetterForm.LastName, NewsLetterForm.NewsLetterType, NewsLetterForm.EmailID,
                    NewsLetterForm.CustomerType != null ? NewsLetterForm.CustomerType : NewsLetterForm.CustomerTypeIfOther,
                    NewsLetterForm.CompanyName, NewsLetterForm.StreetAddress1, NewsLetterForm.StreetAddress2,
                    NewsLetterForm.City, NewsLetterForm.State, NewsLetterForm.PostalCode,
                    NewsLetterForm.Country, NewsLetterForm.TelePhone, NewsLetterForm.Fax) + Convert.ToString(currentPage.Signature);

                dataLocator.sendMail(currentPage.Subject, mailBody,currentPage.ToEmailID, null, null, true, null, NewsLetterForm.EmailID);
                
                model.NewsLetterForm.IsFormSubmit = true;
            }
            return View("~/Views/HighConcreteAccessories/Pages/NewsLetterPage/Index.cshtml", model);
        }
    }
}