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
    public class ContactSalesModel : PageViewModel<ContactSalesPage>
    {
        public ContactSalesModel(ContactSalesPage currentPage)
            : base(currentPage)
        {
            this.ContactSalesForm = new ContactSalesForm();
            this.ContactSalesForm.IsMailSendSuccessfully = false;
        }
        public ContactSalesForm ContactSalesForm { get; set; }
    }
    public class ContactSalesForm
    {
        public List<string> TypeofProjects = new List<string>() { "Bridges", "Building Construction", "Manufacturing", "Steel Erection", "Emergency Repair", "Specialized Hauling", "Other" };

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Your Message is required.")]
        [Display(Name = "Your Message")]
        public string Message { get; set; }
        
        public bool IsMailSendSuccessfully { get; set; }

        public string SelectedProject { get; set; }
    }
}
