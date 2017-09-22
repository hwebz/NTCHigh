using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "Video Item Page",
        GUID = "af36b93a-e79b-4b4e-98be-e6b4411ed68a",
        Description = "",
        Order=18050)]    
    public class VideoItemPage : HighSteelStructurePageData
    {

        #region Content

        [Display(
            Name = "Video Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2100)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Intro text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        [UIHint(UIHint.LongString)]
        public virtual XhtmlString IntroText { get; set; }

        [Display(
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2400)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}