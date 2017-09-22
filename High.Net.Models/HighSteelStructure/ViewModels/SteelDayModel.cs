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
    public class SteelDayModel : PageViewModel<SteelDayPage>
    {
        public SteelDayModel(SteelDayPage currentPage)
            : base(currentPage) 
        {
            this.SteelDayForm = new SteelDayForm();
            this.SteelDayForm.IsMailSendSuccessfully = false;
        }
      
        public SteelDayForm SteelDayForm { get; set; }
    }
    public class SteelDayForm
    {
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Mailing Address is required.")]
        [Display(Name = "Mailing Address")]
        public string MailingAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Business Classification is required.")]
        [Display(Name = "Business Classification")]
        public string BusinessClassification { get; set; }
        
        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email Address is not valid.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Daytime Phone Number with Area Code is required.")]
        [Display(Name = "Daytime Phone Number with Area Code")]
        public string PhoneNumber { get; set; }

        [Display(Name = "How did you hear about this event?")]
        public string HowDidYouHearAboutEvent { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        public bool IsMailSendSuccessfully { get; set; }
    }

}
