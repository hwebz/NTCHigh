using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.HighConcrete.Pages
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "VideoItemPage",
        GUID = "cdab0d1c-316f-4a58-8274-15d75f3c3b16",
        Description = "",
        Order=13030)]    
    public class VideoItemPage : HighConcretePageData
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
        public virtual String IntroText { get; set; }

        [Display(
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2400)]
        public virtual XhtmlString Text { get; set; }

        #endregion

    }
}