using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(
        GroupName = SiteGroups.RO,
        Order = 11090,
        DisplayName = "Find an Space Block",
        GUID = "785BF4A8-3B89-419D-8243-10E3E804D56C",
        Description = "")]
    public class FindASpaceBlock : RolloverBlockData
    {
        #region Images

        [Display(Name = "Property Location Image",
            Description = "Property Location Image",
            GroupName = Global.Tabs.Images,
            Order = 1000)]
        public virtual MediaReference PropertyImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Property Location Name",
            Description = "Property Location Name",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual string PropertyLocationName { get; set; }

        [Display(
            Name = "Location",
            GroupName = Global.Tabs.Content,
            Order = 300)]
        [SelectOne(SelectionFactoryType = typeof(SelectLocation))]
        public virtual string Location { get; set; }

        [Display(
            Name = "Property Search Page",
            Description = "Property Search Page",
            GroupName = Global.Tabs.Content,
            Order = 500)]
        [AllowedTypes(typeof(PropertyListingPage))]
        public virtual PageReference PropertySearchPage { get; set; }

        #endregion
    }
}