using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High.Net.Core;
using System.ComponentModel.DataAnnotations;
using High.Net.Models.Shared.Pages;
using Foolproof;
using EPiServer.Core;
using High.Net.Models.Residential.Pages;

namespace High.Net.Models.Residential.ViewModels
{
    public class ScheduleTourPageModel : PageViewModel<ScheduleTourPage>
    {
        public ScheduleTourPageModel(ScheduleTourPage scheduleTourPage)
            : base(scheduleTourPage)
        {
            this.scheduleTourPageForm = new ScheduleTourPageForm();
            this.scheduleTourPageForm.IsFormSubmitted = false;
        }

        public ScheduleTourPageForm scheduleTourPageForm { get; set; }
    }

    public class ScheduleTourPageForm
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Please Enter your Email Id")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tour time is required")]
        public string TourTime { get; set; }

        public string PhoneNo { get; set; }

        public string Message { get; set; }

        public bool IsFormSubmitted { get; set; }

    }
}