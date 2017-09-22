using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Industries.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HII,
        DisplayName = "Common Listing Page",
        GUID = "9f627a15-11c0-4a6a-b31b-28cc00647ea7",
        Description = "",
        Order=4030)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(CommonItemPage) })]
    public class CommonListingPage : IndustriesPageData, IIndustries
    {
        
    }
}