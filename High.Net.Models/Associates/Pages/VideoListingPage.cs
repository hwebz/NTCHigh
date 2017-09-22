using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HA, 
        DisplayName = "Video Listing Page",
        GUID = "0d080f76-9cf1-4732-b841-2bfb95f9a1e1",
        Description = "Page to display list of videos",
        Order=7060)]    
    [AvailableContentTypes(Availability.Specific, Include = new [] { typeof(VideoItemPage) })]
    public class VideoListingPage : AssociatesPageData , IAssociates
    {
       
    }
}