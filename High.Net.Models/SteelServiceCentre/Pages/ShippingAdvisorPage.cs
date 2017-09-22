using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.SteelServiceCentre.Blocks;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Shipping Advisor Page",
        GUID = "d8443366-d87a-4ecd-8f2b-bca7a79c92da",
        Description = "",
        Order=6090)]    
    public class ShippingAdvisorPage : SteelServiceCentrePageData
    {
        #region Content

        [Display(
        Name = "Sidebar Content Area",
        GroupName = Global.Tabs.Content,
        Description = "Add Sidebar Content",
        Order = 2100)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea SidebarContentArea { get; set; }

        #endregion
    }
}