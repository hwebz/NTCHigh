using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Commercial.Blocks
{
    [ContentType(
        GroupName = SiteGroups.B2B, 
        DisplayName = "Image Gallery Block", 
        GUID = "3e09ce4d-3628-49fe-a09d-b88322b163e3", 
        Description = "",
        Order=3540)]
    public class ImageGalleryBlock : CommercialBlockData
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