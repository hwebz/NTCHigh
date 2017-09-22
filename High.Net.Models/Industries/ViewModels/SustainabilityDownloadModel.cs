using High.Net.Core;
using High.Net.Models.Industries.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Industries.ViewModels
{
    public class SustainabilityDownloadModel: PageViewModel<SustainabilityDownloadPage>
    {
        public SustainabilityDownloadModel(SustainabilityDownloadPage currentPage)
            : base(currentPage) 
        {
            this.SustainabilityDownloadForm = new SustainabilityDownloadForm();
            this.SustainabilityDownloadForm.IsMailSendSuccessfully = false;
        }
        public SustainabilityDownloadForm SustainabilityDownloadForm { get; set; }
    }
    public class SustainabilityDownloadForm
    {
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string EmailAddress { get; set; }

        public bool SignUpForMail { get; set; }

        public bool IsMailSendSuccessfully { get; set; }
    }
}
