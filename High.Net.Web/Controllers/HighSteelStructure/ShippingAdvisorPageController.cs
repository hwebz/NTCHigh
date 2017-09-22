using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Models.HighSteelStructure.ViewModels;
using System;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class ShippingAdvisorPageController : PageController<ShippingAdvisorPage>
    {
        public ActionResult Index(ShippingAdvisorPage currentPage)
        {
            var model = new ShippingAdvisorPageModel(currentPage, new ShippingAdvisorPageForm())
            {

            };
            return View("~/Views/HighSteelStructure/Pages/ShippingAdvisorPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ShippingAdvisorPage currentPage, ShippingAdvisorPageForm ShippingAdvisorPageForm)
        {
            var dataLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<High.Net.Web.Business.DataLocator>();
            var model = new ShippingAdvisorPageModel(currentPage, ShippingAdvisorPageForm);
            if (ModelState.IsValid)
            {
                model.ShippingAdvisorPageForm.IsPreviewPage = ShippingAdvisorPageForm.IsPreviewPage;
                if (!model.ShippingAdvisorPageForm.IsPreviewPage)
                {
                    string mailBody = string.Format(Convert.ToString(currentPage.MailBody),
                        ShippingAdvisorPageForm.FirstName, ShippingAdvisorPageForm.LastName,
                        ShippingAdvisorPageForm.Title, ShippingAdvisorPageForm.CompanyName,
                        ShippingAdvisorPageForm.PhoneNumber, ShippingAdvisorPageForm.EmailAddress,
                        ShippingAdvisorPageForm.ProjectName, ShippingAdvisorPageForm.LettingDate, ShippingAdvisorPageForm.ProjectCountry,
                        (ShippingAdvisorPageForm.ProjectState != null) ? ShippingAdvisorPageForm.ProjectState : ShippingAdvisorPageForm.ProjectStateName,
                        ShippingAdvisorPageForm.RouteNumber, ShippingAdvisorPageForm.WaterBridgeCross,
                        ShippingAdvisorPageForm.DeliveryDateQuarter, ShippingAdvisorPageForm.DeliveryDateYear,
                        ShippingAdvisorPageForm.TotalEstSteelWeight, ShippingAdvisorPageForm.NumberofPieces,
                        ShippingAdvisorPageForm.OwnersProjectNumber, ShippingAdvisorPageForm.Description,
                        ShippingAdvisorPageForm.TypeOfGirder, ShippingAdvisorPageForm.GirderName, ShippingAdvisorPageForm.GirderMeasures,
                        ShippingAdvisorPageForm.GirderLongestLength, ShippingAdvisorPageForm.GirderLongestLengthMeasures,
                        ShippingAdvisorPageForm.GirderLongestHeight, ShippingAdvisorPageForm.GirderLongestHeightMeasures,
                        ShippingAdvisorPageForm.GirderLongestWidth, ShippingAdvisorPageForm.GirderLongestWidthMeasures,
                        ShippingAdvisorPageForm.GirderLongestWeight, ShippingAdvisorPageForm.GirderLongestWeightMeasures,
                        ShippingAdvisorPageForm.GirderLongestRadiusofcurve, ShippingAdvisorPageForm.GirderLongestRadiusofcurveMeasures,
                        ShippingAdvisorPageForm.GirderHeaviestLength, ShippingAdvisorPageForm.GirderHeaviestLengthMeasures,
                        ShippingAdvisorPageForm.GirderHeaviestHeight, ShippingAdvisorPageForm.GirderHeaviestHeightMeasures,
                        ShippingAdvisorPageForm.GirderHeaviestWidth, ShippingAdvisorPageForm.GirderHeaviestWidthMeasures,
                        ShippingAdvisorPageForm.GirderHeaviestWeight, ShippingAdvisorPageForm.GirderHeaviestWeightMeasures,
                        ShippingAdvisorPageForm.GirderHeaviestRadiusofcurve, ShippingAdvisorPageForm.GirderHeaviestRadiusofcurveMeasures,
                        ShippingAdvisorPageForm.Note);

                   

                    dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null, true, null,ShippingAdvisorPageForm.EmailAddress);
                    model.ShippingAdvisorPageForm.IsFormSubmitted = true;
                }
                return View("~/Views/HighSteelStructure/Pages/ShippingAdvisorPage/Index.cshtml", model);
            }
            model.ShippingAdvisorPageForm.IsPreviewPage = false;
            return View("~/Views/HighSteelStructure/Pages/ShippingAdvisorPage/Index.cshtml", model);
        }
    }
}