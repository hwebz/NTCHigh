using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConcrete.Blocks;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Content Page",
        GUID = "cc2d5a3b-c8fd-4b93-9c61-f095ad18dd20",
        Description = "",
        Order=13010)]    
    [AvailableContentTypes(Availability.Specific,
       Include = new[] { typeof(FindRepresentativePage), typeof(ContentPage), typeof(HowAreWeDoingPage), typeof(TeamListingPage), typeof(OnlineCoursesFormPage), typeof(NewsLetterPage),
           typeof(ColorSelectorListingPage) })]
    public class ContentPage : LeftNavigationPage
    {
        #region Content

        [Display(
           Name = "Main Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageGalleryBlock), typeof(ExpandCollapseBlock), typeof(PopupBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}