using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.HighConstructionCo.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCC,
        DisplayName = "Project Item Page",
        GUID = "912fc278-caa1-40d8-ad41-f2e6e9fb5d64",
        Description = "",
        Order=17040)]    
    [AvailableContentTypes(Availability.None)]
    public class ProjectItemPage : HighConstructionCoPageData
    {
        #region Images

        [Display(
           Name = "Page Image",
           GroupName = Global.Tabs.Images,
           Description = "Image used on listing page",
           Order = 1100)]
        public virtual MediaReference PageImage { get; set; }

        [Display(
           Name = "Image Slider (Width : 1400 , Height : 600)",
           GroupName = Global.Tabs.Images,
           Description = "",
           Order = 1200)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSlider { get; set; }

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

        [Display(
          Name = "Repeat Market Segment",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2700)]
        public virtual String RepeatMarketSegment { get; set; }

        [Display(
          Name = "Architects",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2800)]
        public virtual String Architects { get; set; }

        #endregion
        
    }
}