using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.Business.SelectionFactory.Shared
{
    public class PhotosGalleryTemplateFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
           {
                    new SelectItem { Text = " ", Value = "" },
                    new SelectItem { Text = "Grid No Button", Value = PhotoGalleryViewTemplates.GridNoButton },
                    new SelectItem { Text = "Grid No Space No Button", Value = PhotoGalleryViewTemplates.GridNoSpaceNoButton },
                    new SelectItem { Text = "Grid With Button", Value = PhotoGalleryViewTemplates.GridWithButton },
                    new SelectItem { Text = "Grid Slider No Button", Value = PhotoGalleryViewTemplates.GridSliderNoButton },
           };
        }
    }
}