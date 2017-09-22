using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.SSC, 
        DisplayName = "ProjectListingPage",
        GUID = "c807f62c-0d92-46bc-a8f3-2c68554869c2",
        Description = "",
        Order = 6050)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectItemPage) })]
    public class ProjectListingPage : SteelServiceCentrePageData
    {
       
    }
}