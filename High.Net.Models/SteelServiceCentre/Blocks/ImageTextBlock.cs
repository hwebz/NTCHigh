using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.SteelServiceCentre.Blocks
{
    [ContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Image Text Block", 
        GUID = "e8753465-27db-4c3b-9593-207b9a727c6f", 
        Description = "",
        Order=6550)]
    public class ImageTextBlock : SteelServiceCentreBlockData
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
            Order = 2100)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        [UIHint(UIHint.LongString)]
        public virtual String Description { get; set; }

        [Display(
            Name = "Target Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        public virtual EPiServer.Url TargetLink { get; set; }

        #endregion
    }
}