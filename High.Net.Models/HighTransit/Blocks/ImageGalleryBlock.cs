using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HT,
        DisplayName = "Image Gallery Block",
        GUID = "61731fe1-27cc-4202-8654-1e99cabc4c81",
        Description = "Used for history Image Gallery",
        Order=16090)]
    public class ImageGalleryBlock : HighTransitBlockData
    {
        #region Content

        [Display(
            Name = "Image Gallery Content (Width : 425 , Height : 337)",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea GalleryContent { get; set; }

        #endregion
    }
}