using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcreteAccessories.Pages;
using High.Net.Models.HighConcreteAccessories.ViewModels;
using System.Net.Mail;
using High.Net.Web.Business;
using EPiServer.ServiceLocation;
using System;

namespace High.Net.Web.Controllers.HighConcreteAccessories
{
    public class AskTheExpertPageController : PageController<AskTheExpertPage>
    {
        public ActionResult Index(AskTheExpertPage currentPage)
        {
            var model = new AskTheExpertPageModel(currentPage)
            {

            };
            return View("~/Views/HighConcreteAccessories/Pages/AskTheExpertPage/Index.cshtml", model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AskTheExpertPage currentPage, AskTheExpertForm AskTheExpertForm)
        {
            List<Attachment> Attachments = new List<Attachment>();
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new AskTheExpertPageModel(currentPage) { AskTheExpertForm = AskTheExpertForm };

           if (ModelState.IsValid)
            {
                foreach(var item in AskTheExpertForm.fileUpload)
                {
                    if (item != null)
                    {
                        Attachments.Add(new Attachment(item.InputStream, item.FileName));
                    }
                }
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), AskTheExpertForm.FirstName, AskTheExpertForm.MiddleName, AskTheExpertForm.LastName, AskTheExpertForm.Country, AskTheExpertForm.PostalCode, AskTheExpertForm.EmailID , AskTheExpertForm.CustomerType, AskTheExpertForm.QuestionType);
                _contentRepo.sendMail(
                    currentPage.Subject, mailBody, currentPage.ToEmailID, Attachments, "", true, null, AskTheExpertForm.EmailID);
                AskTheExpertForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighConcreteAccessories/Pages/AskTheExpertPage/Index.cshtml", model);
        }
    }
}