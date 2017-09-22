using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using ImageVault.EPiServer;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(GroupName = SiteGroups.HT, DisplayName = "Awards Block", GUID = "2e834f61-be8e-4aec-87d7-97640793cecc", Description = "", Order = 16110)]
    public class AwardsBlock : HighTransitBlockData
    {
        #region Images

        [Display(
            Name = "Award Image",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference AwardImage { get; set; }

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