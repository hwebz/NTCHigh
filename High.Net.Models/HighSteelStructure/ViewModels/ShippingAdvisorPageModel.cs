using High.Net.Core;
using High.Net.Models.HighSteelStructure.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foolproof;
using System.Web.Mvc;

namespace High.Net.Models.HighSteelStructure.ViewModels
{
    public class ShippingAdvisorPageModel : PageViewModel<ShippingAdvisorPage>
    {
        public ShippingAdvisorPageModel(ShippingAdvisorPage shippingAdvisorPage, ShippingAdvisorPageForm shippingAdvisorPageForm)
            : base(shippingAdvisorPage)
        {
            this.ShippingAdvisorPageForm = shippingAdvisorPageForm;
            this.ShippingAdvisorPageForm.IsFormSubmitted = false;
        }

        public ShippingAdvisorPageForm ShippingAdvisorPageForm { get; set; }
    }

    public class ShippingAdvisorPageForm
    {
        public ShippingAdvisorPageForm()
        {
            DeliveryDateYears = new List<SelectListItem>();

            for (int i = 0; i < 10; i++)
            {
                DeliveryDateYears.Add(new SelectListItem()
                {
                    Text = Convert.ToString(DateTime.Now.Year + i),
                    Value = Convert.ToString(DateTime.Now.Year + i),
                });
            }
        }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Project Name is required.")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Scheduled Construction Letting Date is required.")]
        [Display(Name = "Scheduled Construction Letting Date")]
        public string LettingDate { get; set; }

        [Required(ErrorMessage = "Project Country is required.")]
        [Display(Name = "Project Country")]
        public string ProjectCountry { get; set; }

        [RequiredIf("ProjectStateName", null, ErrorMessage = "Project State is required.")]
        [Display(Name = "Project State")]
        public string ProjectState { get; set; }

        [RequiredIf("ProjectState", null, ErrorMessage = "Project State is required.")]
        [Display(Name = "Project State Name")]
        public string ProjectStateName { get; set; }

        [Required(ErrorMessage = "Route Number is required.")]
        [Display(Name = "Route Number")]
        public string RouteNumber { get; set; }

        [Required(ErrorMessage = "Road or Body of Water Bridge is to Cross is required.")]
        [Display(Name = "WaterBridgeCross ")]
        public string WaterBridgeCross { get; set; }

        [Display(Name = "Steel Delivery Date Quarter")]
        public string DeliveryDateQuarter { get; set; }

        [Display(Name = "Steel Delivery Date Year")]
        public string DeliveryDateYear { get; set; }
        public List<SelectListItem> DeliveryDateYears { get; set; }

        [Required(ErrorMessage = "Est. Total Steel Weight is required.")]
        [Display(Name = "Total Est Steel Weight")]
        public string TotalEstSteelWeight { get; set; }

        [Display(Name = "Number of Pieces")]
        public string NumberofPieces { get; set; }

        [Display(Name = "Owner's Project Number")]
        public string OwnersProjectNumber { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Type of Girder is required.")]
        public string TypeOfGirder { get; set; }

        [Display(Name = "Girder Name")]
        [RequiredIf("TypeOfGirder", "Curved", ErrorMessage = "Radius of curve is required")]
        public string GirderName { get; set; }

        [RequiredIf("TypeOfGirder", "Curved", ErrorMessage = "Please select unit")]
        public string GirderMeasures { get; set; }

        [Required(ErrorMessage = "Girder Length is required.")]
        [Display(Name = "Girder Length")]
        public string GirderLongestLength { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderLongestLengthMeasures { get; set; }

        [Required(ErrorMessage = "Girder Height is required.")]
        [Display(Name = "Girder Height")]
        public string GirderLongestHeight { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderLongestHeightMeasures { get; set; }

        [Required(ErrorMessage = "Girder Width is required.")]
        [Display(Name = "Girder Width")]
        public string GirderLongestWidth { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderLongestWidthMeasures { get; set; }

        [Required(ErrorMessage = "Girder Weight is required.")]
        [Display(Name = "Girder Weight")]
        public string GirderLongestWeight { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderLongestWeightMeasures { get; set; }

        [RequiredIf("TypeOfGirder", "Curved", ErrorMessage = "Radius of curve is required")]
        [Display(Name = "Girder Radius of curve")]
        public string GirderLongestRadiusofcurve { get; set; }

        [RequiredIf("TypeOfGirder", "Curved", ErrorMessage = "Please select unit")]
        public string GirderLongestRadiusofcurveMeasures { get; set; }

        [Required(ErrorMessage = "Girder Length is required.")]
        [Display(Name = "Girder Length")]
        public string GirderHeaviestLength { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderHeaviestLengthMeasures { get; set; }

        [Required(ErrorMessage = "Girder Height is required.")]
        [Display(Name = "Girder Height")]
        public string GirderHeaviestHeight { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderHeaviestHeightMeasures { get; set; }

        [Required(ErrorMessage = "Girder Width is required.")]
        [Display(Name = "Girder Width")]
        public string GirderHeaviestWidth { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderHeaviestWidthMeasures { get; set; }

        [Required(ErrorMessage = "Girder Weight is required.")]
        [Display(Name = "Girder Weight")]
        public string GirderHeaviestWeight { get; set; }

        [Required(ErrorMessage = "Please select unit")]
        public string GirderHeaviestWeightMeasures { get; set; }

        [RequiredIf("TypeOfGirder", "Curved", ErrorMessage = "Radius of curve is required")]
        [Display(Name = "Girder Radius of curve")]
        public string GirderHeaviestRadiusofcurve { get; set; }

        [RequiredIf("TypeOfGirder", "Curved", ErrorMessage = "Please select unit")]
        public string GirderHeaviestRadiusofcurveMeasures { get; set; }

        public string Note { get; set; }

        public bool IsPreviewPage { get; set; }
        public bool IsFormSubmitted { get; set; }
    }
}
