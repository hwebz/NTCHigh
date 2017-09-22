using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HA,
        DisplayName = "Services Listing Page",
        GUID = "89725e9c-24d9-4c36-8c39-0f6c9faf5076",
        Description = "List of all services",
        Order = 7020)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(High.Net.Models.HighAppraisal.Pages.HomePage),typeof(ContentPage), typeof(BrokerListPage), })]    
    public class ServiceListPage : AssociatesPageData, IAssociates
    {
        
    }
}