using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(GroupName = SiteGroups.HT, Order = 16050, DisplayName = "Profile Block", GUID = "9faaad1f-20b2-4a3b-ba27-2b685f59bdc3", Description = "")]
    public class ProfileBlock : HighTransitBlockData
    {
        #region Images

        [CultureSpecific]
        [Display(
            Name = "Person Image (Width : 142 , Height : 182)",
            Description = "Person Image",
            GroupName = Global.Tabs.Images,
            Order = 100)]
        public virtual MediaReference PersonImage { get; set; }

        #endregion
        

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Person Name",
            Description = "Person Name",
            GroupName = Global.Tabs.Content,
            Order = 2010)]
        public virtual string PersonName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Person Designation",
            Description = "Person Designation",
            GroupName = Global.Tabs.Content,
            Order = 2020)]
        public virtual string PersonDesignation { get; set; }

        #endregion
    }
}