using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Pages
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Measure Item Page",
        GUID = "487f5436-4ca1-439b-a1e9-fc78e87de3ef",
        Description = "",
        Order=10020)]    
    public class MeasureItemPage : HighNetPageData , IHighNet
    {
        #region Images

        [Display(
            Name = "Page Image (Width : 174 , Height : 174)",
            GroupName = Global.Tabs.Images,
            Description = "Page Image",
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        [Display(
            Name = "Page Intro Image (Width : 157 , Height : 157)",
            GroupName = Global.Tabs.Images,
            Description = "Page Intro Image",
            Order = 1200)]
        public virtual MediaReference PageIntroImage { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Intro Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
           Name = "Text",
           GroupName = Global.Tabs.Content,
           Description = "Description",
           Order = 2200)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}