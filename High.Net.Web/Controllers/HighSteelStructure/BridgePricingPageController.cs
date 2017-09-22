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
using EPiServer.ServiceLocation;
using High.Net.Web.Business;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class BridgePricingPageController : PageController<BridgePricingPage>
    {
        public ActionResult Index(BridgePricingPage currentPage)
        {
            var model = new BridgePricingModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/BridgePricingPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BridgePricingPage currentPage, BridgePricingForm bridgePricingForm)
        {
            var model = new BridgePricingModel(currentPage) { BridgePricingForm = bridgePricingForm };

            if (ModelState.IsValid)
            {
                model.BridgePricingForm.IsPreviewPage = bridgePricingForm.IsPreviewPage;

                if (!model.BridgePricingForm.IsPreviewPage)
                {
                    var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();

                    string Designs = String.Empty;
                    if (bridgePricingForm.ListDesigns.Count() > 0)
                    {
                        foreach (var item in bridgePricingForm.ListDesigns.Where(x => x.Checked == true))
                        {
                            Designs += item.Name + ", ";
                        }
                    }

                    string mailBody = String.Format(Convert.ToString(currentPage.MailBody), bridgePricingForm.FirstName, bridgePricingForm.LastName, bridgePricingForm.ContactTitle,
                                                    bridgePricingForm.Company, bridgePricingForm.ContactPhone, bridgePricingForm.Email, bridgePricingForm.ProjectName,
                                                    bridgePricingForm.ScheduledConstructionLettingDate, bridgePricingForm.ProjectCity, bridgePricingForm.ProjectState == null ? bridgePricingForm.StateIfNotListed : bridgePricingForm.ProjectState,
                                                    bridgePricingForm.SteelDeliveryDate, bridgePricingForm.ProjectOwner, bridgePricingForm.OwnersProjectNumber,
                                                    bridgePricingForm.ApproximateBridgeLength, bridgePricingForm.ApproximateBridgeLengthUnit, bridgePricingForm.NumberOfSpan,
                                                    bridgePricingForm.Description, Designs,
                                                    bridgePricingForm.Radius, bridgePricingForm.RadiusUnit,
                                                    bridgePricingForm.A572Grade50, bridgePricingForm.A588Grade50W, bridgePricingForm.A852GradeHPS70W, bridgePricingForm.HPSHighPerformanceSteel,
                                                    bridgePricingForm.Coating, bridgePricingForm.WebThickness, bridgePricingForm.WebThicknessUnit, bridgePricingForm.WebDepth,
                                                    bridgePricingForm.WebDepthUnit, bridgePricingForm.ThickestFlange, bridgePricingForm.ThickestFlangeUnit, bridgePricingForm.EstimatedWeight,
                                                    bridgePricingForm.EstimatedWeightUnit, bridgePricingForm.FractureCritical);
                    
                    _contentRepo.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null, true, null,bridgePricingForm.Email);

                    model.BridgePricingForm.IsMailSendSuccessfully = true;
                }
                return View("~/Views/HighSteelStructure/Pages/BridgePricingPage/Index.cshtml", model);
            }
            model.BridgePricingForm.IsPreviewPage = false;
            return View("~/Views/HighSteelStructure/Pages/BridgePricingPage/Index.cshtml", model);
        }
    }
}