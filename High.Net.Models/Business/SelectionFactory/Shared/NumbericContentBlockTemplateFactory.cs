using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.Business.SelectionFactory.Shared
{
    public class NumbericContentBlockTemplateFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
           {
                    new SelectItem { Text = " ", Value = "" },
                    new SelectItem { Text = "Numberic Text Only", Value = NumbericContentViewTemplate.NumbericTextOnly },
                    new SelectItem { Text = "Numberic With Photos Gallery", Value = NumbericContentViewTemplate.NumbericWithPhotosGallery },
           };
        }
    }
}