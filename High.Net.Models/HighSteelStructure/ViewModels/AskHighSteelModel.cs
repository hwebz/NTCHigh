using High.Net.Core;
using High.Net.Models.HighSteelStructure.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace High.Net.Models.HighSteelStructure.ViewModels
{
    public class AskHighSteelModel : PageViewModel<AskHighSteelPage>
    {
        public AskHighSteelModel(AskHighSteelPage currentPage) : base(currentPage) 
        {
            this.AskHighSteelForm = new AskHighSteelForm();
            this.AskHighSteelForm.IsMailSendSuccessfully = false;
        }
        public AskHighSteelForm AskHighSteelForm { get; set; }
    }

    public class AskHighSteelForm
    {
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Title is required.")]
        [Display(Name="Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Question")]
        public string Question { get; set; }

        public bool IsMailSendSuccessfully { get; set; }

        public IEnumerable<HttpPostedFileBase> fileUpload { get; set; }
    }
}
