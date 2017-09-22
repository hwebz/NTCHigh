using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Team Type Listing Page", 
        GUID = "fe9445df-fbed-4adb-9dc1-6a2b9beeb558", 
        Description = "",
        Order=13120)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(TeamListingPage) } )]
    public class TeamTypeListingPage : HighConcretePageData , IHighConcrete
    {
       
    }
}