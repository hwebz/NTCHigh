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
    [ContentType(
        GroupName = SiteGroups.HT,
        DisplayName = "Member Block",
        GUID = "e2029546-da49-43e3-89b8-329f3e5e4b12",
        Description = "",
        Order=16100)]
    public class MemberBlock : HighTransitBlockData
    {
        #region Images

        [Display(
            Name = "Member Image (Width : 140 , Height : 72)",
            Description = "Image of members logo",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference MemberImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Description",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        [UIHint(UIHint.LongString)]
        public virtual String Description { get; set; }

        #endregion
    }
}