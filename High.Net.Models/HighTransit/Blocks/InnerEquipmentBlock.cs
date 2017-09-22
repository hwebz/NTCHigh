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
    [ContentType(GroupName = SiteGroups.HT, Order = 16040, DisplayName = "Inner Equipment Block", GUID = "fea66222-6b99-4063-b535-302eb39b0a1e", Description = "")]
    public class InnerEquipmentBlock : HighTransitBlockData
    {
        #region Content

        [Display(Name = "Equipment Area",
                   GroupName = Global.Tabs.Content,
                   Description = "Equipment Area",
                   Order = 2010)]
        [AllowedTypes(typeof(EquipmentDetailsBlock))]
        public virtual ContentArea EquipmentArea { get; set; }

        #endregion
    }
}