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
        DisplayName = "Product Category Page", 
        GUID = "898e47e0-5d58-4b52-af26-17d3a43298b6",
        Description = "",
        Order=13090)]
    
      [AvailableContentTypes(Availability.Specific ,
        Include = new[] { typeof(ProductListingPage) , typeof(ContentPage),typeof(ColorSelectorListingPage) })]
    public class ProductCategoryPage : HighConcretePageData 
    {
        #region Content

            [Display(
               Name = "Main Content",
               GroupName = Global.Tabs.Content,
               Description = "",
               Order = 1100)]
            [AllowedTypes(typeof(TextBlock),typeof(ProductBlock))]
            public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}