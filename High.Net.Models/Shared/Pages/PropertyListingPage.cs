using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.Shared.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Property Listing",
        GUID = "530E2045-D925-49A1-B512-E210FD97A8A1",
        Description = "Listing Page of Property Item",
        Order = 30)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(PropertyTypePage) })]
    public class PropertyListingPage : BasePageData
    {
        #region Images

        [Display(
           Name = "Page Banner Image",
           GroupName = Global.Tabs.Images,
           Description = "Banner Image",
           Order = 1100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Property declaration",
            Description = "Property declaration",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual XhtmlString PropertyDeclaration { get; set; }

        [Display(
            Name = "Search all corporate center only",
            Description = "If checked then result will be all corporate center only.",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual bool IsAllCorporateCenterOnly { get; set; }

        #endregion
    }
}