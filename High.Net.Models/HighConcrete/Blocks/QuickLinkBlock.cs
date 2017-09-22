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
        DisplayName = "Quick Link Block",
        GUID = "FC72A341-1761-4C08-B38C-3A08D6F2EFFE",
        Description = "Quick Link Block",
        Order = 13060)]
    public class QuickLinkBlock : HighConcreteBlockData
    {
        #region Content

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Tab PlaceHolder",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        [AllowedTypes(typeof(ImageTextBlock) , typeof(TextBlock))]
        public virtual ContentArea PlaceHolder { get; set; }

        #endregion
    }
}