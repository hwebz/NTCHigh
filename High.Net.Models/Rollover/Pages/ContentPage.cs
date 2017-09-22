using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Rollover.Blocks;

namespace High.Net.Models.Rollover.Pages
{
    [SiteContentType(GroupName = SiteGroups.RO,
        DisplayName = "Content Page",
        Order = 11010,
        GUID = "eb6da4ae-eb42-4718-a6f0-ffa73b00cc73",
        Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(ContentPage) },
        IncludeOn = new[] { typeof(High.Net.Models.Rollover.Pages.HomePage) })]    
    public class ContentPage : RolloverPageData
    {
        #region Content

        [Display(Name = "Content Area",
         Description = "Content Area",
         GroupName = Global.Tabs.Content,
         Order = 3110)]
        [CultureSpecific]
        [AllowedTypes(typeof(MainBlock), typeof(TextBlock))]
        public virtual ContentArea PageContentArea { get; set; }

        #endregion
    }
}