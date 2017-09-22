using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.Business.SelectionFactory.Shared
{
    public class CarouselTemplateFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
           {
                    new SelectItem { Text = " ", Value = "" },
                    new SelectItem { Text = "High net Carousel", Value = CarouselViewTemplate.HighNetCarousel },
                    new SelectItem { Text = "Leadership Carousel", Value = CarouselViewTemplate.LeadershipCarousel },
                    new SelectItem { Text = "Family Carousel Left Image", Value = CarouselViewTemplate.FamilyCarouselLeftImage },
                    new SelectItem { Text = "Family Carousel Right Image", Value = CarouselViewTemplate.FamilyCarouselRightImage },
           };
        }
    }
}