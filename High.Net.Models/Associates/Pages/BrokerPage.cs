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
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HA,
        DisplayName = "Broker Page",
        GUID = "e7b62731-f210-4f0c-9350-aba1cb1aaca8",
        Description = "Broker profile page",
        Order = 7030)]
    [AvailableContentTypes(
       Availability.None)]    
    public class BrokerPage : AssociatesPageData, IAssociates
    {
        #region Images

        [Display(
            Name = "Profile Photo (Width = 86, Height = 114)",
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
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "Description",
            Order = 2200)]
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

        [Display(
            Name = "Location",
            GroupName = Global.Tabs.Content,
            Description = "Location",
            Order = 3300)]
        [SelectOne(SelectionFactoryType = typeof(SelectBrokerLocation))]
        public virtual String Location { get; set; }


        #endregion

    }
}