using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Business.SelectionFactory
{
    /// <summary>
    /// Provides a list of options corresponding to ContactPage pages on the site
    /// </summary>
    /// <seealso cref="ContactPageSelector"/>
    public class SelectRolloverSite : ISelectionFactory
    {
        private Injected<ContentLocator> ContentLocator { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            List<SelectItem> RolloverSites = new List<SelectItem>() { 
            new SelectItem{Text = "Commercial", Value="commercial"},
            new SelectItem{Text = "Residential", Value="residential"},
            new SelectItem{Text = "Retail", Value="retail"}
            };

            return RolloverSites;
        }
    }
}
