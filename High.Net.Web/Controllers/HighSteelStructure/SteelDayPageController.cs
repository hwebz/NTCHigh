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
    public class SteelDayPageController : HighSteelStructureController<SteelDayPage>
    {
        public ActionResult Index(SteelDayPage currentPage)
        {
            var model = new SteelDayModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/SteelDayPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SteelDayPage currentPage, SteelDayForm steelDayForm)
        {
            var model = new SteelDayModel(currentPage) { SteelDayForm = steelDayForm };
            if (ModelState.IsValid)
            {
                var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
                
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), steelDayForm.FirstName, steelDayForm.LastName, steelDayForm.Company, steelDayForm.MailingAddress, steelDayForm.City, steelDayForm.State,
                    steelDayForm.BusinessClassification, steelDayForm.ZipCode, steelDayForm.EmailAddress, steelDayForm.PhoneNumber, steelDayForm.HowDidYouHearAboutEvent, steelDayForm.Note);
                _contentRepo.sendMail(
                        currentPage.Subject, mailBody, currentPage.ToEmailID, null, "", true, null,steelDayForm.EmailAddress);
                steelDayForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighSteelStructure/Pages/SteelDayPage/Index.cshtml", model);
        }
    }
}