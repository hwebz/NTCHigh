using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;
using ImageVault.EPiServer;

namespace High.Net.Models.HighAppraisal.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HAPP,
        DisplayName = "Video Item Page",
        GUID = "910a486c-3004-4959-a1ea-7488eaeacad7",
        Description = "",
        Order=14040)]    
    public class VideoItemPage : HighAppraisalPageData , IHighAppraisal
    {
        #region Content

        [Display(
          Name = "Heading",
          Description = "Heading for page",
          GroupName = Global.Tabs.Content,
          Order = 1100)]
        public virtual String Heading { get; set; }

        [Display(
          Name = "Video Link",
          Description = "Livk for video",
          GroupName = Global.Tabs.Content,
          Order = 1200)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [Display(
          Name = "Intro Text",
          Description = "Information about video",
          GroupName = Global.Tabs.Content,
          Order = 1300)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
          Name = "Video Details",
          Description = "Information about video",
          GroupName = Global.Tabs.Content,
          Order = 1400)]
        public virtual XhtmlString VideoDetails { get; set; }

        #endregion
    }
}