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
        DisplayName = "Sales Category Page",
        GUID = "7c196513-d1f7-45df-bed8-4252349e5472", 
        Description = "",
        Order = 5080)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(SalesListingPage) })]
    public class SalesCategoryPage : ResidentialPageData , IResidential
    {
        
    }
}