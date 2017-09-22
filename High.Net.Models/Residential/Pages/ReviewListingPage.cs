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
    [SiteContentType(GroupName = SiteGroups.BR,
        DisplayName = "ReviewListingPage",
        GUID = "49cb7cb8-5ce1-4283-bb60-82d57c020e46",
        Description = "Page For Review Listing",
        Order=5050
        )]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ReviewPage) })]
    public class ReviewListingPage : ResidentialPageData, IResidential
    {
        
    }
}