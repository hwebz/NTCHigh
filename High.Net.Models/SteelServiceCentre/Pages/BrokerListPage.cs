using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Associates.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(GroupName = SiteGroups.SSC,
        DisplayName = "Brokers List Page",
        GUID = "D48928B6-D6D3-46E2-9340-04534486C99A",
        Description = "Brokers List Page",
        Order = 6030)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(BrokerPage) })]    
    public class BrokerListPage : SteelServiceCentrePageData, ISteelServiceCentre
    {
       
    }
}