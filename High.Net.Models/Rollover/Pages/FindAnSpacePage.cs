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
        DisplayName = "Find An Space Page",
        Order = 11080,
        GUID = "29AAFFDF-8719-4399-8ADB-4B5759A5109A",
        Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.None)]    
    public class FindAnSpacePage : RolloverPageData
    {

    }
}