using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Carousel Area",
        GUID = "4D2C4B46-96DC-4C29-80EE-582B184DDC09",
        Description = "",
        Order = 1000)]
    public class CarouselAreaBlock : HighNetBlockData
    {
        [Display(
            Name = "Area Heading",
            GroupName = Global.Tabs.Content,
            Description = "Area Heading",
            Order = 1100)]
        [CultureSpecific]
        public virtual String MainHeading { get; set; }

        [Display(
            Name = "Carousel Items",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display carousels",
            Order = 1100)]
        [AllowedTypes(typeof(CarouselBlock))]
        public virtual ContentArea CarouselItems { get; set; }
    }
}

