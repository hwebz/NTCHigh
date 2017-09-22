using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConstructionCo.Blocks;

namespace High.Net.Models.HighConstructionCo.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCC,
        DisplayName = "Project Category List Page",
        GUID = "754333f5-aef2-42ca-81a5-b72bb7ca63b5",
        Description = "",
        Order=17020)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectListingPage) })]
    public class ProjectCategoryListPage : HighConstructionCoPageData
    {
       
    }
}