using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.HighSteelStructure.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "Image Text Block",
        GUID = "1fb8533f-c600-4dde-83ad-1720c89c0052",
        Description = "",
        Order=18001)]
    public class ImageTextBlock : HighSteelStructureBlockData
    {
        #region Image

        [Display(
            Name = "Image",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2100)]
        public virtual XhtmlString Text { get; set; }

        [Display(
            Name = "Link page",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual EPiServer.Url LinkPage { get; set; }

        #endregion
    }
}