using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.Business.SelectionFactory.Shared
{
    public class AuthorQuoteTemplateFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
           {
                    new SelectItem { Text = " ", Value = "" },
                    new SelectItem { Text = "High net Author Quote Slider", Value = AuthorQuoteSliderViewTemplate.HighNetAuthorQuote },
                    new SelectItem { Text = "Family Author Quote Slider", Value = AuthorQuoteSliderViewTemplate.FamilyAuthorQuote },
           };
        }
    }
}