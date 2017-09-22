using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Rollover.Pages
{
    [ContentType(GroupName = SiteGroups.RO,Order = 11060, DisplayName = "Opportunity Listing Page", GUID = "67ace159-b756-483e-bfa9-08a141ae3a8a", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(OpportunityItemPage) })]
    
    public class OpportunityListingPage : RolloverPageData
    {

    }
}