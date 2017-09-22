using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;

namespace High.Net.Models.HighConcrete.Pages
{
    [ContentType(
        GroupName = SiteGroups.HC, 
        DisplayName = "VideoListingPage",
        GUID = "7f4f9a6b-99fd-4dd4-b7e0-8e46332e6074",
        Description = "",
        Order=13040)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(VideoItemPage) })]
    public class VideoListingPage : HighConcretePageData
    {
 
    }
}