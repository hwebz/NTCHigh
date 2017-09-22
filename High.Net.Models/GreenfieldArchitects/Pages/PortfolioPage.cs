using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;
using High.Net.Models.GreenfieldArchitects.Blocks;

namespace High.Net.Models.GreenfieldArchitects.Pages
{
    [SiteContentType(GroupName = SiteGroups.GAL,
        DisplayName = "Portfolio Page",
        GUID = "E8616A50-C20E-4CC8-9C6F-4C7CB3EE9458",
        Description = "Portfolio page",
        Order = 19040
        )]    
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(PortfolioListingPage) })]
    public class PortfolioPage : GreenfieldArchitectsPageData, IGreenfieldArchitects
    {

        #region Images

        [Display(
            Name = "Page Banner Image",
            GroupName = Global.Tabs.Images,
            Description = "Page Banner Image",
            Order = 1100)]
        public virtual MediaReference PageBanner { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Description",
            Description = "Description",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}