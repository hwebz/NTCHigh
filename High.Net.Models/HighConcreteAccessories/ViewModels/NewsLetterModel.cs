using Foolproof;
using High.Net.Core;
using High.Net.Models.HighConcreteAccessories.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighConcreteAccessories.ViewModels
{
    public class NewsLetterModel : PageViewModel<NewsLetterPage>
    {
        public NewsLetterModel(NewsLetterPage currentPage)
            : base(currentPage)
        {
            this.NewsLetterForm = new NewsLetterForm();
            this.NewsLetterForm.IsFormSubmit = false;
        }

        public NewsLetterForm NewsLetterForm { get; set; }

    }

    public class NewsLetterForm
    {
        [Required(ErrorMessage = "Please select NewsLetter Type")]
        public string NewsLetterType { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zip/Postal code is required")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string EmailID { get; set; }
        [RequiredIf("CustomerTypeIfOther", null, ErrorMessage = "Please Select Type")]
        public string CustomerType { get; set; }
        [RequiredIf("CustomerType", null, ErrorMessage = "Please Select Type")]
        public string CustomerTypeIfOther { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string TelePhone { get; set; }
        public string Fax { get; set; }
        public bool IsFormSubmit { get; set; }

    }
}
