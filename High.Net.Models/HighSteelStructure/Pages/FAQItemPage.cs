using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.HighSteelStructure.Blocks;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [ContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "FAQ Item Page",
        GUID = "3F358CA7-3EEA-436B-BF74-D1F29B79E16C",
        Description = "FAQ Item Page",
        Order = 18150)]
    [AvailableContentTypes(Availability.None)]
    public class FAQItemPage : HighSteelStructurePageData
    {
        #region Content

        [Display(
           Name = "FAQ Question",
           GroupName = Global.Tabs.Content,
           Description = "FAQ Question",
           Order = 1100)]
        public virtual String FAQQuestion { get; set; }

        [Display(
           Name = "FAQ Answer",
           GroupName = Global.Tabs.Content,
           Description = "FAQ Answer",
           Order = 1200)]
        public virtual XhtmlString FAQAnswer { get; set; }


        #endregion
    }
}