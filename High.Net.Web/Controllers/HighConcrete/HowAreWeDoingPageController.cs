using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.HighConcrete.ViewModels;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class HowAreWeDoingPageController : PageController<HowAreWeDoingPage>
    {
        public ActionResult Index(HowAreWeDoingPage currentPage)
        {
            var model = new HowAreWeDoingModel(currentPage)
            {

            };
            ViewBag.SendingStatus = false;
            return View("~/Views/HighConcrete/Pages/HowAreWeDoingPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HowAreWeDoingPage currentPage, HowAreWeDoingForm HowAreWeDoingForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new HowAreWeDoingModel(currentPage)
            {

            };
            if (ModelState.IsValid)
            {
                string mailBody = string.Format(System.Convert.ToString(currentPage.MailBody), HowAreWeDoingForm.EasyToFind, HowAreWeDoingForm.Accomplishment, HowAreWeDoingForm.Recommendation, HowAreWeDoingForm.RecommendationComment);
                dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null, true, null);
                ViewBag.SendingStatus = true;
                return View("~/Views/HighConcrete/Pages/HowAreWeDoingPage/Index.cshtml", model);
            }
            ViewBag.SendingStatus = false;
            return View("~/Views/HighConcrete/Pages/HowAreWeDoingPage/Index.cshtml", model);
        }
    }
}