using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Core;
using High.Net.Models.HighConcrete.ViewModels;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using System.Net.Mail;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class GetQuotePageController : PageController<GetQuotePage>
    {
        public ActionResult Index(GetQuotePage currentPage)
        {
            ViewBag.SendingStatus = false;
            var model = new GetQuotePageModel(currentPage) { };
            return View("~/Views/HighConcrete/Pages/GetQuotePage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GetQuotePage currentPage, GetQuoteForm getQuoteForm)
        {
            List<Attachment> attach = new List<Attachment>();
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new GetQuotePageModel(currentPage) { };
            var repo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            var homePage = repo.Get<HomePage>(PageReference.StartPage);

            if (ModelState.IsValid)
            {
                //send mail to admin
                if (getQuoteForm.AttachmentFile != null)
                    attach.Add(new Attachment(getQuoteForm.AttachmentFile.InputStream, getQuoteForm.AttachmentFile.FileName));
                
                string mailBody = string.Format(System.Convert.ToString(currentPage.MailBody), getQuoteForm.FirstName, getQuoteForm.MiddleInitial, getQuoteForm.LastName,
                    getQuoteForm.EmailAddress, getQuoteForm.Company, getQuoteForm.AddressLane1, getQuoteForm.AddressLane2, getQuoteForm.City,
                    getQuoteForm.State, getQuoteForm.Zip, getQuoteForm.PlusFour, getQuoteForm.PrimaryTelephone, getQuoteForm.WhichBestDescribesYou,
                    getQuoteForm.ProjectInformation);

                dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, attach, null, true, null, getQuoteForm.EmailAddress);

                //send mail to user
                string userMailBody = string.Format(System.Convert.ToString(currentPage.MailBodyForUser));

                dataLocator.sendMail(currentPage.Subject, userMailBody, getQuoteForm.EmailAddress, null, null, true, null, currentPage.ToEmailID, homePage.Name);

                ViewBag.SendingStatus = true;
                return View("~/Views/HighConcrete/Pages/GetQuotePage/Index.cshtml", model);
            }
            ViewBag.SendingStatus = false;
            return View("~/Views/HighConcrete/Pages/GetQuotePage/Index.cshtml", model);
        }
    }
}