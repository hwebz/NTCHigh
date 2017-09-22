using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Models.Validation;
using High.Net.Validation;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Testimonials Container",
        GUID = "DD0BF2D7-7834-41B1-B270-F84ED5C76EF9", Description = "", Order = 10620)]
    public class TestimonialConatinerBlock : HighNetBlockData
    {
        [AllowedTypes(typeof (TestimonialBlock))]
        [MaxItemCount(RangeRules.TestimonialSliderMaxItems)]
        //[MinItemCount(3)]
        public virtual ContentArea Items { get; set; }
    }
}