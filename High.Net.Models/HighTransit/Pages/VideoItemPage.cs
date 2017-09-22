using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Models.HighTransit.Pages
{
    [ContentType(GroupName = SiteGroups.HT, Order = 16080, DisplayName = "Video Item Page", GUID = "a88938f3-398b-4c6e-a9f0-e7fcc5781d7f", Description = "")]
    [SiteImageUrl]
    public class VideoItemPage : HighTransitPageData
    {
        #region Content

        [Display(Name = "Video Link",
            GroupName = Global.Tabs.Content,
            Description = "Video Link",
            Order = 2010)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [Display(
            Name = "Video Introduction Text",
            Description = "Video Introduction Text",
            GroupName = Global.Tabs.Content,
            Order = 2020)]
        [UIHint(UIHint.LongString)]
        public virtual string VideoIntro { get; set; }

        [Display(
            Name = "Video Description Text",
            Description = "Video Description Text",
            GroupName = Global.Tabs.Content,
            Order = 2020)]
        public virtual XhtmlString VideoDescription { get; set; }

        
        #endregion

    }
}