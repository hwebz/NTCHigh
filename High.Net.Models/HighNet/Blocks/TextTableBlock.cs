using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Text Table",
        GUID = "8a16b02b-d1c5-4c0d-8113-3dd0dc93f0b8", 
        Description = "",
        Order=10800)]
    public class TextTableBlock : HighNetBlockData
    {
        [Display(
            Name = "Main Heading",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        [CultureSpecific]
        public virtual string MainHeading { get; set; }

        [Display(
             Name = "Page Content",
             GroupName = Global.Tabs.Content,
             Description = "Content Area to display tasks",
             Order = 1100)]
        [AllowedTypes(typeof(TextTableItemBlock))]
        public virtual ContentArea TextTableContentArea { get; set; }
    }
}