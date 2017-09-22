using High.Net.Core;
using High.Net.Models.Associates.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Associates.ViewModels
{
    public class HelpPageModel : PageViewModel<HowWeCanHelpYouPage>
    {
        public HelpPageModel(HowWeCanHelpYouPage currentPage)
            : base(currentPage)
        {
            _HelpPageForm = new HelpPageForm();
            _HelpPageForm.IsMailSendSuccessfully = false;
        }
        public HelpPageForm _HelpPageForm { get; set; }
    }

    public class HelpPageForm
    {
        public HelpPageForm()
        {
            this.propertyTypeList = new List<propertyTypes>()
           {
               new propertyTypes { Property = "Office" , IsChecked = false },
               new propertyTypes { Property = "Retail" , IsChecked = false },
               new propertyTypes { Property = "Industrial (warehouse/flex/mfg)" , IsChecked = false },
               new propertyTypes { Property = "Land" , IsChecked = false },
               new propertyTypes { Property = "Investment Property" , IsChecked = false },
               new propertyTypes { Property = "Appartment rental" , IsChecked = false }
           };

            this.serviceTypeList = new List<ServiceTypes>()
            {
                new ServiceTypes { Service="Brokerage Services" , IsChecked=false },
                new ServiceTypes { Service="Development services" , IsChecked=false },
                new ServiceTypes { Service="Faculty & Renovation Services" , IsChecked=false },
                new ServiceTypes { Service="Appraisal Services" , IsChecked=false }
            };
        }

        [Required(ErrorMessage = "Please provide your Email Address")]
        [EmailAddress(ErrorMessage="Please enter a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Company Name")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Please enter your Zip Code")]
        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public List<propertyTypes> propertyTypeList { get; set; }

        public List<ServiceTypes> serviceTypeList { get; set; }

        [MaxLength]
        public string HelpText { get; set; }

        public bool IsMailSendSuccessfully { get; set; }

        public string ThankYouMessageText { get; set; }
    }

    public class propertyTypes
    {
        public string Property { get; set; }

        public bool IsChecked { get; set; }
    }

    public class ServiceTypes
    {
        public string Service { get; set; }

        public bool IsChecked { get; set; }
    }
}
