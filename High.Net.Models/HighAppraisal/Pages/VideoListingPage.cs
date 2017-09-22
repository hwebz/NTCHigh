using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighAppraisal.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HAPP,
        DisplayName = "Video Listing Page",
        GUID = "10c0b96d-4508-48d5-9835-bb3a594ddc66",
        Description = "",
        Order = 14030)]    
    [AvailableContentTypes(Availability.Specific, Include = new [] { typeof(VideoItemPage) })]
    public class VideoListingPage : HighAppraisalPageData , IHighAppraisal
    {

    }
}