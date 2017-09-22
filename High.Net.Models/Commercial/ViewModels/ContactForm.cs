using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Commercial.ViewModels
{
    class ContactForm
    {
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Name*")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email*")]
        public string Email { get; set; }


        [Display(Name = "Subject")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Message is required!")]
        [Display(Name = "Message*")]
        [UIHint(UIHint.LongString)]
        public string Message { get; set; }
    
    }
}
