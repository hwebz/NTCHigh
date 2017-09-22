using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName=SiteGroups.HN,
        DisplayName = "Carousel Item", 
        GUID = "bcb9c1ab-f9eb-47e5-b370-450599b0bf5f",
        Description = "",
        Order=10940)]
    public class CarouselItemBlock : HighNetBlockData
    {
        [Display(
        Name = "Image",
        GroupName = Global.Tabs.Content,
        Description = "",
        Order = 1100)]
        public virtual MediaReference Image { get; set; }

        [Display(
        Name = "Alt Text",
        GroupName = Global.Tabs.Content,
        Description = "Description of the image",
        Order = 1200)]
        public virtual string AltText { get; set; }

        [Display(
        Name = "Html Text",
        GroupName = Global.Tabs.Content,
        Description = "use to format text content",
        Order = 1300)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString HtmlText { get; set; }

        [Display(
        Name = "Url",
        GroupName = Global.Tabs.Content,
        Description = "",
        Order = 1400)]
        public virtual EPiServer.Url Link { get; set; }
    }
}