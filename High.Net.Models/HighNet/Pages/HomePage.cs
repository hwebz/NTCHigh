using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Constants;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.NewResidential.Blocks;
using High.Net.Models.Shared.Blocks;
using High.Net.Models.Shared.ListPropertyModel;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Validation;
using High.Net.Validation;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Home Page",
        GUID = "1e0eca20-4a7b-4c9f-9c7b-e76e05c1f4d1",
        Description = "Homepage of the site",
        Order = 10001)]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(MeasureListingPage),
            typeof(MeasureListingPage), typeof(NewsListingPage), typeof(CommonListingPage),
            typeof(LocationPage), typeof(ContactUsPage), typeof(SearchPage),typeof(SustainabilityDownloadPage),
            typeof(ReusableComponentPage)})]
    public class HomePage : HighNetPageData, IHome, IHighNet
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 197 , Height : 47)", 
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
            Name = "Site Logo Animate (Width : 197 , Height : 47)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogoAnimated { get; set; }
        #endregion Images

        #region Contact Settings
        [Display(
           Name = "Email ID",
           GroupName = Global.Tabs.ContactSettings,
           Description = "",
           Order = 2410)]
        public virtual String EmailID { get; set; }

        [Display(
            Name = "Contact",
            GroupName = Global.Tabs.ContactSettings,
            Description = "",
            Order = 2500)]
        public virtual String Contact { get; set; }


        [Display(
            Name = "Contact Information",
            GroupName = Global.Tabs.ContactSettings,
            Description = "",
            Order = 2800)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString ContactInfo { get; set; }

        [Display(
           Name = "Contact Button Text",
           GroupName = Global.Tabs.ContactSettings,
           Description = "",
           Order = 2810)]
        public virtual String ContactButtonText { get; set; }

        [Display(
           Name = "Contact Us Link",
           GroupName = Global.Tabs.ContactSettings,
           Description = "",
           Order = 2811)]
        public virtual EPiServer.Url ContactUsLink { get; set; }

        [Display(
          Name = "Contact Us Header",
          GroupName = Global.Tabs.ContactSettings,
          Description = "",
          Order = 2820)]
        public virtual String ContactHeader { get; set; }       

        [Display(
           Name = "Application Form",
           GroupName = Global.Tabs.ContactSettings,
           Description = "Setting to display applicaiton form",
           Order = 3170)]
        public virtual ContentArea ApplicationForm { get; set; }

        [Display(
            GroupName = Global.Tabs.ContactSettings,
            Name = "Solve360 Category Tag",
            Order = 5100)]
        //[Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return Contact; } }

        #endregion

        [Display(Name = "Search Page Url",
           GroupName = Global.Tabs.Content,
           Description = "Search Page Reference",
           Order = 3120)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #region Social

        [Display(
            Name = "Facebook Link",
            GroupName = Global.Tabs.Social,
            Description = "",
            Order = 3100)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
            Name = "Twitter Link",
            GroupName = Global.Tabs.Social,
            Description = "",
            Order = 3200)]
        public virtual EPiServer.Url TwitterLink { get; set; }

        [Display(
            Name = "LinkedIn Link",
            GroupName = Global.Tabs.Social,
            Description = "",
            Order = 3300)]
        public virtual EPiServer.Url LinkedInLink { get; set; }

        [Display(
            Name = "Youtube Link",
            GroupName = Global.Tabs.Social,
            Description = "",
            Order = 3400)]
        public virtual EPiServer.Url YoutubeLink { get; set; }

        #endregion Social

        #region Google Analytics
        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Social,
             Order = 4100)]
        public virtual string GoogleAnalytics { get; set; }

        [Display(
            Name = "Google Tag Manager Id",
            Description = "Google Tag Manager Id",
            GroupName = Global.Tabs.Social,
            Order = 4101)]
        public virtual string GoogleTagManagerId { get; set; }

        #endregion Google Analytics     

        #region New Footer settings

        [Display(
            Name = "Footer Page Link Collection",
           Description = "Footer Page Link Collection",
           GroupName = Global.Tabs.FooterSettings,
           Order = 100)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<LinkCollectionModel>))]
        public virtual IList<LinkCollectionModel> FooterPageLinkCollection { get; set; }

        [Display(
          Name = "Bottom Bar Icon Links",
        Description = "Bottom Bar Icon Links",
        GroupName = Global.Tabs.FooterSettings,
        Order = 90)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<IconLinkModel>))]
        public virtual IList<IconLinkModel> BottomBarIconLinks { get; set; }

        [Display(
            Name = "Footer Logo",
            GroupName = Global.Tabs.FooterSettings,
            Description = "Footer Logo",
            Order = 1100)]
        public virtual MediaReference FooterLogo { get; set; }

        [Display(
          Name = "Extra Information",
          Description = "Extra Information",
          GroupName = Global.Tabs.FooterSettings,
          Order = 80)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationModel>))]
        public virtual IList<TextInformationModel> ExtraInformation { get; set; }

        #endregion Footer setting sharing btw sites

        #region ViewTemplates

        [Display(
            Name = "Site view template",
            GroupName = Global.Tabs.TemplateSettings,
            Order = 5200)]
        [SelectOne(SelectionFactoryType = typeof(SelectHighSiteTemplate))]
        public virtual string SiteViewTemplate { get; set; }

        #endregion

        #region Refactor 
        [Display(
            Name = "Content",
            Description = "Content",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        [AllowedTypes(typeof(ResizableBlock), typeof(AuthorQuoteContainerBlock), typeof(TilesContainerBlock),
     typeof(TextColumnBlock), typeof(VideoBlock), typeof(CarouselBlock), typeof(GoogleMapSingleLocationBlock), typeof(TestimonialSliderBlock), typeof(VideoCarouselBlock))]
        public virtual ContentArea Content { get; set; }

        #endregion

        #region  should be removed
        [Display(
           Name = "Slider (Width : 1400 , Height : 360)",
           Description = "Image Slider",
           GroupName = Global.Tabs.ShouldBeRemoved,
           Order = 1200)]
        [AllowedTypes(typeof(AuthorQuoteBlock))]
        [MaxItemCount(10)]
        public virtual ContentArea Slider { get; set; }

        
        [Display(
            Name = "Carousel Heading",
            GroupName = Global.Tabs.ShouldBeRemoved,
            Description = "",
            Order = 2130)]
        [UIHint(UIHint.LongString)]
        public virtual String CarouselHeading { get; set; }


        [Display(
            Name = "Map Address",
            GroupName = Global.Tabs.ShouldBeRemoved,
            Description = "",
            Order = 2300)]
        public virtual String Address { get; set; }


        [Display(
            Name = "Video Carousel",
            GroupName = Global.Tabs.ShouldBeRemoved,
            Description = "",
            Order = 2700)]
        [AllowedTypes(typeof(VideoBlock))]
        public virtual ContentArea VideoCarousel { get; set; }

         [Display(
            Name = "CopyRight Text",
            GroupName = Global.Tabs.ShouldBeRemoved,
            Description = "",
            Order = 2900)]
        public virtual String CopyRightText { get; set; }


        [Display(Name = "Footer Pages",
          GroupName = Global.Tabs.ShouldBeRemoved,
          Description = "Footer Pages",
          Order = 3010)]
        public virtual LinkItemCollection FooterPages { get; set; }


        [Display(
          Name = "Section Title",
          GroupName = Global.Tabs.ShouldBeRemoved,
          Description = "",
          Order = 3140)]
        public virtual String SectionTitle { get; set; }

        [Display(
          Name = "Section Intro",
          GroupName = Global.Tabs.ShouldBeRemoved,
          Description = "",
          Order = 3150)]
        public virtual String SectionIntro { get; set; }

        [Display(
          Name = "Section Slider",
          GroupName = Global.Tabs.ShouldBeRemoved,
          Description = "",
          Order = 3160)]
        [AllowedTypes(typeof(TestimonialBlock))]
        [MaxItemCount(5)]
        [MinItemCount(3)]
        public virtual ContentArea SectionSlider { get; set; }

        [Display(
           Name = "Tiles",
           GroupName = Global.Tabs.ShouldBeRemoved,
           Description = "Content Area to display tiles",
           Order = 3130)]
        [AllowedTypes(typeof(TweeterFeedBlock), typeof(OtherTilesBlock), typeof(OtherTileBlockWide), typeof(NewsBlock))]
        public virtual ContentArea Tiles { get; set; }
        #endregion

    }
}