using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR,
        DisplayName = "Text Block",
        GUID = "09ea12eb-a92b-4693-9dda-34caea2ad119",
        Description = "Standard text block",
        Order=5501)]
    public class TextBlock : ResidentialBlockData
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