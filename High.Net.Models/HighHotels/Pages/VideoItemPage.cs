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

namespace High.Net.Models.HighHotels.Pages
{
    [ContentType(GroupName = SiteGroups.HH,
        Order = 12040, DisplayName = "Video Item Page", GUID = "36ec07c2-c463-4bb9-af59-6992d8e4ff99", Description = "")]
    public class VideoItemPage : HighHotelsPageData
    {

        #region Content

        [Display(Name = "Video Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1000)]
        public virtual String Heading { get; set; }

        [Display(Name = "Video Link",
            GroupName = Global.Tabs.Content,
            Description = "Video Link",
            Order = 1010)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text of the block",
            GroupName = Global.Tabs.Content,
            Order = 1020)]
        [UIHint(UIHint.LongString)]
        public virtual string IntroText { get; set; }

        [Display(Name = "Video Description",
            GroupName = Global.Tabs.Content,
            Description = "Video Link",
            Order = 1010)]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}