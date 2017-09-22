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
        DisplayName = "Common Item Page",
        GUID = "6BB83711-2CB2-4058-B3FC-CC29824EB2DB",
        Description = "Common Item Page",
        Order=10050)]    
    public class CommonItemPage : HighNetPageData, IHighNet
    {
        #region Images

        [Display(
            Name = "Image (Width : 317 , Height : 317)",
            GroupName = Global.Tabs.Images,
            Description = "Image",
            Order = 1100)]
        public virtual MediaReference PageImage { get; set; }

        [Display(
            Name = "Introduction Image (Width : 150 , Height : 80)",
            GroupName = Global.Tabs.Images,
            Description = "Introduction Image",
            Order = 1110)]
        public virtual MediaReference IntroImage { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Introduction Text",
           GroupName = Global.Tabs.Content,
           Description = "Introduction Text",
           Order = 2100)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
           Name = "Page Content",
           GroupName = Global.Tabs.Content,
           Description = "Page Content",
           Order = 2200)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString ItemDescription { get; set; }

        #endregion
    }
}