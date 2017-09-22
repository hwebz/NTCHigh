using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(GroupName = SiteGroups.HII, Order = 4020, DisplayName = "Text Block", GUID = "a5f5709f-2539-4e37-a2c5-e92646bc3186", Description = "")]
    [SiteImageUrl]
    public class TextBlock : IndustriesBlockData
    {
        #region Content

        [Display(
            Name = "Text",
            Description = "Text Area",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}