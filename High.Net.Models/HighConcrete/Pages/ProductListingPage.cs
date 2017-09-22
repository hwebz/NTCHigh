using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConcrete.Blocks;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "ProductListingPage",
        GUID = "6c26d992-c144-43d3-9637-e265dcf77a28", 
        Description = "",
        Order=13100)]    
    [AvailableContentTypes(Availability.Specific ,
        Include = new[] { typeof(ProductListingPage) , typeof(ProductItemPage) , typeof(ContentPage) })]
    public class ProductListingPage : LeftNavigationPage
    {
        #region Content

        [Display(
         Name = "Main Content Area",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1200)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageTextBlock), typeof(ExpandCollapseBlock), typeof(PopupBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}