using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Models.HighNet.Pages
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Reusable Component Page",
        GUID = "47deff55-cb9d-4f85-b28b-27c8815ac097",
        Description = "Reusable Component",
        Order = 10070)]
    public class ReusableComponentPage : HighNetPageData, IHighNet
    {
        #region Content

        [Display(
            Name = "Page Content",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display page content",
            Order = 1100)]
//        [AllowedTypes(typeof(HeaderBannerBlock), typeof(FeaturePositionBlock), typeof(ResizableBlock), typeof(CarouselBlock),
//            typeof(GoogleMapBlock), typeof(TestimonialConatinerBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
            Name = "Is google map integreated?",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual bool IsGoogleMapIntegrated { get; set; }

        #endregion
    }
}
