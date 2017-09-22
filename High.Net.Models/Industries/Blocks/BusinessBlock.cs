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
        DisplayName = "Business Block",
        GUID = "af581cfe-eb77-4343-bb1d-35a778276706",
        Description = "",
        Order = 4080)]
    public class BusinessBlock : IndustriesBlockData
    {
        #region Image

        [Display(
            Name = "Image (Width : 201 , Height : 201)",
            Description = "Text Area",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Heading",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1000)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual XhtmlString Text { get; set; }

        [Display(Name = "Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Page Url",
            Order = 1110)]
        public virtual EPiServer.Url PageUrl { get; set; }

        #endregion
    }
}