using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.Business.SelectionFactory.HighNet
{
    public class ImageTextBlockTemplateFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
           {
                    new SelectItem { Text = "Full Screen Image", Value =ImageTextViewTemplate.FullImage },
                    new SelectItem { Text = "Image In Left", Value = ImageTextViewTemplate.ImageInLeft},
                    new SelectItem { Text = "Image Below", Value = ImageTextViewTemplate.ImageBelow},
           };
        }
    }
}