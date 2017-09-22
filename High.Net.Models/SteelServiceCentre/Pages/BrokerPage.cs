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

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Broker Page",
        GUID = "7373E7CD-A40F-4D84-A2D5-D37620542939",
        Description = "Broker profile page",
        Order = 6040)]
    [AvailableContentTypes(
       Availability.None)]    
    public class BrokerPage : SteelServiceCentrePageData, ISteelServiceCentre
    {
        #region Images

        [Display(
            Name = "Profile Photo (Width : 84 , Height : 111)",
            GroupName = Global.Tabs.Images,
            Description = "Profile Photo",
            Order = 1100)]
        public virtual MediaReference ProfilePhoto { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Team",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2100)]
        public virtual String Team { get; set; }

        [Display(
            Name = "Designation",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual String Designation { get; set; }

        [Display(
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        public virtual XhtmlString Description { get; set; }

        #endregion

        #region Contact

        [Display(
            Name = "Skype Contact",
            GroupName = Global.Tabs.Content,
            Description = "Skype Contact",
            Order = 3100)]
        public virtual String SkypeContact { get; set; }

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