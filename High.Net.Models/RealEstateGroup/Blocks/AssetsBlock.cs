using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(GroupName = SiteGroups.REG, Order=8020, DisplayName = "Assets Block", GUID = "409776c2-6dc4-4e89-8fea-3a07bc8ca154", Description = "")]
    public class AssetsBlock : RealEstateGroupBlockData
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
        [AllowedTypes(typeof(ServicesBlock))]
        public virtual ContentArea BlockContentArea { get; set; }

    }
}