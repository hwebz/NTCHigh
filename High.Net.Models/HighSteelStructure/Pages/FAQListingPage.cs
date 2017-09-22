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
        DisplayName = "FAQ Listing Page",
        GUID = "D14CD8D7-9B39-464E-85CA-0286BF584284",
        Description = "FAQ Listing Page",
        Order = 18140)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(FAQItemPage) })]
    public class FAQListingPage : HighSteelStructurePageData
    {
        #region Content

        [Display(
            Name = "Main Content",
            GroupName = Global.Tabs.Content,
            Description = "Main Content",
            Order = 2100)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageTextBlock) , typeof(FaqBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}