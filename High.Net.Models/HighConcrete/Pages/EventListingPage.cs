using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.HighConcrete.Pages
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Event Listing Page",
        GUID = "C3559914-482E-42DE-B2FF-08E82F345883",
        Description = "Event Listing Page",
        Order = 13190)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(EventItemPage) })]
    public class EventListingPage : HighConcretePageData
    {

    }
}