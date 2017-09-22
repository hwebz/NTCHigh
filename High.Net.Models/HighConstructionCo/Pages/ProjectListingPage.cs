using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.HighConstructionCo.Blocks;

namespace High.Net.Models.HighConstructionCo.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCC,
        DisplayName = "Project Listing Page",
        GUID = "0d36204a-f855-4862-92fa-ccfaf4e23e56",
        Description = "",
        Order=17030)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectItemPage) })]
    public class ProjectListingPage : HighConstructionCoPageData
    {

        #region Content

        [Display(
           Name = "Main Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}