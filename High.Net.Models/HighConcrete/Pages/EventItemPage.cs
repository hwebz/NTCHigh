using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.HighConcrete.Pages
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Event Item Page",
        GUID = "6E36E805-49C6-4411-A7A6-25903822CE7F",
        Description = "Event Item Page",
        Order = 13180)]
    public class EventItemPage : HighConcretePageData
    {
        #region Content

        [Display(
           Name = "Start Date",
           GroupName = Global.Tabs.Content,
           Description = "Start date of event",
           Order = 1100)]
        public virtual DateTime StartDate { get; set; }

        [Display(
           Name = "End Date",
           GroupName = Global.Tabs.Content,
           Description = "End date if different than starting date",
           Order = 1120)]
        public virtual DateTime EndDate { get; set; }

        [Display(
           Name = "Event Title",
           GroupName = Global.Tabs.Content,
           Description = "The title of this event",
           Order = 1130)]
        public virtual String EventTitle { get; set; }

        [Display(
           Name = "Photo",
           GroupName = Global.Tabs.Content,
           Description = "Please select an image to accompany this event",
           Order = 1140)]
        public virtual MediaReference Photo { get; set; }

        [Display(
           Name = "Short Description",
           GroupName = Global.Tabs.Content,
           Description = "Brief description to display when viewing event outside of the full details page",
           Order = 1150)]
        public virtual XhtmlString ShortDescription { get; set; }

        [Display(
           Name = "FullDescription",
           GroupName = Global.Tabs.Content,
           Description = "Full description displayed on event details page",
           Order = 1160)]
        public virtual XhtmlString FullDescription { get; set; }

        [Display(
           Name = "Location",
           GroupName = Global.Tabs.Content,
           Description = "The location of this event",
           Order = 1160)]
        public virtual String Location { get; set; }

        #endregion

        #region Optional Contact Information

        [Display(
           Name = "Contact Name",
           GroupName = Global.Tabs.Content,
           Description = "Contact Name",
           Order = 1200)]
        public virtual String ContactName { get; set; }

        [Display(
           Name = "Contact Phone Number",
           GroupName = Global.Tabs.Content,
           Description = "Contact Phone Number",
           Order = 1210)]
        public virtual String ContactPhoneNumber { get; set; }

        [Display(
           Name = "Contact Email",
           GroupName = Global.Tabs.Content,
           Description = "Contact Email",
           Order = 1220)]
        public virtual String ContactEmail { get; set; }

        [Display(
           Name = "Web Site",
           GroupName = Global.Tabs.Content,
           Description = "Web Site",
           Order = 1230)]
        public virtual EPiServer.Url WebSite { get; set; }

        #endregion
    }
}