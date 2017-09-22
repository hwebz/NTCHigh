using EPiServer.Core;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Shared.ViewModels
{
    public class PropertyPageModel : PageViewModel<PropertyListingPage>
    {
        public PropertyPageModel(PropertyListingPage currentPage)
            : base(currentPage)
        {
            this.propertySearchForm = new PropertySearchForm();
        }

        public PropertySearchForm propertySearchForm { get; set; }
    }

    public class PropertySearchForm
    {
        public PageReference RootPage { get; set; }
        public List<string> ListingType { get; set; }
        public List<string> PropertyType { get; set; }
        public string Location { get; set; }
        public string Keywords { get; set; }
        public List<double> Size { get; set; }
        public List<double> Rent { get; set; }
        public List<double> RentBase { get; set; }
        public IEnumerable<PropertyPage> SearchResult { get; set; }
    }
}


