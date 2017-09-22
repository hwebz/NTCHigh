using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.HighTransit.Blocks;

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HT,Order=16090, 
        DisplayName = "Map Page",
        GUID = "F0873A1D-51EF-4A29-8434-DBF17C20D929", 
        Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(Availability.None)]    
    public class MapPage : HighTransitPageData
    {
        #region Content

        [Display(
           Name = "Page Content Area",
           GroupName = Global.Tabs.Content,
           Description = "Page Content Area",
           Order = 2010)]
        [AllowedTypes(typeof(TextBlock),typeof(ImageTextBlock))]
        public virtual ContentArea PageContentArea { get; set; }

        [Display(
           Name = "Map Location Data",
           GroupName = Global.Tabs.Content,
           Description = "Map Location Data",
           Order = 2020)]
        public virtual MediaReference MapLocationData{ get; set; }

        #endregion
    }
}