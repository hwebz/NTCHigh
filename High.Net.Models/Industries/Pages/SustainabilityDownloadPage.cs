using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Industries.Blocks;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Models.Industries.Pages
{
    [SiteContentType(GroupName = SiteGroups.HII, DisplayName = "Embracing the Power of Sustainability Download Page",
        GUID = "b4883a38-73f2-4b92-8073-37e0c5ee78d2", Description = "", Order = 4050)]
    public class SustainabilityDownloadPage : IndustriesPageData
    {
        #region Content

        [Display(
           Name = "Thank you message",
           GroupName = Global.Tabs.Content,
           Description = "This message is display after submit.",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        [Display(Name = "Top Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2110)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea TopContentArea { get; set; }

        [Display(Name = "Bottom Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2120)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea BottomContentArea { get; set; }

        #endregion
    }
}