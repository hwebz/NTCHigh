using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using High.Net.Core.ContentTypes.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR,
        DisplayName = "Feature Gallery Image Block",
        GUID = "23a5e01e-776c-41e4-8f9d-969302d08f2e",
        Description = "Feature Gallery Image Block",
        Order=5520)]
    public class GalleryBlock : ResidentialBlockData
    {
        #region Image

        [Display(
            Name = "Image Gallery",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSliders { get; set; }

        #endregion
    }
}