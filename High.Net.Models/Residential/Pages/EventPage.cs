using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using EPiServer.Web;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.BR,
        DisplayName = "Event Page",
        GUID = "4e6a3977-86a4-480b-9dcd-5648f4312ad9",
        Description = "Event Page",
        Order=5060)]
    [AvailableContentTypes(
       Availability.None)]    
    public class EventPage : ResidentialPageData , IResidential
    {
        #region Image

        [Display(
          Name = "Event Image (Width : 191 , Height : 163)",
          Description = "",
          GroupName = Global.Tabs.Images,
          Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion 
 
        #region Content

            [Display(
             Name = "Event Name",
             Description = "",
             GroupName = Global.Tabs.Content,
             Order = 2100)]
            public virtual String eventName { get; set; }

            [Display(
              Name="Start Date",
              Description = "",
              GroupName = Global.Tabs.Content,
              Order = 2200)]
            [Required]
            public virtual DateTime startDate { get; set; }

            [Display(
             Name = "End Date",
             Description = "",
             GroupName = Global.Tabs.Content,
             Order = 2300)]
            public virtual DateTime endDate { get; set; }

            [Display(
              Name="Days",
              Description = "",
              GroupName = Global.Tabs.Content,
              Order = 2400)]
            public virtual String Days { get; set; }

            [Display(
              Name="Time",
              Description = "Duration of time",
              GroupName = Global.Tabs.Content,
              Order = 2500)]
            public virtual string Time { get; set; }
        
            [Display(
              Name="Location",
              Description = "",
              GroupName = Global.Tabs.Content,
              Order = 2700)]
            public virtual String Location { get; set; }

            [Display(
              Name="Intro Text",
              Description = "",
              GroupName = Global.Tabs.Content,
              Order = 2800)]
            [UIHint(UIHint.LongString)]
            public virtual String introText { get; set; }

            [Display(
             Name = "Description",
             Description = "",
             GroupName = Global.Tabs.Content,
             Order = 2900)]
            public virtual XhtmlString Description { get; set; }

        #endregion

    }
}