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
        DisplayName = "Expand collapse Block",
        GUID = "AC0EFC76-46D6-4C00-884A-0DE989E150BF",
        Description = "Expand collapse Block",
        Order = 13070)]
    public class ExpandCollapseBlock : HighConcreteBlockData
    {
        #region Content

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1100)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Item Body",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        [AllowedTypes(typeof(ImageTextBlock) , typeof(TextBlock))]
        public virtual ContentArea ItemBody { get; set; }

        #endregion
    }
}