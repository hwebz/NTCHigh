using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.Blocks;
using High.Net.Models.NewResidential.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.HighNet.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Content Page",
        GUID = "3f74c94c-ba3b-4a62-99d9-b497a4637831",
        Description = "",
        Order = 10010)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(MeasureListingPage), typeof(ContentPage),
        typeof(CommonListingPage), typeof(LocationPage) ,typeof(SustainabilityDownloadPage), typeof(ReusableComponentPage)})]
    public class ContentPage : HighNetPageData, IHighNet
    {
        #region Content

        public virtual string BannerTitle { get; set; }
        

        [Display(
            Name = "Task Content",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display tasks",
            Order = 1100)]
        [AllowedTypes(typeof(TextColumnBlock), typeof(GoogleMapSingleLocationBlock), typeof(VideoBlock), typeof(TextBlock)
            , typeof(TestimonialSliderBlock), typeof(PhotosGridGalleryBlock), typeof(ImageTextBlock), typeof(NumberListContentBlock), typeof(LogoWallBlock),typeof(CarouselAreaBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}