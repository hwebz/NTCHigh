using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Carousel",
        GUID = "2a7aaf92-705b-4bb0-8f5f-24dd964037ae",
        Description = "",
        Order = 10930)]
    public class CarouselBlock : HighNetBlockData
    {
        [Display(
            Name = "Main Heading",
            GroupName = Global.Tabs.Content,
            Description = "Heading",
            Order = 1100)]
        [CultureSpecific]
        public virtual String MainHeading { get; set; }

        [Display(
            Name = "Page Content",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display tasks",
            Order = 1100)]
        [AllowedTypes(typeof(CarouselItemBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
              Name = "View Templates",
              GroupName = Global.Tabs.TemplateSettings,
              Order = 120)]
        [UIHint(HighUIHint.CarouselTemplatesSelection)]
        public virtual string ViewTemplate { get; set; }        
    }
}
