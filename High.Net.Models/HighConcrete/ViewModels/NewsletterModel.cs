using EPiServer.Core;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighConcrete.ViewModels
{
    public class NewsletterModel : PageViewModel<NewsLetterPage>
    {
        public NewsletterModel(NewsLetterPage currentPage)
            : base(currentPage)
        {
            this.NewsLetterForm = new NewsLetterForm();
            this.NewsLetterForm.IsMailSendSuccessfully = false;
        }

        public NewsLetterForm NewsLetterForm { get; set; }
        //public ContentReference MessageOnPost { get; set; }
    }

    public class NewsLetterForm
    {
       
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Job Title is required.")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "State/Province is required.")]
        [Display(Name = "State/Province")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip/Postal Code is required.")]
        [Display(Name = "Zip/Postal Code")]
        public string ZipCode { get; set; }

        public bool IsMailSendSuccessfully { get; set; }
    }
}
