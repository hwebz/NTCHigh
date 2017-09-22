using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighHotels.Blocks
{
    [ContentType(GroupName = SiteGroups.HH, Order = 12010, DisplayName = "Text Block", GUID = "d1054c49-fbf1-42e2-b019-b59763b5dd8b", Description = "")]
    [SiteImageUrl]
    public class TextBlock : HighHotelsBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text of the block",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual XhtmlString Text { get; set; }

    }
}