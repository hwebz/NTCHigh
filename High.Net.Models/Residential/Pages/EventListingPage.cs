using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(
         GroupName = SiteGroups.BR, 
         DisplayName = "Event Listing Page",
         GUID = "a11b5a08-e9be-4610-b4de-405617d6d55f",
         Description = "Page to display list of events",
         Order=5070)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(EventPage) })]
    public class EventListingPage : ResidentialPageData, IResidential
    {
        
    }
}