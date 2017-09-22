using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.StructureCareUs.Pages;
using High.Net.Models.StructureCareUs.Blocks;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.StructureCareUs.Pages
{
    [SiteContentType(GroupName = SiteGroups.SCU, Order = 9040, DisplayName = "Service Listing Page", GUID = "d31bbedc-d08f-4aee-8c02-8dd871b15436", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ServiceItemPage),typeof(NewsListingPage)})]    
    public class ServiceListingPage : StructureCareUsPageData
    {
        #region Content

        [Display(Name = "Content Area",
         GroupName = Global.Tabs.Content,
         Description = "Content Area",
         Order = 2120)]
        [AllowedTypes(typeof(TextBlock),typeof(ImageTextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}