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
    public class BuildingProjectModel : PageViewModel<BuildingProjectPage>
    {
        public BuildingProjectModel(BuildingProjectPage currentPage)
            : base(currentPage)
        {
            this.BuildingProjectForm = new BuildingProjectForm();
        }
        public BuildingProjectForm BuildingProjectForm { get; set; }
    }
    public class BuildingProjectForm
    {
        public BuildingProjectForm()
        {
            ListDesignsInformation = new List<DesignsInformation>()
            {
                new DesignsInformation{Name="Straight Girder",Checked=false },
                new DesignsInformation{Name="Crane Girder",Checked=false},
                new DesignsInformation{Name="Box Girder",Checked=false},
                new DesignsInformation{Name="Rolled Beam",Checked=false},
                new DesignsInformation{Name="Truss",Checked=false},
                new DesignsInformation{Name="Metal Building Frame",Checked=false},
                new DesignsInformation{Name="Curved Girder",Checked=false},
                new DesignsInformation{Name="Other",Checked=false},
            };
        }

        #region Contact Information

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact Title is required.")]
        [Display(Name = "Contact Title:")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        [Display(Name = "Company:")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Contact Phone is required.")]
        [Display(Name = "Contact Phone:")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email:")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string Email { get; set; }

        #endregion

        #region Project Information

        [Required(ErrorMessage = "Project Name is required.")]
        [Display(Name = "Project Name:")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Project City is required.")]
        [Display(Name = "Project City:")]
        public string ProjectCity { get; set; }

        [Required(ErrorMessage = "Project State is required.")]
        [Display(Name = "Project State:")]
        public string ProjectState { get; set; }

        [Required(ErrorMessage = "Scheduled Construction Letting Date is required.")]
        [Display(Name = "Scheduled Letting Date:")]
        public string ScheduledLettingDate { get; set; }

        [Required(ErrorMessage = "Steel Delivery Location is required.")]
        [Display(Name = "Steel Delivery Location:")]
        public string SteelDeliveryLocation { get; set; }

        [Required(ErrorMessage = "Steel Delivery Date is required.")]
        [Display(Name = "Steel Delivery Date:")]
        public string SteelDeliveryDate { get; set; }

        [Required(ErrorMessage = "Project Owner is required.")]
        [Display(Name = "Project Owner:")]
        public string ProjectOwner { get; set; }

        [Required(ErrorMessage = "State Specifications Used is required.")]
        [Display(Name = "State Specifications Used:")]
        public string StateSpecificationsUsed { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }

        #endregion

        #region Design Information

        public List<DesignsInformation> ListDesignsInformation { get; set; }

        //[Required(ErrorMessage = "Radius is required.")]
        [Display(Name = "Radius:")]
        public string Radius { get; set; }


        //[Required(ErrorMessage = "Radius Unit is required.")]
        [Display(Name = "Radius Unit:")]
        public string RadiusUnit { get; set; }

        #endregion

        #region Specifications

        [Display(Name = "A572 Grade 50:")]
        public string A572Grade50 { get; set; }

        [Display(Name = "A588 Grade 50:")]
        public string A588Grade50 { get; set; }

        [Display(Name = "HPS High Performance Steel:")]
        public string HPSHighPerformanceSteel { get; set; }

        [Display(Name = "A852 Grade HPS 70W (Weathering):")]
        public string A852GradeHPS70W { get; set; }

        [Display(Name = "Coating:")]
        public string Coating { get; set; }

        #endregion

        #region Average Material Measurements

        [Required(ErrorMessage = "Web Thickness is required.")]
        [Display(Name = "Web Thickness:")]
        public string WebThickness { get; set; }

        [Required(ErrorMessage = "Web Thickness Unit is required.")]
        [Display(Name = "Web Thickness Unit:")]
        public string WebThicknessUnit { get; set; }

        [Required(ErrorMessage = "Web Depth is required.")]
        [Display(Name = "Web Depth:")]
        public string WebDepth { get; set; }

        [Required(ErrorMessage = "Web Depth Unit is required.")]
        [Display(Name = "Web Depth Unit:")]
        public string WebDepthUnit { get; set; }

        [Required(ErrorMessage = "Thickest Flange is required.")]
        [Display(Name = "Thickest Flange:")]
        public string ThickestFlange { get; set; }

        [Required(ErrorMessage = "Thickest Flange Unit is required.")]
        [Display(Name = "Thickest Flange Unit:")]
        public string ThickestFlangeUnit { get; set; }

        [Required(ErrorMessage = "Estimated Steel Weight of Entire Structure is required.")]
        [Display(Name = "Estimated Steel Weight of Entire Structure:")]
        public string EstimatedWeight { get; set; }

        [Required(ErrorMessage = "Estimated Steel Weight Unit of Entire Structure is required.")]
        [Display(Name = "Estimated Steel Weight Unit of Entire Structure:")]
        public string EstimatedWeightUnit { get; set; }

        [Required(ErrorMessage = "Fracture Critical is required.")]
        [Display(Name = "Fracture Critical?:")]
        public string FractureCritical { get; set; }

        #endregion

        #region Flags

        public bool IsMailSendSuccessfully { get; set; }
        public bool IsPreviewPage { get; set; }

        #endregion
    }
    public class DesignsInformation
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}

