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
    public class FindRepresentativeModel : PageViewModel<FindRepresentativePage>
    {
        public FindRepresentativeModel(FindRepresentativePage currentPage)
            : base(currentPage)
        {
            this.FindRepresentitiveForm = new FindRepresentitiveForm();
        }

        public FindRepresentitiveForm FindRepresentitiveForm{ get; set; }
 
    }

    public class FindRepresentitiveForm
    {

        [Required(ErrorMessage = "Which best describes you is required!")]
        [Display(Name = "Which best describes you?")]
        public string PersonDescription { get; set; }

        [Required(ErrorMessage = "Project name is required!")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Project size is required!")]
        [Display(Name = "Project Size")]
        public string ProjectSize { get; set; }

        public string RepresentativeLocation { get; set; }

        [Required(ErrorMessage = "State is required!")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "County is required!")]
        [Display(Name = "County")]
        public string County { get; set; }

    }
}
