using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.HighTransit.Blocks;

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName = SiteGroups.HT,Order=16020, DisplayName = "Content Page", GUID = "d591d0c4-2b0a-405e-b1ac-71b351063a48", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage),typeof(ProjectListingPage)})]    
    public class ContentPage : HighTransitPageData
    {
        #region Content

        [Display(Name = "Page Content Area",
           GroupName = Global.Tabs.Content,
           Description = "Page Content Area",
           Order = 2010)]
        [AllowedTypes(typeof(ProfileBlock), typeof(TextBlock),
            typeof(EquipmentBlock), typeof(InnerEquipmentBlock), typeof(ImageGalleryBlock),
            typeof(ImageTextBlock), typeof(MemberBlock),typeof(AwardsBlock))]
        public virtual ContentArea PageContentArea { get; set; }

        #endregion
    }
}