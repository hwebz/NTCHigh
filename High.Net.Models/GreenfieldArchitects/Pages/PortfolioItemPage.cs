
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
        DisplayName = "Portfolio Item Page",
        GUID = "34191743-53C9-490F-97D3-DEDF87AB7B03",
        Description = "Portfolio Item Page",
        Order = 19050
        )]    
    [AvailableContentTypes(
      Availability.None)]
    public class PortfolioItemPage : GreenfieldArchitectsPageData, IGreenfieldArchitects
    {

        #region Images

        [Display(
           Name = "Page Standard Image (Width : 200, Height : 130)",
           GroupName = Global.Tabs.Images,
           Description = "This image is goes on home page",
           Order = 1110)]
        public virtual MediaReference PageImage { get; set; }

        [Display(
         Name = "Portfolio Images (Width : 1400, Height : 600)",
         Description = "Portfolio Images",
         GroupName = Global.Tabs.Images,
         Order = 1120)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> PortfolioImages { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Project Name",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        public virtual String ProjectName { get; set; }

        [Display(
           Name = "Project facility",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2200)]
        public virtual String facility { get; set; }

        [Display(
           Name = "Project Size",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2300)]
        public virtual String Size { get; set; }

        [Display(
           Name = "Location",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2400)]
        public virtual String Location { get; set; }

        [Display(
          Name = "Service provided",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2500)]
        public virtual String ServiceProvided { get; set; }

        [Display(
           Name = "Description",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2600)]
        public virtual XhtmlString Description { get; set; }

        [Display(
          Name = "Market Segment",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2600)]
        public virtual String MarketSegment { get; set; }

        #endregion
    }
}