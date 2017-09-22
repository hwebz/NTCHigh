using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Models.SteelServiceCentre.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(GroupName = SiteGroups.SSC, 
        DisplayName = "VideoItemPage", 
        GUID = "ba33a408-4b8b-484a-943b-8492a1770092",
        Description = "",
        Order=6070)]    
    public class VideoItemPage : SteelServiceCentrePageData
    {
        #region Content

        [Display(
            Name = "Video Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1100)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Video Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [Display(
            Name = "Intro Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1300)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
            Name = "Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1400)]
        public virtual XhtmlString Text { get; set; }

        [Display(
            Name = "Sidebar Content Area",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1500)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea SidebarContentArea { get; set; }

        #endregion

        
    }
}