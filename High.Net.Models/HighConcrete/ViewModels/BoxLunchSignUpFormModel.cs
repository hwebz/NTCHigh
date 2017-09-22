using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace High.Net.Models.HighConcrete.ViewModels
{
    public class BoxLunchSignUpFormModel : PageViewModel<BoxLunchSignUpFormPage>
    {
        // select only BoxLunchSignUpFormPage for page
        public BoxLunchSignUpFormModel(BoxLunchSignUpFormPage CurrentPage)
            : base(CurrentPage)
        {
            this._BoxLunchSignUpForm = new BoxLunchSignUpForm();
            this._BoxLunchSignUpForm.Ismailsendsuccessfully = false;
        } 
        public BoxLunchSignUpForm _BoxLunchSignUpForm { get; set; }

       
    }

    public class BoxLunchSignUpForm
    {
        // contructor to fill all dropdown information 
        public BoxLunchSignUpForm()
        {
            this.WhichBestDescribesYouItems = new List<SelectListItem>() { 
                new SelectListItem(){Text="Architect", Value="Architect"},
                new SelectListItem(){Text="Engineer", Value="Engineer"},
                new SelectListItem(){Text="Parking Consultant", Value="Parking Consultant"},
                new SelectListItem(){Text="General Contractor", Value="General Contractor"},
                new SelectListItem(){Text="Construction Manager", Value="Construction Manager"},
                new SelectListItem(){Text="Owner", Value="Owner"},
                new SelectListItem(){Text="Student", Value="Student"},
                new SelectListItem(){Text="Other", Value="Other"},
            };

            this.States = new List<SelectListItem>() { 
                new SelectListItem(){Text="Alabama", Value="Alabama"},
                new SelectListItem(){Text="Alaska", Value="Alaska"},
                new SelectListItem(){Text="American Samoa", Value="American Samoa"},
                new SelectListItem(){Text="Arizona", Value="Arizona"},
                new SelectListItem(){Text="Arkansas", Value="Arkansas"},
                new SelectListItem(){Text="California", Value="California"},
                new SelectListItem(){Text="Colorado", Value="Colorado"},
                new SelectListItem(){Text="Connecticut", Value="Connecticut"},
                new SelectListItem(){Text="Delaware", Value="Delaware"},
                new SelectListItem(){Text="District of Columbia", Value="District of Columbia"},
                new SelectListItem(){Text="Florida", Value="Florida"},
                new SelectListItem(){Text="Georgia", Value="Georgia"},
                new SelectListItem(){Text="Guam", Value="Guam"},
                new SelectListItem(){Text="Hawaii", Value="Hawaii"},
                new SelectListItem(){Text="Idaho", Value="Idaho"},
                new SelectListItem(){Text="Illinois", Value="Illinois"},
                new SelectListItem(){Text="Indiana", Value="Indiana"},
                new SelectListItem(){Text="Iowa", Value="Iowa"},
                new SelectListItem(){Text="Kansas", Value="Kansas"},
                new SelectListItem(){Text="Kentucky", Value="Kentucky"},
                new SelectListItem(){Text="Louisiana", Value="Louisiana"},
                new SelectListItem(){Text="Maine", Value="Maine"},
                new SelectListItem(){Text="Maryland", Value="Maryland"},
                new SelectListItem(){Text="Massachusetts", Value="Massachusetts"},
                new SelectListItem(){Text="Michigan", Value="Michigan"},
                new SelectListItem(){Text="Minnesota", Value="Minnesota"},
                new SelectListItem(){Text="Mississippi", Value="Mississippi"},
                new SelectListItem(){Text="Missouri", Value="Missouri"},
                new SelectListItem(){Text="Montana", Value="Montana"},
                new SelectListItem(){Text="Nebraska", Value="Nebraska"},
                new SelectListItem(){Text="Nevada", Value="Nevada"},
                new SelectListItem(){Text="New Hampshire", Value="New Hampshire"},
                new SelectListItem(){Text="New Jersey", Value="New Jersey"},
                new SelectListItem(){Text="New Mexico", Value="New Mexico"},
                new SelectListItem(){Text="New York", Value="New York"},
                new SelectListItem(){Text="North Carolina", Value="North Carolina"},
                new SelectListItem(){Text="North Dakota", Value="North Dakota"},
                new SelectListItem(){Text="Northern Marianas Islands", Value="Northern Marianas Islands"},
                new SelectListItem(){Text="Ohio", Value="Ohio"},
                new SelectListItem(){Text="Oklahoma", Value="Oklahoma"},
                new SelectListItem(){Text="Oregon", Value="Oregon"},
                new SelectListItem(){Text="Pennsylvania", Value="Pennsylvania"},
                new SelectListItem(){Text="Puerto Rico", Value="Puerto Rico"},
                new SelectListItem(){Text="Rhode Island", Value="Rhode Island"},
                new SelectListItem(){Text="South Carolina", Value="South Carolina"},
                new SelectListItem(){Text="South Dakota", Value="South Dakota"},
                new SelectListItem(){Text="Tennessee", Value="Tennessee"},
                new SelectListItem(){Text="Texas", Value="Texas"},
                new SelectListItem(){Text="Utah", Value="Utah"},
                new SelectListItem(){Text="Vermont", Value="Vermont"},
                new SelectListItem(){Text="Virginia", Value="Virginia"},
                new SelectListItem(){Text="Virgin Islands", Value="Virgin Islands"},
                new SelectListItem(){Text="Washington", Value="Washington"},
                new SelectListItem(){Text="West Virginia", Value="West Virginia"},
                new SelectListItem(){Text="Wisconsin", Value="Wisconsin"},
                new SelectListItem(){Text="Wyoming", Value="Wyoming"},

            };
        } 

        #region SignUp Information

        #region Personal Information

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter E-mail Address.")]
        [EmailAddress(ErrorMessage = "Please enter valid E-mail Address.")]
        public string EmailAddress { get; set; }

        [System.ComponentModel.DataAnnotations.CompareAttribute("EmailAddress", ErrorMessage = "The E-mail and confirmation E-mail do not match.")]
        public string ConfirmEmailAddress { get; set; }

        public string Company { get; set; }

        [Required(ErrorMessage = "Please enter Address Lane 1.")]
        public string AddressLane1 { get; set; }

        public string AddressLane2 { get; set; }

        [Required(ErrorMessage = "Please enter your city.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter State/Province/Territory.")]
        public string State { get; set; }
        public List<SelectListItem> States { get; set; }

        [Required(ErrorMessage = "Please enter your zip code.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public string PlusFour { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        #endregion

        #region Addition information

        [Required(ErrorMessage = "Please select the best option to describe you.")]
        public string WhichBestDescribesYou { get; set; }
        public List<SelectListItem> WhichBestDescribesYouItems { get; set; }

        [Display(Name = "AIA Number")]
        public string AIANumber { get; set; }

        [Display(Name = "Program Information")]
        public string ProgramInformation { get; set; }

        public bool Ismailsendsuccessfully { get; set; }

        #endregion

        #region prefered Dates

        [Required(ErrorMessage = "Please enter your preferred date 1.")]
        [Display(Name = "Preferred Date 1")]
        public string PreferedDate1 { get; set; }

        [Required(ErrorMessage = "Please enter your preferred date 2.")]
        [Display(Name = "Preferred Date 2")]
        public string PreferedDate2 { get; set; }

        [Required(ErrorMessage = "Please enter your preferred date 3.")]
        [Display(Name = "Preferred Date 3")]
        public string PreferedDate3 { get; set; }

        #endregion

        #endregion

        
    }
}
