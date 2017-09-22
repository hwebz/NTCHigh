using High.Net.Core;
using High.Net.Models.HighConcreteAccessories.Pages;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace High.Net.Models.HighConcreteAccessories.ViewModels
{
    public class AskTheExpertPageModel : PageViewModel<AskTheExpertPage>
    {
        public AskTheExpertPageModel(AskTheExpertPage AskTheExpertPage)
            :base(AskTheExpertPage)
        {
            this.AskTheExpertForm = new AskTheExpertForm();
        }

        public AskTheExpertForm AskTheExpertForm { get; set; }
    }

   public class AskTheExpertForm
   {
       [Display(Name="First Name")]
       [Required(ErrorMessage="Please Enter your first name")]
       public string FirstName { get; set; }

       [Display(Name="Middle Name")]
       public string MiddleName { get; set; }

       [Display(Name="First Name")]
       [Required(ErrorMessage="Please Enter your last name")]
       public string LastName { get; set; }

       [Required(ErrorMessage = "Country is required")]
       public string Country { get; set; }

       [Required(ErrorMessage = "Zip/Postal code is required")]
       public string PostalCode { get; set; }

       [Required(ErrorMessage = "Email Address is required")]
       [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
       public string EmailID { get; set; }

       [Required(ErrorMessage = "Please Select Type")]
       public string CustomerType { get; set; }

       public string QuestionType { get; set; }

       public bool IsMailSendSuccessfully { get; set; }

       public IEnumerable<HttpPostedFileBase> fileUpload { get; set; }

   }
}
