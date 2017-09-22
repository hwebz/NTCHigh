using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConcrete.Blocks;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Project Listing Page", 
        GUID = "3001e1fa-6079-4915-af19-d6afa63939a0",
        Description = "",
        Order=13060)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectItemPage) , typeof(ProjectListingPage) , typeof(ContentPage) })]
    public class ProjectListingPage : LeftNavigationPage
    {
        
    }
}