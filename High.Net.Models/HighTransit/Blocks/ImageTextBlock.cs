using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HT,
        DisplayName = "Image Text Block",
        GUID = "9839b472-12fd-4aa6-8cf6-0fa59a596697",
        Description = "Used for image with text content and for image gallery",
        Order=16080)]
    public class ImageTextBlock : HighTransitBlockData
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