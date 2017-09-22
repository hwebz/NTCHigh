using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Models.HighSteelStructure.ViewModels;
using System;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class TechnicalResourcesPageController : PageController<TechnicalResourcesPage>
    {
        public ActionResult Index(TechnicalResourcesPage currentPage)
        {
            var model = new TechnicalResourcesModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/TechnicalResourcesPage/Index.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TechnicalResourcesPage currentPage, TechnicalResourcesForm technicalResourcesForm)
        {
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new TechnicalResourcesModel(currentPage) { TechnicalResourcesForm = technicalResourcesForm };
            if (ModelState.IsValid)
            {
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody),technicalResourcesForm.FirstName,technicalResourcesForm.LastName,technicalResourcesForm.EmailAddress,technicalResourcesForm.PhoneNumber,technicalResourcesForm.CompanyName,technicalResourcesForm.CompanyAddress,technicalResourcesForm.PurposeOfRequest);
                _contentRepo.sendMail(
                    currentPage.Subject, mailBody, currentPage.ToEmailID, null, "", true, null,technicalResourcesForm.EmailAddress);
                model.TechnicalResourcesForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighSteelStructure/Pages/TechnicalResourcesPage/Index.cshtml", model);
        }
    }
}