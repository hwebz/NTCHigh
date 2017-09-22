using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Team Item Page",
        GUID = "f7d6b57a-7679-4062-8734-316259232633",
        Description = "",
        Order=13150)]    
    [AvailableContentTypes(Availability.None)]
    public class TeamItemPage : HighConcretePageData , IHighConcrete
    {
        #region Images

        [Display(
            Name = "Profile Photo (Width : 142 , Height : 181)",
            GroupName = Global.Tabs.Images,
            Description = "Profile Photo",
            Order = 1100)]
        public virtual MediaReference ProfilePhoto { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Designation",
            GroupName = Global.Tabs.Content,
            Description = "Description",
            Order = 2100)]
        public virtual String Designation { get; set; }

        [Display(
            Name = "Name Of The Person",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual String PersonName { get; set; }

        [Display(
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "Description",
            Order = 2300)]
        public virtual XhtmlString Description { get; set; }

        #endregion

        #region Contact

        [Display(
            Name = "Telephone Contact",
            GroupName = Global.Tabs.Content,
            Description = "Skype Contact",
            Order = 3100)]
        public virtual String TelephoneContact { get; set; }

        [Display(
            Name = "Mobile Contact",
            GroupName = Global.Tabs.Content,
            Description = "Skype Contact",
            Order = 3200)]
        public virtual String MobileContact { get; set; }

        [Display(
            Name = "Email ID",
            GroupName = Global.Tabs.Content,
            Description = "Email ID",
            Order = 3200)]
        public virtual String EmailAddress { get; set; }

        #endregion
    }
}