using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.Business.SelectionFactory.Shared
{
    public class TestimonialSliderTemplateFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
           {
                    new SelectItem { Text = "High Net Testimonials", Value = TestimonialSliderViewTemplate.HighNetTestimonials },
                    new SelectItem { Text = "Leadership Testimonials", Value = TestimonialSliderViewTemplate.LeadershipTestimonials },
           };
        }
    }
}