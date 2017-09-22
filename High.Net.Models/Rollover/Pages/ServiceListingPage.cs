using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Rollover.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.RO,
        DisplayName = "Service Listing Page",
        Order = 11030,
        GUID = "a6651906-e9d7-48ff-9272-6639daccbec5",
        Description = "Service Listing Page")]    
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ServiceItemPage) })]
    public class ServiceListingPage : RolloverPageData
    {
       
    }
}