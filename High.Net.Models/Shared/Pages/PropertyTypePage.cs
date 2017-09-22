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

namespace High.Net.Models.Shared.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Property Type",
        GUID = "9c44a983-c521-4271-9e01-47edf4bf1269",
        Description = "Property Item Page",
        Order = 50)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(PropertyPage) })]
    public class PropertyTypePage : BasePageData
    {
        #region Image

        [Display(
           Name = "Page Banner Image",
           GroupName = Global.Tabs.Images,
           Description = "Banner Image",
           Order = 1000)]
        public virtual MediaReference BannerImage { get; set; }

        [Display(
           Name="Page Image",
           GroupName = Global.Tabs.Images,
           Description = "Page Image",
           Order = 1100)]       
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
           Name="Introduction Text",
           GroupName = Global.Tabs.Content,
           Description = "Introduction Text",
           Order = 2110)]
        [UIHint(UIHint.LongString)]
        public virtual string IntroText { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Use Override Content",
          Description = "Use Override Content",
          GroupName = Global.Tabs.Content,
          Order = 2111)]
        public virtual Boolean IsOverrideContent { get; set; }


        [CultureSpecific]
        [Display(
           Name = "Tile Link Override",
           GroupName = Global.Tabs.Content,
           Description = "Tile Link Override",
           Order = 2112)]
        public virtual XhtmlString TileOverlayLink { get; set; }

        #endregion
    }
}