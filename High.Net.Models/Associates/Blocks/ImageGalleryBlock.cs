using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Associates.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HA,
        DisplayName = "Image Gallery Block",
        GUID = "c5947a6e-e28c-46a1-ba47-a7624831e328",
        Description = "",
        Order=7540)]
    public class ImageGalleryBlock : AssociatesBlockData
    {
        #region Content

        [Display(
           Name = "Image Galley Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea ImageGalleryContent { get; set; }

        #endregion
    }
}