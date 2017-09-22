using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Business.Solve360;
using System.Xml;
using System.Xml.Linq;

namespace High.Net.Models.Business.SelectionFactory
{
    /// <summary>
    /// Provides a list of options corresponding to ContactPage pages on the site
    /// </summary>
    /// <seealso cref="ContactPageSelector"/>
    public class SelectSolve360CategoryTag : ISelectionFactory
    {
        private Injected<ContentLocator> ContentLocator { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            List<SolveCategoryTag> categories = Solve360Helper.GetCategoryTags();
            return new List<SelectItem>(categories.Select(c => new SelectItem { Value = c.Id, Text = c.Name }));
        }
    }
}
