using EPiServer.XForms.WebControls;
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
    public class NEXTBeamBudgetPriceModel : PageViewModel<NEXTBeamBudgetPricePage>
    {
        public NEXTBeamBudgetPriceModel(NEXTBeamBudgetPricePage currentPage)
            : base(currentPage)
        {
            this._NEXTBeamBudgetPriceForm = new NEXTBeamBudgetPriceForm();
            this._NEXTBeamBudgetPriceForm.IsSuccess = false;
        }
        public NEXTBeamBudgetPriceForm _NEXTBeamBudgetPriceForm { get; set; }
    }
    public class NEXTBeamBudgetPriceForm
    {
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

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Project Name is required.")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Construction Bid Date is required.")]
        [Display(Name = "Construction Bid Date")]
        public string ConstructionBidDate { get; set; }

        [Required(ErrorMessage = "Project City is required.")]
        [Display(Name = "Project City")]
        public string ProjectCity { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Beam Delivery Location is required.")]
        [Display(Name = "Beam Delivery Location")]
        public string BeamDeliveryLocation { get; set; }

        [Required(ErrorMessage = "Delivery Date is required.")]
        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }

        [Required(ErrorMessage = "Project Owner is required.")]
        [Display(Name = "Project Owner")]
        public string ProjectOwner { get; set; }

        [Required(ErrorMessage = "Owner Project Number is required.")]
        [Display(Name = "Owner Project Number")]
        public int OwnerProjectNumber { get; set; }

        [Required(ErrorMessage = "Approx. Bridge Width is required.")]
        [Display(Name = "Approx. Bridge Width")]
        public double ApproxBridgeWidth { get; set; }

        [Required(ErrorMessage = "Approx. Bridge Length is required.")]
        [Display(Name = "Approx. Bridge Length")]
        public double ApproxBridgeLength { get; set; }

        [Required(ErrorMessage = "Number of Spans is required.")]
        [Display(Name = "Number of Spans")]
        public int NumberofSpans { get; set; }

        [Required(ErrorMessage = "Type of Beam is required.")]
        [Display(Name = "Type of Beam")]
        public string TypeofBeam { get; set; }

        [Required(ErrorMessage = "Approximate Beam Length is required.")]
        [Display(Name = "Approximate Beam Length (feet)")]
        [Range(30, 90, ErrorMessage = "Please enter a number between 30 and 90.")]
        public int ApproximateBeamLength { get; set; }

        [Required(ErrorMessage = "Approximate Beam Depth is required.")]
        [Range(24, 40, ErrorMessage = "Please enter a number between 24 and 40.")]
        [Display(Name = "Approximate Beam Depth (inches)")]
        public int ApproximateBeamDepth { get; set; }

        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }

        public bool IsSuccess { get; set; }
        public bool IsPreviewPage { get; set; }
    }
}
