
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
        DisplayName = "Portfolio Listing Page",
        GUID = "AFE1F323-5DD1-4CEF-8F85-847F1A4D8928",
        Description = "Portfolio Listing Page",
        Order = 19040
        )]    
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(PortfolioItemPage) })]
    public class PortfolioListingPage : GreenfieldArchitectsPageData, IGreenfieldArchitects
    {

        #region Images

        [Display(
            Name = "Page Banner Image (Width : 1400 , Height : 360)",
            GroupName = Global.Tabs.Images,
            Description = "Page Banner Image",
            Order = 1100)]
        public virtual MediaReference PageBanner { get; set; }

        [Display(
           Name = "Page Standard Image (Width : 279 , Height : 181)",
           GroupName = Global.Tabs.Images,
           Description = "This image is goes on home page",
           Order = 1110)]
        public virtual MediaReference PageImage { get; set; }

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