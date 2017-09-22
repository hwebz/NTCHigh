using Foolproof;
using High.Net.Core;
using High.Net.Models.HighSteelStructure.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighSteelStructure.ViewModels
{
    public class BridgePricingModel : PageViewModel<BridgePricingPage>
    {
        public BridgePricingModel(BridgePricingPage currentPage)
            : base(currentPage)
        {
            this.BridgePricingForm = new BridgePricingForm();
            this.BridgePricingForm.IsMailSendSuccessfully = false;
        }
        public BridgePricingForm BridgePricingForm { get; set; }
    }

    public class BridgePricingForm
    {
        public BridgePricingForm()
        {
            ListDesigns = new List<Designs>()
            {
                new Designs{Name="Straight Girder",Checked=false },
                new Designs{Name="Haunched Girder",Checked=false},
                new Designs{Name="Box Girder",Checked=false},
                new Designs{Name="Tub Girder",Checked=false},
                new Designs{Name="Rolled Beam",Checked=false},
                new Designs{Name="Railroad Bridge",Checked=false},
                new Designs{Name="Truss",Checked=false},
                new Designs{Name="Curved Girder",Checked=false},
                new Designs{Name="Other",Checked=false},
            };
        }

        #region Contact Information

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact Title is required.")]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Contact Phone is required.")]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string Email { get; set; }

        #endregion

        #region Project Information

        [Required(ErrorMessage = "Project Name is required.")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Scheduled Construction Letting Date is required.")]
        [Display(Name = "Scheduled Construction Letting Date")]
        public string ScheduledConstructionLettingDate { get; set; }

        [Required(ErrorMessage = "Project City is required.")]
        [Display(Name = "Project City")]
        public string ProjectCity { get; set; }

        [RequiredIf("StateIfNotListed", null, ErrorMessage = "Project State is required.")]
        [Display(Name = "Project State")]
        public string ProjectState { get; set; }

        [RequiredIf("ProjectState", null, ErrorMessage = "Project State is required.")]
        [Display(Name = "State, If Not Listed")]
        public string StateIfNotListed { get; set; }

        [Required(ErrorMessage = "Steel Delivery Date is required.")]
        [Display(Name = "Steel Delivery Date")]
        public string SteelDeliveryDate { get; set; }

        [Required(ErrorMessage = "Project Owner is required.")]
        [Display(Name = "Project Owner")]
        public string ProjectOwner { get; set; }

        [Required(ErrorMessage = "Owner's Project Number is required.")]
        [Display(Name = "Owner's Project Number")]
        public string OwnersProjectNumber { get; set; }

        [Required(ErrorMessage = "Approximate Bridge Length is required.")]
        [Display(Name = "Approximate Bridge Length")]
        public string ApproximateBridgeLength { get; set; }


        [Required(ErrorMessage = "Approximate Bridge Length Unit is required.")]
        [Display(Name = "Approximate Bridge Length Unit")]
        public string ApproximateBridgeLengthUnit { get; set; }

        [Required(ErrorMessage = "Number of Span is required.")]
        [Display(Name = "Number of Spans")]
        public string NumberOfSpan { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        #endregion

        #region Design Information

        public List<Designs> ListDesigns { get; set; }

        //[Required(ErrorMessage = "Radius is required.")]
        [Display(Name = "Radius")]
        public string Radius { get; set; }

        //[Required(ErrorMessage = "Radius Unit is required.")]
        [Display(Name = "Radius Unit")]
        public string RadiusUnit { get; set; }

        #endregion

        #region Specifications

        [Display(Name = "A572 Grade 50")]
        public string A572Grade50 { get; set; }

        [Display(Name = "A588 Grade 50W (Weathering)")]
        public string A588Grade50W { get; set; }

        [Display(Name = "A852 Grade HPS 70W (Weathering)")]
        public string A852GradeHPS70W { get; set; }

        [Display(Name = "HPS High Performance Steel")]
        public string HPSHighPerformanceSteel { get; set; }

        [Display(Name = "Coating")]
        public string Coating { get; set; }

        #endregion

        #region Average Material Measurements

        [Required(ErrorMessage = "Web Thickness is required.")]
        [Display(Name = "Web Thickness")]
        public string WebThickness { get; set; }

        [Required(ErrorMessage = "Web Thickness Unit is required.")]
        [Display(Name = "Web Thickness Unit")]
        public string WebThicknessUnit { get; set; }

        [Required(ErrorMessage = "Web Depth is required.")]
        [Display(Name = "Web Depth")]
        public string WebDepth { get; set; }

        [Required(ErrorMessage = "Web Depth Unit is required.")]
        [Display(Name = "Web Depth Unit")]
        public string WebDepthUnit { get; set; }

        [Required(ErrorMessage = "Thickest Flange is required.")]
        [Display(Name = "Thickest Flange")]
        public string ThickestFlange { get; set; }

        [Required(ErrorMessage = "Thickest Flange Unit is required.")]
        [Display(Name = "Thickest Flange Unit")]
        public string ThickestFlangeUnit { get; set; }

        [Required(ErrorMessage = "Estimated Steel Weight of Entire Structure is required.")]
        [Display(Name = "Estimated Steel Weight of Entire Structure")]
        public string EstimatedWeight { get; set; }

        [Required(ErrorMessage = "Estimated Steel Weight Unit of Entire Structure is required.")]
        [Display(Name = "Estimated Steel Weight Unit of Entire Structure")]
        public string EstimatedWeightUnit { get; set; }

        [Required(ErrorMessage = "Fracture Critical is required.")]
        [Display(Name = "Fracture Critical")]
        public string FractureCritical { get; set; }

        #endregion

        public bool IsMailSendSuccessfully { get; set; }
        public bool IsPreviewPage { get; set; }
    }

    public class Designs
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}
