using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(GroupName = SiteGroups.RO, Order = 11040, DisplayName = "Testimonials Block", GUID = "eb206b61-de81-4c5d-a27a-72da991dbdeb", Description = "")]
    public class Testimonials : RolloverBlockData
    {
        #region Image

        [Display(Name = "Person Image (Width : 161 , Height : 161)",
            Description = "Person Image",
            GroupName = Global.Tabs.Images,
            Order = 1000)]
        [CultureSpecific]
        public virtual MediaReference PersonImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Person Name",
            Description = "Person Name",
            GroupName = Global.Tabs.Content,
            Order = 2000)]
        public virtual String PersonName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Person Comment",
            Description = "Person Comment",
            GroupName = Global.Tabs.Content,
            Order = 2010)]
        public virtual XhtmlString Comment { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Is Image On Right Side?",
            Description = "Is Image On Right Side?",
            GroupName = Global.Tabs.Content,
            Order = 2020)]
        public virtual bool IsImageOnRight{ get; set; }

        #endregion

    }
}