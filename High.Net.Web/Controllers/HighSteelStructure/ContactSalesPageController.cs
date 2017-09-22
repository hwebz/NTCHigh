using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Models.HighSteelStructure.ViewModels;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using System;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class ContactSalesPageController : HighSteelStructureController<ContactSalesPage>
    {
        public ActionResult Index(ContactSalesPage currentPage)
        {
            var model = new ContactSalesModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/ContactSalesPage/Index.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactSalesPage currentPage, ContactSalesForm contactSalesForm)
        {
            var model = new ContactSalesModel(currentPage) { ContactSalesForm = contactSalesForm };
            if (ModelState.IsValid) 
            {
                var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
               
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), contactSalesForm.FirstName, contactSalesForm.LastName, contactSalesForm.CompanyName,
                    contactSalesForm.Email, contactSalesForm.PhoneNumber, contactSalesForm.SelectedProject,contactSalesForm.Message);
                _contentRepo.sendMail(
                        currentPage.Subject, mailBody, currentPage.ToEmailID, null, "", true, null,contactSalesForm.Email);
                contactSalesForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighSteelStructure/Pages/ContactSalesPage/Index.cshtml", model);
        }
    }
}