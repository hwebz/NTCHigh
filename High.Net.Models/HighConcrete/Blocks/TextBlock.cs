using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighConcrete.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "TextBlock",
        GUID = "65b1741d-a19b-4e5a-848a-097b5ba51170",
        Description = "",
        Order=13020)]
    public class TextBlock : HighConcreteBlockData
    {
        #region Content

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}