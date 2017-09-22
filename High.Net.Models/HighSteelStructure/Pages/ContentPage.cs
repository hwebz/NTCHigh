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
        DisplayName = "Content Page",
        GUID = "51c05450-1298-41c7-acbb-5073ff10b0d9",
        Description = "",
        Order = 18040)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage), typeof(NewsListingPage), typeof(AskHighSteelPage), typeof(FAQListingPage), typeof(ContactSalesPage), typeof(ContactUsPage) })]
    public class ContentPage : HighSteelStructurePageData
    {
        #region Content

        [Display(
            Name = "Main Content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2100)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageTextBlock), typeof(FaqBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}