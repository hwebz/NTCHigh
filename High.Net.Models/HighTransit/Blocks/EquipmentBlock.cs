using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(GroupName = SiteGroups.HT, Order = 16020, DisplayName = "Equipment Block", GUID = "9ceff279-b536-4ad8-849c-0efcdcb10f22", Description = "")]
    public class EquipmentBlock : HighTransitBlockData
    {
        #region Images

        [Display(Name = "Equipment Image Site Logo (Width : 485 , Height : 315)",
          GroupName = Global.Tabs.Images,
          Description = "Equipment Image",
          Order = 1010)]
        public virtual MediaReference EquipmentImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Equipment Description",
                   GroupName = Global.Tabs.Content,
                   Description = "Equipment Description",
                   Order = 2010)]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}