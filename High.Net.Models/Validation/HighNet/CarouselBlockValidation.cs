using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Validation;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Models.Validation.HighNet
{
    public class CarouselBlockValidation : IValidate<CarouselBlock>
    {
        public IEnumerable<ValidationError> Validate(CarouselBlock instance)
        {
            // List of errors to return within the scope of the current IValidate
            var errors = new List<ValidationError>();

            // Check if the block is published first before trying to validate
            var content = instance as IContent;
            if (ContentReference.IsNullOrEmpty(content.ContentLink))
            {
                return new ValidationError[0];
            }

            // Check the ContentArea is not null
            if (instance.ContentArea == null || instance.ContentArea.Items.Count < RangeRules.CarouselMinItems)
            {
                var errorMess = $"The Carousel block requires a minimum of {RangeRules.CarouselMinItems} CarouselItem block item.";
                Helper.AddError(errorMess, ref errors, "Carousel Block", "ContentArea");
            }

            return errors;
        }
    }
}