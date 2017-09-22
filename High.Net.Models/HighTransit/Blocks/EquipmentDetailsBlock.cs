using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using ImageVault.EPiServer;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(GroupName = SiteGroups.HT, Order = 16030, DisplayName = "Equipment Details Block", GUID = "272fa979-ae74-43ea-b5b6-35bc93f74f97", Description = "")]
    public class EquipmentDetailsBlock : HighTransitBlockData
    {
        #region Images

        [Display(Name = "Equipment Image (Width : 470 , Height : 80)",
          GroupName = Global.Tabs.Images,
          Description = "Equipment Image",
          Order = 1010)]
        public virtual MediaReference EquipmentImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Heading",
                   GroupName = Global.Tabs.Content,
                   Description = "Heading",
                   Order = 2010)]
        [UIHint(UIHint.LongString)]
        public virtual string Heading { get; set; }

        [Display(Name = "Equipment Description",
                   GroupName = Global.Tabs.Content,
                   Description = "Equipment Description",
                   Order = 2020)]
        [UIHint(UIHint.LongString)]
        public virtual string ShortDescription { get; set; }

        #endregion
    }
}