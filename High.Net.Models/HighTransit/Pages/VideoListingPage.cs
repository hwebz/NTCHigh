using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName = SiteGroups.HT, Order = 16070, DisplayName = "Video Listing Page", GUID = "a806ca9c-e78e-4b97-b23c-27de74f2a3c1", Description = "")]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(VideoItemPage) })]    
    public class VideoListingPage : HighTransitPageData
    {

    }
}