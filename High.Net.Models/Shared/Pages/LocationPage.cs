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

namespace High.Net.Models.Shared.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Location Page",
        GUID = "CD51DA90-3EE4-4F13-A60D-107B91659C4A",
        Description = "Location Page",
        Order = 60)]
    [AvailableContentTypes(
       Availability.None)]
    public class LocationPage : BasePageData
    {
        #region Images

        [Display(
           Name = "Banner Image",
           GroupName = Global.Tabs.Images,
           Description = "Size: 1400x430",
           Order = 100)]
        public virtual MediaReference BannerImage { get; set; }


        #endregion

        #region Content

        [Display(
            Name = "Main Content Area",
            Description = "Main Content Area",
            GroupName = Global.Tabs.Content,
            Order = 1110)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
            Name = "Location Data",
            Description = "Location Data",
            GroupName = Global.Tabs.Content,
            Order = 1120)]
        public virtual MediaReference LocationData { get; set; }

        #endregion
    }
}