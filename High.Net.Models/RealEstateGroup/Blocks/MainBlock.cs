using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(GroupName = SiteGroups.REG, Order = 8060, DisplayName = "Main Block", GUID = "aade5fc6-df65-43e8-ae40-1cb0e874546b", Description = "")]
    public class MainBlock : RealEstateGroupBlockData
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
        [AllowedTypes(typeof(ProfileImageBlock), typeof(TextBlock))]
        public virtual ContentArea BlockContentArea { get; set; }

    }
}