using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Project Category Page",
        GUID = "3cbde7b8-a368-4f15-bcdd-6211c81c6632",
        Description = "",
        Order=13050)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectListingPage), typeof(ContentPage) })]
    public class ProjectCategoryPage : HighConcretePageData
    {
        
    }
}