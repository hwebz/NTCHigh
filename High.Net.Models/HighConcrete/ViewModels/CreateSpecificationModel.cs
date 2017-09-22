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
    public class CreateSpecificationModel : PageViewModel<CreateSpecificationPage>
    {
        public CreateSpecificationModel(CreateSpecificationPage currentPage)
            : base(currentPage)
        {
            this.createSpecificationForm = new CreateSpecificationForm();
        }

        public CreateSpecificationForm createSpecificationForm { get; set; }
    }

    public class CreateSpecificationForm
    {
        public string ProductType { get; set; }
        public string ProjectName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string ProjectSize { get; set; }
        public string FirmName { get; set; }
        public string FirmContact { get; set; }

        [Required(ErrorMessage="Please Enter Email Address")]
        [EmailAddress(ErrorMessage="Please Enter Valid Email Address.")]
        public string FirmEmail { get; set; }
        public string SpecificationFormat { get; set; }
        public string SpecificationType { get; set; }
        public bool IsFormSubmitted { get; set; }
    }
}
