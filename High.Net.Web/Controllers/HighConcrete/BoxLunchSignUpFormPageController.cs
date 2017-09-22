using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.HighConcrete.ViewModels;
using System;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class BoxLunchSignUpFormPageController : PageController<BoxLunchSignUpFormPage>
    {
        public ActionResult Index(BoxLunchSignUpFormPage currentPage)
        {
            var model = new BoxLunchSignUpFormModel(currentPage);
            {

            }

            return View("~/Views/HighConcrete/Pages/BoxLunchSignUpFormPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BoxLunchSignUpFormPage currentPage, BoxLunchSignUpForm _BoxLunchSignUpForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new BoxLunchSignUpFormModel(currentPage);
            {

            }
          
            if (ModelState.IsValid)
            {
                //Send mail to high
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody),
                                                 _BoxLunchSignUpForm.FirstName, _BoxLunchSignUpForm.MiddleName, _BoxLunchSignUpForm.LastName, 
                                                 _BoxLunchSignUpForm.ConfirmEmailAddress, _BoxLunchSignUpForm.Company, _BoxLunchSignUpForm.AddressLane1,
                                                 _BoxLunchSignUpForm.AddressLane2,_BoxLunchSignUpForm.City, _BoxLunchSignUpForm.State, 
                                                 _BoxLunchSignUpForm.ZipCode,_BoxLunchSignUpForm.PlusFour,_BoxLunchSignUpForm.Telephone, _BoxLunchSignUpForm.Fax,
                                                 _BoxLunchSignUpForm.WhichBestDescribesYou,_BoxLunchSignUpForm.AIANumber,_BoxLunchSignUpForm.ProgramInformation,
                                                 _BoxLunchSignUpForm.PreferedDate1, _BoxLunchSignUpForm.PreferedDate2,_BoxLunchSignUpForm.PreferedDate3);
                dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null, true, null, _BoxLunchSignUpForm.EmailAddress);
                model._BoxLunchSignUpForm.Ismailsendsuccessfully = true;
            }

            return View("~/Views/HighConcrete/Pages/BoxLunchSignUpFormPage/Index.cshtml", model);
        }

    }
}