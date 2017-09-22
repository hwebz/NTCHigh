using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Validation;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Models.Validation.HighNet
{
    public class TestimonialConatinerBlockValidation : IValidate<TestimonialConatinerBlock>
    {
        public IEnumerable<ValidationError> Validate(TestimonialConatinerBlock instance)
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
            if (instance.Items == null || instance.Items.Items.Count < RangeRules.TestimonialSliderMinItems)
            {
                var errorMess = $"The TestimonialConatiner block requires a minimum of {RangeRules.TestimonialSliderMinItems} Testimonial block item.";
                Helper.AddError(errorMess, ref errors, "TestimonialConatiner Block", "Items");
            }

            return errors;
        }
    }
}