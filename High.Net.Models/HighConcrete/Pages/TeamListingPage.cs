using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Team Listing Page",
        GUID = "da015d43-ea70-4073-8b8c-58c573a418ea", 
        Description = "",
        Order=13140)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(TeamItemPage) } )]
    public class TeamListingPage : HighConcretePageData , IHighConcrete
    {
        #region Images

        [Display(
            Name = "Page Icon Image (Width : 50 , Height : 50)",
            GroupName = Global.Tabs.Images,
            Description = "Will use to display listing page",
            Order = 1100)]
        public virtual MediaReference PageIcon { get; set; }

        #endregion
    }
}