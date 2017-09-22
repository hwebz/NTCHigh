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
        DisplayName = "Service Page",
        GUID = "90EE531B-E7FE-468A-BC9F-A6ED80B25710",
        Description = "Service Page",
        Order = 19030
        )]    
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ServicePage) })]
    public class ServicePage : GreenfieldArchitectsPageData, IGreenfieldArchitects
    {

        #region Images

        [Display(
            Name = "Page Banner Image (Width : 1400, Height : 350)",
            GroupName = Global.Tabs.Images,
            Description = "Page Banner Image",
            Order = 1000)]
        public virtual MediaReference PageBanner { get; set; }

        [Display(
            Name = "Page Standard Image (Width : 276, Height : 209)",
            GroupName = Global.Tabs.Images,
            Description = "This image is goes on home page",
            Order = 1010)]
        public virtual MediaReference PageImage { get; set; }

        [Display(
            Name = "Page Icon Image (Width : 87, Height : 87)",
            GroupName = Global.Tabs.Images,
            Description = "This image is goes on home page",
            Order = 1020)]
        public virtual MediaReference PageIcon { get; set; }

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