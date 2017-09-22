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
   public class TechnicalResourcesModel: PageViewModel<TechnicalResourcesPage>
    {
       public TechnicalResourcesModel(TechnicalResourcesPage currentPage)
           : base(currentPage)
       { 
       this.TechnicalResourcesForm = new TechnicalResourcesForm();
       this.TechnicalResourcesForm.IsMailSendSuccessfully = false;
    
       }
       public TechnicalResourcesForm TechnicalResourcesForm { get; set; }
    }
   public class TechnicalResourcesForm
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

       [Required(ErrorMessage = "Phone Number is required.")]
       [Display(Name = "Phone Number")]
       public string PhoneNumber { get; set; }

       [Required(ErrorMessage = "Company Name is required.")]
       [Display(Name = "Company Name")]
       public string CompanyName { get; set; }

       [Display(Name = "Company Address")]
       public string CompanyAddress { get; set; }

       [Display(Name = "Purpose of Request")]
       public string PurposeOfRequest { get; set; }

       public bool IsMailSendSuccessfully { get; set; }
   }
}
