using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.Rollover.Pages
{
    [ContentType(GroupName=SiteGroups.RO,Order=11070, DisplayName = "Opportunity Item Page", GUID = "558d7043-6f39-41e6-bde6-9f47477e1bbf", Description = "")]
    public class OpportunityItemPage : RolloverPageData
    {
        #region Image

        [Display(Name = "Portfolio Image (Width : 200 , Height : 200)",
          GroupName = Global.Tabs.Images,
          Description = "Portfolio Image",
          Order = 1010)]
        public virtual MediaReference PortfolioImage { get; set; }

        [Display(
           Name = "Slider Images (Width : 757 , Height : 328)",
           Description = "Slider Image Items",
           GroupName = Global.Tabs.Sliders,
           Order = 1020)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Slider { get; set; }

        #endregion

        #region Content

        [Display(Name = "Title",
          GroupName = Global.Tabs.Content,
          Description = "Title",
          Order = 2010)]
        public virtual string Title { get; set; }


        [Display(Name = "Sub Title",
          GroupName = Global.Tabs.Content,
          Description = "Sub Title",
          Order = 2020)]
        public virtual string SubTitle { get; set; }


        [Display(Name = "Property Status",
        GroupName = Global.Tabs.Content,
        Description = "Property Status",
        Order = 2030)]
        public virtual string PropertyStatus { get; set; }

        [Display(Name = "Intro Text",
          GroupName = Global.Tabs.Content,
          Description = "Intro Text",
          Order = 2040)]
        public virtual XhtmlString IntroText { get; set; }

        [Display(Name = "Property Description",
          GroupName = Global.Tabs.Content,
          Description = "Property Description",
          Order = 2050)]
        public virtual XhtmlString PropertyDescription { get; set; }

        #endregion

        #region PropertyDetails


        [Display(Name = "Total SF",
          GroupName = Global.Tabs.Content,
          Description = "Total SF",
          Order = 3010)]
        public virtual string TotalSF { get; set; }


        [Display(Name = "Opened Year",
          GroupName = Global.Tabs.Content,
          Description = "Opened in year",
          Order = 3020)]
        public virtual string OpenedYear { get; set; }


        [Display(Name = "Availability",
          GroupName = Global.Tabs.Content,
          Description = "Availability",
          Order = 3030)]
        public virtual string Availability { get; set; }

        #endregion
    }
}