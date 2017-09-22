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
    public class SelectBridgeProjectType : ISelectionFactory
    {
        private Injected<ContentLocator> ContentLocator { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var propertyTypes = ContentLocator.Service.GetCategories(PropertyCategories.BridgeProjectType);
            return new List<SelectItem>(propertyTypes.Categories.Select(c => new SelectItem { Value = c.Name, Text = c.Description }));
        }
    }
}
