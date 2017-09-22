using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Commercial.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.B2B,
        DisplayName = "Broker Listing Page",
        GUID = "49d1841c-dcfa-4c8a-9d2f-6f33b8a2ce2e",
        Description = "",
        Order =3030)]    
    public class BrokerListingPage : CommercialPageData , ICommercial
    {
       
    }
}