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

namespace High.Net.Models.Industries.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HII,
        DisplayName = "Common Item Page",
        GUID = "4230aae0-f86c-4504-941c-2b03fa3b913f",
        Description = "",
        Order=4040)]    
    public class CommonItemPage : IndustriesPageData , IIndustries
    {
        #region Images

        [Display(
            Name = "Image (Width : 205 , Height : 80)",
            GroupName = Global.Tabs.Images,
            Description = "Image",
            Order = 1100)]
        public virtual MediaReference PageImage { get; set; }

        [Display(
            Name = "Introduction Image (Width : 205 , Height : 80)",
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
        public virtual XhtmlString ItemDescription { get; set; }

        #endregion
    }
}