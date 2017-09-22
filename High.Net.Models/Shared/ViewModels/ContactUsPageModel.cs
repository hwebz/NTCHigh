using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High.Net.Core;
using System.ComponentModel.DataAnnotations;
using High.Net.Models.Shared.Pages;
using Foolproof;
using EPiServer.Core;

namespace High.Net.Models.Shared.ViewModels
{
    public class ContactUsPageModel : PageViewModel<ContactUsPage>
    {
        public ContactUsPageModel(ContactUsPage ContactUsPage)
            : base(ContactUsPage)
        {
            this.ContactUsForm = new ContactUsForm();
            this.ContactUsForm.IsContactSubmitted = false;
            this.ContactUsForm.IsB2BSite = false;
        }

        public ContactUsForm ContactUsForm { get; set; }
    }

    public class ContactUsForm
    {
        public ContactUsForm()
        {
            this.chkSpecialOffers = true;
        }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Please Enter your Email Id")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Company")]
        [RequiredIf("IsB2BSite", true, ErrorMessage = "Please Enter your Company")]
        public string Company { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string Message { get; set; }

        public string Solve360SelectedCategory { get; set; }

        public bool IsContactSubmitted { get; set; }

        public bool IsSentSuccessfully { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsB2BSite { get; set; }

        public bool IsJsonRequest { get; set; }

        public bool chkSpecialOffers { get; set; }

        public string ThankYouMessageText { get; set; }
    }
}