using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace High.Net.Models.Business.SelectionFactory
{
    public class SelectHighSiteTemplate : ISelectionFactory
    {
        public const string HightNetTemplate = "HighNet";
        public const string FamilyTemplate = "Family";
        public const string LeadershipTemplate = "Leadership";
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>() {
                new SelectItem{Text = "HighNet", Value="HighNet"},
                new SelectItem{Text = "Family", Value="Family"},
                new SelectItem{Text = "Leadership", Value="Leadership"}
            };
        }
    }
}
