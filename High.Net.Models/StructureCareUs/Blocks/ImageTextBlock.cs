using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.StructureCareUs.Blocks
{
    [ContentType(GroupName = SiteGroups.SCU, Order = 9040, DisplayName = "Image Text Block", GUID = "c0a3c552-0e78-4abb-bf28-19bf63c679f3", Description = "")]
    [SiteImageUrl]
    public class ImageTextBlock : StructureCareUsBlockData
    {
        #region Image

        [Display(Name = "Inner Page Image",
        GroupName = Global.Tabs.Images,
        Description = "Page Image",
        Order = 1110)]
        public virtual MediaReference  Image { get; set; }

        #endregion

        #region Content

        [Display(Name = "Page Content",
          GroupName = Global.Tabs.Content,
          Description = "Page Content",
          Order = 2110)]
        public virtual XhtmlString PageContent { get; set; }

        #endregion
    }
}