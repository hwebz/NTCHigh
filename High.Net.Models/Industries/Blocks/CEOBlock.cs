using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HII,
        DisplayName = "CEO Block",
        GUID = "5246d955-91fc-4849-9678-f2a18f55bfac",
        Description = "",
        Order=4070)]
    public class CEOBlock : IndustriesBlockData
    {
        #region Image

        [Display(
            Name = "Image (Width : 165 , Height : 206)",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Heading",
            Description = "Heading of Block",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        #endregion
    }
}