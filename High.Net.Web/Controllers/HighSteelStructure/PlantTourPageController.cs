using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Models.HighSteelStructure.ViewModels;
using High.Net.Web.Business;
using EPiServer.ServiceLocation;
using System;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class PlantTourPageController : PageController<PlantTourPage>
    {
        public ActionResult Index(PlantTourPage currentPage)
        {
            var model = new PlantTourPageModel(currentPage)
            {

            };

            return View("~/Views/HighSteelStructure/Pages/PlantTourPage/Index.cshtml",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PlantTourPage currentPage, PlantTourPageForm _PlantTourPageForm)
        {
            
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new PlantTourPageModel(currentPage)
            {

            };
            if (ModelState.IsValid)
            {

                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), _PlantTourPageForm.FirstName, _PlantTourPageForm.LastName,
                                                _PlantTourPageForm.CompanyName, _PlantTourPageForm.MailingAddress,
                                                _PlantTourPageForm.City, _PlantTourPageForm.State, _PlantTourPageForm.BusinessClassification, _PlantTourPageForm.ZipCode,_PlantTourPageForm.PhoneNumberWithAreaCode,
                                                _PlantTourPageForm.EmailAddress, _PlantTourPageForm.HowDidYouHearAboutThisEvent, _PlantTourPageForm.Note);
                _contentRepo.sendMail(
                    currentPage.Subject, mailBody, currentPage.ToEmailID, null, "", true, null,_PlantTourPageForm.EmailAddress);
                model._PlantTourPageForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighSteelStructure/Pages/PlantTourPage/Index.cshtml", model);
        }
    }
}