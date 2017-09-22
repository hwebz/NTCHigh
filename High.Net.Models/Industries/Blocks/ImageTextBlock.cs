using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HII,
        DisplayName = "Image Text Block",
        GUID = "43647108-73e6-4966-8839-4642a6035c1d",
        Description = "",
        Order=4050)]
    public class ImageTextBlock : IndustriesBlockData
    {
        #region Images

        [Display(
            Name = "Image",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion


        #region Content

        [Display(
            Name = "Description",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}