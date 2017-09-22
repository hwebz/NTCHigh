using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.SelfStorage.Blocks
{
    [ContentType(GroupName = SiteGroups.PSS, 
        DisplayName = "Text Block",
        GUID = "100cc624-66d1-463f-937b-31fa3ef2f60a",
        Description = "Standard text block",
        Order=2501)]
    public class TextBlock : SelfStorageBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title of the block",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text of the block",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual XhtmlString Text { get; set; }
    }
}