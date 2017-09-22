using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.Shared.Pages;
using High.Net.Models.RealEstateGroup.Blocks;
using EPiServer.Web;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Shared.Blocks;

namespace High.Net.Models.RealEstateGroup.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.REG,
        DisplayName = "Real Estate Matters Page",
        Order = 8060,
        GUID = "0F8AEB94-0447-468C-9C6B-EABE93ABA3B2",
        Description = "Real Estate Matters Page")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage) })]
    public class RealEstateMattersPage : RealEstateGroupPageData
    {
        #region Images

        [Display(
           Name = "Banner Image (Width : 1400 , Height : 360)",
           GroupName = Global.Tabs.Images,
           Description = "Size: 1400x430",
           Order = 100)]
        public virtual MediaReference BannerImage { get; set; }

        [Display(Name = "Video Item Links",
           GroupName = Global.Tabs.Images,
           Description = "Video Item Links",
           Order = 110)]
        public virtual LinkItemCollection VideoItemLinks { get; set; }

        [Display(
           Name = "Related Content Image (Width : 166 , Height : 156)",
           GroupName = Global.Tabs.Images,
           Description = "Size: 166x156",
           Order = 120)]
        public virtual MediaReference RelatedContentImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Top Content Area",
            Description = "Top Content Area",
            GroupName = Global.Tabs.Content,
            Order = 130)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea TopContentArea { get; set; }

        [Display(
        Name = "Related Content Heading",
        Description = "Related Content Heading",
        GroupName = Global.Tabs.Content,
        Order = 140)]
        public virtual string RelatedContentHeading { get; set; }

        [Display(
            Name = "Related Content Description",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 150)]
        public virtual XhtmlString RelatedContentDescription { get; set; }

        [Display(Name = "Announcement Block Content Area",
            Description = "Announcement Block Content Area",
            GroupName = Global.Tabs.Content,
            Order = 160)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea AnnouncementBlockContentArea { get; set; }

        [Display(
           Name = "Related Content Video Url",
           GroupName = Global.Tabs.Images,
           Description = "",
           Order = 170)]
        public virtual EPiServer.Url RelatedContentVideoUrl { get; set; }

        [Display(
        Name = "Banner Text",
        Description = "Banner Text",
        GroupName = Global.Tabs.Content,
        Order = 180)]
        public virtual string BannerText { get; set; }

        #endregion


    }
}
