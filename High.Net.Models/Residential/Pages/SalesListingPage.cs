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
        DisplayName = "Sales Listing Page",
        GUID = "5851c3f1-a667-403f-9b8a-dc0ef9a1bf30",
        Description = "",
        Order=5090)]
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(SalesItemPage) })]
    public class SalesListingPage : ResidentialPageData , IResidential
    {
        
    }
}