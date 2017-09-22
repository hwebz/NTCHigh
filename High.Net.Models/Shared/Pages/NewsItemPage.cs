using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.Shared.Pages
{
    [ContentType(GroupName = SiteGroups.Global,
        DisplayName = "News Item",
        Order = 20,
        GUID = "f770fcfd-fee2-40ea-b2a8-efc72bc99801",
        Description = "Single news in detail")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.None)]
    public class NewsItemPage : BasePageData
    {

        #region Image

        [Display(
            Name = "News Image",
            Description = "",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference NewsImage { get; set; }

        [Display(
          Name = "Banner Image",
          GroupName = Global.Tabs.Images,
          Description = "Banner Image",
          Order = 1200)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "News Image Quote",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2000)]
        public virtual String ImageQuote { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "News Title",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "News Highlight",
            Description = "Short news introdcution (will be display on listing page)",
            GroupName = Global.Tabs.Content,
            Order = 2200)]
        public virtual XhtmlString NewsHighlight { get; set; }

        [CultureSpecific]
        [Display(
            Name = "News content",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2300)]
        public virtual XhtmlString NewsContent { get; set; }


        [CultureSpecific]
        [UIHint("DateOnly")]
        [Display(
            Name = "Release Date",
            Description = "News release date",
            GroupName = Global.Tabs.Content,
            Order = 2400)]
        public virtual DateTime PostedDate { get; set; }

        [Display(
            Name = "Hide On Parent Site",
            Description = "Hide On Parent Site",
            GroupName = Global.Tabs.Content,
            Order = 2500)]
        public virtual Boolean HideOnParentSite { get; set; }


        [Display(
          Name = "Featured News",
          Description = "Is Featured News",
          GroupName = Global.Tabs.Content,
          Order = 2600)]
        public virtual Boolean FeaturedNews { get; set; }

        #endregion
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            base.VisibleInMenu = false;
            PostedDate = DateTime.Now;
            StopPublish = DateTime.Now.AddYears(2);

        }
    }
}