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
    public class SelectContainerType : ISelectionFactory
    {
        private Injected<ContentLocator> ContentLocator { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var containerTypes = ContentLocator.Service.GetCategories(PropertyCategories.ContainerStyle);
            return new List<SelectItem>(containerTypes.Categories.Select(c => new SelectItem { Value = c.Name, Text = c.Name }));
        }
    }
}
