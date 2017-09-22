using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Associates.Blocks
{
    [ContentType(GroupName = SiteGroups.HA, 
        DisplayName = "Text Block",
        GUID = "03c8ea4f-6144-4ef0-9ddf-6c91b6e05545",
        Description = "",
        Order = 7510)]
    public class TextBlock : AssociatesBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the block",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text of the block",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}