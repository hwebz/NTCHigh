using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "Video Listing Page",
        GUID = "a46aeb5a-80a7-4867-ab24-37181a46bf81", 
        Description = "",
        Order=18050)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(VideoItemPage) })]
    public class VideoListingPage : HighSteelStructurePageData
    {
        
    }
}