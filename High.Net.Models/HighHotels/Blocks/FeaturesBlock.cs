using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.HighHotels.Blocks
{
    [ContentType(GroupName = SiteGroups.HH,
        Order = 12040,
        DisplayName = "Features Block", GUID = "d3d2f508-832d-4600-9880-3bee3d58bdb7", Description = "")]
    public class FeaturesBlock : HighHotelsBlockData
    {
        #region Image

        [Display(Name = "Page Icon (Width : 89 , Height : 89)",
        GroupName = Global.Tabs.Images,
        Description = "Page Icon",
        Order = 1010)]
        public virtual MediaReference PageIcon { get; set; }

        [Display(Name = "Page Hover Icon (Width : 89 , Height : 89)",
       GroupName = Global.Tabs.Images,
       Description = "Page Hover Icon",
       Order = 1010)]
        public virtual MediaReference PageHoverIcon { get; set; }

        #endregion

        #region Content

        [Display(Name = "Page Url",
           GroupName = Global.Tabs.Content,
           Description = "Page Url",
           Order = 1020)]
        public virtual EPiServer.Url PageUrl { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading",
            GroupName = Global.Tabs.Content,
            Order = 1030)]
        public virtual String Heading { get; set; }

        #endregion

    }
}