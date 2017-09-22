using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighHotels.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HH,
        DisplayName = "Portfolio List Page",
        GUID = "A4E0F6E0-1ED8-4475-BD88-B795E2F4A587",
        Description = "",
        Order=12060)]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(PortfolioPage) })]
    public class PortfolioListPage : HighHotelsPageData
    {
       
    }
}