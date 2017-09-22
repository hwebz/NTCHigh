using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.SteelServiceCentre.Blocks
{
    [ContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Image Gallery Block",
        GUID = "dde1cf3a-1f40-401a-a031-b882ecc41a35",
        Description = "",
        Order=6540)]
    public class ImageGalleryBlock : SteelServiceCentreBlockData
    {
        #region Content

        [Display(
            Name = "Image Gallery Content",
            GroupName = Global.Tabs.Content,
            Description = "Description",
            Order = 1100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea ImageGalleryContent { get; set; }

        #endregion
    }
}