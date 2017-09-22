using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "Project Category Page",
        GUID = "300d51c4-fae3-4f69-98cb-50d70bfe7191",
        Description = "",
        Order=18010)]    
    [AvailableContentTypes(Availability.Specific, Include= new[] { typeof(ProjectListingPage) })]
    public class ProjectCategoryPage : HighSteelStructurePageData
    {
        
    }
}