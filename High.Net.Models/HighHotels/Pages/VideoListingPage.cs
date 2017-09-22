using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;

namespace High.Net.Models.HighHotels.Pages
{
    [ContentType(GroupName = SiteGroups.HH,
        Order = 12030, DisplayName = "Video Listing Page", GUID = "eb41a2ff-c8f8-4b45-a9e4-35188046ada4", Description = "")]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(VideoItemPage)})]
    public class VideoListingPage : HighHotelsPageData
    {
        
    }
}