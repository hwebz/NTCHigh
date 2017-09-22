using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Constants;
using High.Net.Models.Business.Solve360;
using High.Net.Models.Residential.Pages;
using High.Net.Models.Residential.ViewModels;
using System;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.Residential
{
    [TemplateDescriptor(Name = SiteGroups.BR)]
    public class ScheduleTourPageController : PageController<ScheduleTourPage>
    {
        public ActionResult Index(ScheduleTourPage currentPage)
        {
            var model = new ScheduleTourPageModel(currentPage)
            {

            };
            return View("~/Views/Residential/Pages/ScheduleTourPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ScheduleTourPage currentPage, ScheduleTourPageForm scheduleTourPageForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new ScheduleTourPageModel(currentPage)
            {
                scheduleTourPageForm = scheduleTourPageForm
            };
            if (ModelState.IsValid)
            {
                string mailBody = string.Format(System.Convert.ToString(currentPage.MailBody), scheduleTourPageForm.Name,
                    scheduleTourPageForm.Email, scheduleTourPageForm.TourTime, scheduleTourPageForm.PhoneNo,
                    scheduleTourPageForm.Message);

                if (!string.IsNullOrEmpty(currentPage.ToEmailID))
                {
                    dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null, true, null);
                    model.scheduleTourPageForm.IsFormSubmitted = true;
                }
                return View("~/Views/Residential/Pages/ScheduleTourPage/Index.cshtml", model);
            }
            model.scheduleTourPageForm.IsFormSubmitted = false;
            return View("~/Views/Residential/Pages/ScheduleTourPage/Index.cshtml", model);
        }
    }


}