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
        DisplayName = "Content Page",
        GUID = "CDFDAAA0-F9DC-441A-B047-1FAA705DEBB7",
        Description = "Standard content page",
        Order = 19020
        )]    
    [AvailableContentTypes(
      Availability.None)]
    public class ContentPage : GreenfieldArchitectsPageData, IGreenfieldArchitects
    {

        #region Images

        [Display(
            Name = "Page Banner Image (Width : 1400 , Height : 360)",
            GroupName = Global.Tabs.Images,
            Description = "Page Banner Image",
            Order = 1100)]
        public virtual MediaReference PageBanner { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Main Content Area",
           Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}