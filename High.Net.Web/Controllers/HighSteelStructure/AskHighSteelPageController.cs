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
using System.Net.Mail;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class AskHighSteelPageController : PageController<AskHighSteelPage>
    {
        public ActionResult Index(AskHighSteelPage currentPage)
        {
            var model = new AskHighSteelModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/AskHighSteelPage/Index.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AskHighSteelPage currentPage, AskHighSteelForm askHighSteelForm)
        {
            List<Attachment> Attachments = new List<Attachment>();
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new AskHighSteelModel(currentPage) { AskHighSteelForm = askHighSteelForm };
            if (ModelState.IsValid)
            {
                foreach (var item in askHighSteelForm.fileUpload)
                {
                    if (item != null)
                    {
                        Attachments.Add(new Attachment(item.InputStream, item.FileName));
                    }
                }
                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), askHighSteelForm.FirstName, askHighSteelForm.LastName, askHighSteelForm.Title, askHighSteelForm.Company, askHighSteelForm.EmailAddress, askHighSteelForm.PhoneNumber, askHighSteelForm.Subject, askHighSteelForm.Question);
                _contentRepo.sendMail(
                    currentPage.Subject, mailBody, currentPage.ToEmailID, Attachments, "", true, null,askHighSteelForm.EmailAddress);
                askHighSteelForm.IsMailSendSuccessfully = true;
            }
            return View("~/Views/HighSteelStructure/Pages/AskHighSteelPage/Index.cshtml", model);
        }
    }
}