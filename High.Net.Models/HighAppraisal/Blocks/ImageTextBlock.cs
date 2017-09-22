using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.HighAppraisal.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HAPP,
        DisplayName = "Image Text Block", 
        GUID = "7edd17ab-02ed-4dd4-ab78-5d1b00e54d8f",
        Description = "",
        Order = 14001)]
    public class ImageTextBlock : HighAppraisalBlockData
    {
        #region Images

        [Display(
            Name = "Image",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1100)]
        public virtual String Heading { get; set; }

        #endregion
    }
}