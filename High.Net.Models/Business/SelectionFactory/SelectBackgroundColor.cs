using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Business.SelectionFactory
{
    class SelectBackgroundColor : ISelectionFactory
    {
        private Injected<ContentLocator> ContentLocator { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var propertyTypes = ContentLocator.Service.GetCategories(PropertyCategories.PageBackgroundColor);
            return new List<SelectItem>(propertyTypes.Categories.Select(c => new SelectItem { Value = c.Name, Text = c.Description }));
        }
    }
}
