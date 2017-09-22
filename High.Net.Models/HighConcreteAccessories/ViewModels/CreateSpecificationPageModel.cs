using High.Net.Core;
using High.Net.Models.HighConcreteAccessories.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighConcreteAccessories.ViewModels
{
    public class CreateSpecificationPageModel : PageViewModel<CreateSpecificationPage>
    {
        public CreateSpecificationPageModel(CreateSpecificationPage CreateSpecificationPage)
            : base(CreateSpecificationPage)
        {
            this.createSpecificationPageForm = new CreateSpecificationPageForm();
        }

        public CreateSpecificationPageForm createSpecificationPageForm { get; set; }
    }

    public class CreateSpecificationPageForm
    {
        public CreateSpecificationPageForm()
        {
            ListProducts = new List<Products>()
            {
                new  Products { Name="Double Tee Stem Blockouts" , Checked=false },
                new  Products { Name="Spandrel Sleeves & Caps", Checked=false },
                new  Products { Name="Wide Shoulder Sleeves & Caps", Checked=false },
                new  Products { Name="Short Wide Shoulder Sleeves & Caps", Checked=false },
                new  Products { Name="Column Sleeves & Caps", Checked=false },
                new  Products { Name="Girder Sleeves", Checked=false },
                new  Products { Name="Grouted Connection Tubes" , Checked=false },
                new  Products { Name="Grouted Connection Tubes w/ Weep" , Checked=false },
                new  Products { Name="Swift-Lift® Covers" , Checked=false },
                new  Products { Name="Burke Lift® Covers" , Checked=false }
            };

        }

        public string ProductType { get; set; }
        public string ProjectName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ProjectSize { get; set; }
        public string FirmName { get; set; }
        public string FirmContact { get; set; }

        [Required(ErrorMessage = "Please enter E-mail address.")]
        [EmailAddress(ErrorMessage = "Please enter valid e-mail address.")]
        public string FirmEmail { get; set; }
        public string SpecificationType { get; set; }
        public string DocumentFormat { get; set; }
        public string DocumentType { get; set; }
        public List<Products> ListProducts { get; set; }
        public bool IsFormSubmitted { get; set; }

    }

    public class Products
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}
