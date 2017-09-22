using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.StructureCareUs.Blocks
{
    [ContentType(GroupName = SiteGroups.SCU, Order=9010, DisplayName = "Text Block", GUID = "be3a1f93-a376-4756-8183-f30d5a5d1ab6", Description = "")]
    [SiteImageUrl]
    public class TextBlock : StructureCareUsBlockData
    {
           [CultureSpecific]
                [Display(
                    Name = "Text",
                    Description = "Text",
                    GroupName = Global.Tabs.Content,
                    Order = 100)]
                public virtual XhtmlString Text { get; set; }
    }
}