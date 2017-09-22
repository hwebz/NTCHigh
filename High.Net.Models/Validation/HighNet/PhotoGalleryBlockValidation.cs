using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Validation;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Models.Validation.HighNet
{
    public class PhotoGalleryBlockValidation : IValidate<PhotoGalleryBlock>
    {
        public IEnumerable<ValidationError> Validate(PhotoGalleryBlock instance)
        {
            // List of errors to return within the scope of the current IValidate
            var errors = new List<ValidationError>();

            // Check if the block is published first before trying to validate
            var content = instance as IContent;
            if (ContentReference.IsNullOrEmpty(content.ContentLink))
            {
                return new ValidationError[0];
            }

            // Check the PhotoGalleryContentArea is not null
            if (instance.PhotoGalleryContentArea == null || instance.PhotoGalleryContentArea.Items.Count < RangeRules.PhotoGalleryMinItems)
            {
                var errorMess = $"The PhotoGallery block requires a minimum of {RangeRules.PhotoGalleryMinItems} PhotoGalleryItemBlock block item.";
                Helper.AddError(errorMess, ref errors, "PhotoGallery Block", "PhotoGalleryContentArea");
            }           

            return errors;
        }
    }
}