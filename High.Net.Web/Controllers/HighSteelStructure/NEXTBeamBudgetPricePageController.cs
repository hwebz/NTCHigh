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
    public class NEXTBeamBudgetPricePageController : PageController<NEXTBeamBudgetPricePage>
    {
        public ActionResult Index(NEXTBeamBudgetPricePage currentPage)
        {
            var model = new NEXTBeamBudgetPriceModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/NEXTBeamBudgetPricePage/Index.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NEXTBeamBudgetPricePage currentPage, NEXTBeamBudgetPriceForm _NEXTBeamBudgetPriceForm)
        {
            var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new NEXTBeamBudgetPriceModel(currentPage) { _NEXTBeamBudgetPriceForm = _NEXTBeamBudgetPriceForm };
            if (ModelState.IsValid)
            {
                model._NEXTBeamBudgetPriceForm.IsPreviewPage = _NEXTBeamBudgetPriceForm.IsPreviewPage;
                if (!model._NEXTBeamBudgetPriceForm.IsPreviewPage)
                {
                    string mailBody = string.Format(Convert.ToString(currentPage.MailBody),
                        _NEXTBeamBudgetPriceForm.FirstName, _NEXTBeamBudgetPriceForm.LastName, _NEXTBeamBudgetPriceForm.ContactTitle,
                        _NEXTBeamBudgetPriceForm.Company, _NEXTBeamBudgetPriceForm.PhoneNumber, _NEXTBeamBudgetPriceForm.Email,
                        _NEXTBeamBudgetPriceForm.ProjectName, _NEXTBeamBudgetPriceForm.ConstructionBidDate, _NEXTBeamBudgetPriceForm.ProjectCity,
                        _NEXTBeamBudgetPriceForm.State, _NEXTBeamBudgetPriceForm.BeamDeliveryLocation, _NEXTBeamBudgetPriceForm.DeliveryDate,
                        _NEXTBeamBudgetPriceForm.ProjectOwner, _NEXTBeamBudgetPriceForm.OwnerProjectNumber, _NEXTBeamBudgetPriceForm.ApproxBridgeWidth,
                        _NEXTBeamBudgetPriceForm.ApproxBridgeLength, _NEXTBeamBudgetPriceForm.NumberofSpans, _NEXTBeamBudgetPriceForm.TypeofBeam,
                        _NEXTBeamBudgetPriceForm.ApproximateBeamLength, _NEXTBeamBudgetPriceForm.ApproximateBeamDepth, _NEXTBeamBudgetPriceForm.AdditionalNotes);

                    _contentRepo.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, "", true, null,_NEXTBeamBudgetPriceForm.Email);

                    _NEXTBeamBudgetPriceForm.IsSuccess = true;
                    return View("~/Views/HighSteelStructure/Pages/NEXTBeamBudgetPricePage/Index.cshtml", model);
                }
                return View("~/Views/HighSteelStructure/Pages/NEXTBeamBudgetPricePage/Index.cshtml", model);
            }
            model._NEXTBeamBudgetPriceForm.IsPreviewPage = false;
            return View("~/Views/HighSteelStructure/Pages/NEXTBeamBudgetPricePage/Index.cshtml", model);
        }
    }
}