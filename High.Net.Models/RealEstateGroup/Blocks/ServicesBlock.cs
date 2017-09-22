using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(GroupName = SiteGroups.REG, Order=8010, DisplayName = "Services Block", GUID = "d731e57c-d8e6-4b54-8955-d7418050d819", Description = "")]
    [SiteImageUrl]
    public class ServicesBlock : RealEstateGroupBlockData
    {
        #region Image

        [Display(Name = "Image (Width : 226 , Height : 226)",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 100)]
        [CultureSpecific]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the block",
            GroupName = Global.Tabs.Content,
            Order = 200)]
        public virtual String Heading { get; set; }

        #endregion

        #region Url

        [Display(Name = "Page Url",
           GroupName = Global.Tabs.Images,
           Description = "Image",
           Order = 300)]
        public virtual EPiServer.Url PageUrl { get; set; }

        #endregion
    }
}