using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Commercial.Blocks;
using High.Net.Models.Shared.Blocks;

namespace High.Net.Models.Shared.Pages
{
    [SiteContentType(GroupName = SiteGroups.Global, DisplayName = "News Listing",
        Order = 10,
        GUID = "b36ea3cb-f7ac-4b6e-8ee2-2684a10c85a4", Description = "List of News")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(NewsItemPage) })]
    public class NewsListingPage : BasePageData
    {
        #region Images

        [Display(
          Name = "Banner Image (Width : 1140 , Height : 360)",
          GroupName = Global.Tabs.Images,
          Description = "Banner Image",
          Order = 1000)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title of the Page",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Content Area",
            Description = "Main Content Area",
            GroupName = Global.Tabs.Content,
            Order = 2200)]
        [AllowedTypes(typeof(LinkItemBlock), typeof(TextBlock), typeof(ImageGalleryBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
            Name = "News Feeds",
            Description = "News Feeds",
            GroupName = Global.Tabs.Content,
            Order = 2300)]
        public virtual LinkItemCollection NewsFeeds { get; set; }

        [Display(Name = "Announcement Block Content Area",
            Description = "Announcement Block Content Area",
            GroupName = Global.Tabs.Content,
            Order = 2500)]
        [CultureSpecific]
        [AllowedTypes(typeof(High.Net.Models.RealEstateGroup.Blocks.TextBlock))]
        public virtual ContentArea AnnouncementBlockContentArea { get; set; }

        #endregion
    }
}