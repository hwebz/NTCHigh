using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.HighConcreteAccessories.Blocks;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.HighConcreteAccessories.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "Content Page",
        GUID = "268cae25-e27d-4af2-817d-fb136b1c0cf7",
        Description = "",
        Order=15010)]    
    [AvailableContentTypes(Availability.Specific, Include= new[] { typeof(ContentPage) , typeof(NewsLetterPage) , typeof(ContactUsPage) ,typeof(AskTheExpertPage) , typeof(CreateSpecificationPage) })]
    public class ContentPage : HighConcreteAccessoriesPageData , IHighConcreteAccessories
    {
        #region Content

        [Display(
            Name = "Main content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1100)]
        [AllowedTypes(typeof(TextBlock) , typeof(FaqBlock),typeof(SpecificationsBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}