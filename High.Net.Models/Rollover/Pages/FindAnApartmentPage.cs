using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Rollover.Blocks;

namespace High.Net.Models.Rollover.Pages
{
    [SiteContentType(GroupName = SiteGroups.RO,
        DisplayName = "Find An Apartment Page",
        Order = 11040,
        GUID = "9BAD332C-D8BE-4FE8-A3D8-D717D93E1FB1",
        Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.None)]    
    public class FindAnApartmentPage : RolloverPageData
    {

    }
}