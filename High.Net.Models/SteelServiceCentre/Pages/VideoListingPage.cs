using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.SteelServiceCentre.Blocks;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "VideoListingPage",
        GUID = "b27f8a8f-1b60-4e5b-a47e-0c7a358d1439",
        Description = "",
        Order = 6080)]    
    [AvailableContentTypes(Availability.Specific, Include= new[] { typeof(VideoItemPage) })]
    public class VideoListingPage : SteelServiceCentrePageData
    {
        [Display(
            Name = "Sidebar Content Area",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1400)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea SidebarContentArea { get; set; }
    }
}