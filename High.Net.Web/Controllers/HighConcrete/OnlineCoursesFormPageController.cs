using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.HighConcrete.ViewModels;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using System;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class OnlineCoursesFormPageController : PageController<OnlineCoursesFormPage>
    {
        public ActionResult Index(OnlineCoursesFormPage currentPage)
        {
            var model = new OnlineCoursesFormModel(currentPage);
            {

            }

            return View("~/Views/HighConcrete/Pages/OnlineCoursesFormPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OnlineCoursesFormPage currentPage, OnlineCoursesForm _OnlineCoursesForm)
        {
            string CertificateRequired = "No";
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new OnlineCoursesFormModel(currentPage);
            {
                
            }

            if (ModelState.IsValid)
            {
                if (_OnlineCoursesForm.CertificateOfCompletionRequired)
                {
                    CertificateRequired = "Yes";
                }
                //send mail to high
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody),
                                                 _OnlineCoursesForm.FirstName, _OnlineCoursesForm.MiddleName, _OnlineCoursesForm.LastName,
                                                 _OnlineCoursesForm.ConfirmEmailAddress, _OnlineCoursesForm.Company, _OnlineCoursesForm.AddressLane1,
                                                 _OnlineCoursesForm.AddressLane2, _OnlineCoursesForm.City, _OnlineCoursesForm.State,
                                                 _OnlineCoursesForm.ZipCode, _OnlineCoursesForm.PlusFour, _OnlineCoursesForm.Telephone, _OnlineCoursesForm.Fax,
                                                 _OnlineCoursesForm.WhichBestDescribesYou, _OnlineCoursesForm.AIANumber,CertificateRequired ,
                                                 _OnlineCoursesForm.ProgramInformation);
                dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null,true,null,_OnlineCoursesForm.EmailAddress);
                model._OnlineCoursesForm.Ismailsendsuccessfully = true;
            }

            return View("~/Views/HighConcrete/Pages/OnlineCoursesFormPage/Index.cshtml", model);
        }
    }
}