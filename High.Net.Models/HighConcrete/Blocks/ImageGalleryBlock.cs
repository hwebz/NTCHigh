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
        DisplayName = "Image Gallery Block",
        GUID = "bc2e86a9-14b7-46c0-93dc-fa56b605f13f",
        Description = "",
        Order=13040)]
    public class ImageGalleryBlock : HighConcreteBlockData
    {
        #region Content

        [Display(
            Name = "Image Gallery Content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea ImageGalleryContent { get; set; }

        #endregion
    }
}