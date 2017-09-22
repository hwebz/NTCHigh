using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.RealEstateGroup.Blocks;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.RealEstateGroup.Pages
{
    [SiteContentType(GroupName = SiteGroups.REG,
        DisplayName = "Content Page",
        Order = 8020,
        GUID = "1fe88160-308a-4547-ac90-1fac3c787cb3", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(ContentPage)},
        IncludeOn = new[] { typeof(HomePage) })]    
    public class ContentPage : RealEstateGroupPageData
    {
        #region Content

        [Display(Name = "Content Area",
         Description = "Content Area",
         GroupName = Global.Tabs.Content,
         Order = 3110)]
        [CultureSpecific]
        [AllowedTypes(typeof(ProfileImageBlock), typeof(TextBlock))]
        public virtual ContentArea PageContentArea { get; set; }

        #endregion
    }
}