using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(GroupName = SiteGroups.HII,
        Order = 4040, DisplayName = "About Block", GUID = "33c6483d-6dc2-4e88-9828-1542c3ef8882", Description = "")]
    public class AboutBlock : IndustriesBlockData
    {
        #region Image

        [Display(Name = "Page Display Image (Width : 358 , Height : 358)",
           GroupName = Global.Tabs.Images,
           Description = "Page Display Image",
           Order = 1010)]
        public virtual MediaReference AboutPageIcon { get; set; }

        #endregion

        #region Content

        [Display(Name = "Page Url",
          GroupName = Global.Tabs.Content,
          Description = "Page Url",
          Order = 2010)]
        public virtual EPiServer.Url PageUrl { get; set; }


        [Display(Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "Heading",
            Order = 2020)]
        public virtual string Heading { get; set; }

        #endregion
    }
}