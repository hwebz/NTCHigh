using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;

namespace High.Net.Models.RealEstateGroup.Pages
{
    [ContentType(
        GroupName = SiteGroups.REG, 
        DisplayName = "Profile Listing Page",
        GUID = "45adc880-3fba-4055-b043-d072d825ba4f", 
        Description = "",
        Order = 8030)]    
    [AvailableContentTypes(Availability.Specific , Include = new []{ typeof(ProfileItemPage) } )]
    public class ProfileListingPage : RealEstateGroupPageData
    {
        
    }
}