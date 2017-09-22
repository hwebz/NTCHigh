using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(GroupName = SiteGroups.RO, Order = 11020, DisplayName = "Main Block", GUID = "1f00cc61-1b04-4f77-83a8-8b6186474329", Description = "")]
    public class MainBlock : RolloverBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the block",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content Area",
            Description = "Content Area for Blocks",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        [AllowedTypes(typeof(TextBlock), typeof(Testimonials), typeof(ProfileBlock), typeof(FindASpaceBlock))]
         public virtual ContentArea BlockContentArea { get; set; }

    }
}