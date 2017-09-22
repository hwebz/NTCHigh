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
    public class BuildingProjectPageController : PageController<BuildingProjectPage>
    {
        public ActionResult Index(BuildingProjectPage currentPage)
        {
            var model = new BuildingProjectModel(currentPage);
            return View("~/Views/HighSteelStructure/Pages/BuildingProjectPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BuildingProjectPage currentPage, BuildingProjectForm buildingProjectForm)
        {
            var model = new BuildingProjectModel(currentPage) { BuildingProjectForm = buildingProjectForm };

            if (ModelState.IsValid)
            {
                model.BuildingProjectForm.IsPreviewPage = buildingProjectForm.IsPreviewPage;

                if (!model.BuildingProjectForm.IsPreviewPage)
                {
                    var _contentRepo = ServiceLocator.Current.GetInstance<DataLocator>();

                    string Designs = String.Empty;
                    if (buildingProjectForm.ListDesignsInformation.Count() > 0)
                    {
                        foreach (var item in buildingProjectForm.ListDesignsInformation.Where(x => x.Checked == true))
                        {
                            Designs += item.Name + ", ";
                        }
                    }

                    string mailBody = String.Format(Convert.ToString(currentPage.MailBody),
                                                    buildingProjectForm.FirstName, buildingProjectForm.LastName, buildingProjectForm.ContactTitle,
                                                    buildingProjectForm.Company, buildingProjectForm.ContactPhone, buildingProjectForm.Email,
                                                    buildingProjectForm.ProjectName, buildingProjectForm.ProjectCity, buildingProjectForm.ProjectState,
                                                    buildingProjectForm.ScheduledLettingDate, buildingProjectForm.SteelDeliveryLocation, buildingProjectForm.SteelDeliveryDate,
                                                    buildingProjectForm.ProjectOwner, buildingProjectForm.StateSpecificationsUsed, buildingProjectForm.Description,
                                                    Designs, buildingProjectForm.Radius, buildingProjectForm.RadiusUnit,
                                                    buildingProjectForm.A572Grade50, buildingProjectForm.A588Grade50, buildingProjectForm.HPSHighPerformanceSteel,
                                                    buildingProjectForm.A852GradeHPS70W, buildingProjectForm.Coating, buildingProjectForm.WebThickness,
                                                    buildingProjectForm.WebThicknessUnit, buildingProjectForm.WebDepth, buildingProjectForm.WebDepthUnit,
                                                    buildingProjectForm.ThickestFlange, buildingProjectForm.ThickestFlangeUnit,
                                                    buildingProjectForm.EstimatedWeight, buildingProjectForm.EstimatedWeightUnit,
                                                    buildingProjectForm.FractureCritical);

                    _contentRepo.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, null, true, null,buildingProjectForm.Email);

                    model.BuildingProjectForm.IsMailSendSuccessfully = true;
                }
                return View("~/Views/HighSteelStructure/Pages/BuildingProjectPage/Index.cshtml", model);
            }
            model.BuildingProjectForm.IsPreviewPage = false;
            return View("~/Views/HighSteelStructure/Pages/BuildingProjectPage/Index.cshtml", model);
        }
    }
}