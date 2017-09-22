using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Constants;
using High.Net.Models.Residential.Blocks;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using System;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(GroupName = SiteGroups.BR,
        DisplayName = "Home Page",
        GUID = "dc1acba9-d949-46c4-bcae-b005c577ef4b",
        Description = "Home page of the website",
        Order = 5001)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage), typeof(EventListingPage), typeof(ReviewListingPage),
        typeof(StandardPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(SalesCategoryPage), typeof(ContactUsPage),
        typeof(ScheduleTourPage), typeof(ApplyNowPage), typeof(SearchPage)})]
    public class HomePage : ResidentialPageData, IHome, IResidential
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 297 , Height : 81)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
           Name = "Fav Icon",
           GroupName = Global.Tabs.Images,
           Description = "Fav Icon",
           Order = 1200)]
        public virtual MediaReference FavIcon { get; set; }

        #endregion Images

        #region Slider

        [Display(
          Name = "Image Carousel (Width : 1400 , Height : 360)",
          Description = "Size: 1400x360",
          GroupName = Global.Tabs.Sliders,
          Order = 1200)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageCarousel { get; set; }

        #endregion Slider

        #region Content

        [Display(
          Name = "Content Area",
          Description = "",
          GroupName = Global.Tabs.Content,
          Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(TextBlock), typeof(ImageTextBlock) })]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
         Name = "Office Hours",
         Description = "Office Hours",
         GroupName = Global.Tabs.Content,
         Order = 2200)]
        public virtual XhtmlString OfficeHours { get; set; }

        [Display(
         Name = "High Associates Link",
         Description = "High Associates",
         GroupName = Global.Tabs.Content,
         Order = 2300)]
        public virtual MediaLink HighAssociates { get; set; }

        [Display(
         Name = "Copy Right Text",
         Description = "",
         GroupName = Global.Tabs.Content,
         Order = 2400)]
        public virtual String CopyRightText { get; set; }

        [Display(
         Name = "Email Us Link",
         Description = "Email Us Link",
         GroupName = Global.Tabs.Content,
         Order = 2500)]
        public virtual PageReference EmailUsLink { get; set; }

        [Display(
         Name = "Apply Now Link",
         Description = "Apply Now Link",
         GroupName = Global.Tabs.Content,
         Order = 2600)]
        public virtual PageReference ApplyNowLink { get; set; }

        [Display(
           Name = "Schedule Tour Property Email",
           Description = "Schedule Tour Property Email",
           GroupName = Global.Tabs.EmailSetting,
           Order = 2700)]
        public virtual String ScheduleTourPropertyEmail { get; set; }

        [Display(
           Name = "Schedule Tour Property Subject",
           Description = "Schedule Tour Property Subject",
           GroupName = Global.Tabs.EmailSetting,
           Order = 2700)]
        public virtual String ScheduleTourPropertySubject { get; set; }

        [Display(
           Name = "Schedule Tour Property Body",
           Description = "Schedule Tour Property Body",
           GroupName = Global.Tabs.EmailSetting,
           Order = 2700)]
        public virtual String ScheduleTourPropertyBody { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 2800)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion Content

        #region Contact

        [Display(
          Name = "Contact No",
          Description = "Contact No",
          GroupName = Global.Tabs.EmailSetting,
          Order = 3100)]
        [CultureSpecific]
        public virtual String ContactNo { get; set; }

        [Display(
          Name = "Address",
          Description = "Address",
          GroupName = Global.Tabs.Content,
          Order = 3200)]
        [CultureSpecific]
        public virtual String Address { get; set; }

        #endregion Contact

        #region Url

        [Display(
          Name = "Footer Links",
          Description = "Footer Links",
          GroupName = Global.Tabs.Content,
          Order = 4100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea FooterLinkItems { get; set; }

        [Display(
          Name = "Footer Navigation Links",
          Description = "Footer Navigation Links",
          GroupName = Global.Tabs.Content,
          Order = 4200)]
        public virtual LinkItemCollection FooterNavigationItems { get; set; }

        #endregion Url

        #region Social

        [Display(
             Name = "Facebook Link",
             GroupName = Global.Tabs.Social,
             Description = "Facebook Link",
             Order = 5100)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
            Name = "Google Location Link",
            GroupName = Global.Tabs.Social,
            Description = "Google Location Url",
            Order = 5300)]
        [UIHint(UIHint.LongString)]
        public virtual String LocationUrl { get; set; }

        [Display(
            Name = "Google Location Direction Link",
            GroupName = Global.Tabs.Social,
            Description = "Google Location Direction Url",
            Order = 5400)]
        [UIHint(UIHint.LongString)]
        public virtual String LocationDirectionUrl { get; set; }

        #endregion Social

        #region Rollover

        [Display(
          Name = "Site Image (Width : 360 , Height : 250)",
          GroupName = Global.Tabs.Rollover,
          Description = "Site Logo",
          Order = 6100)]
        public virtual MediaReference SiteImage { get; set; }

        [Display(
         Name = "Site Introduction",
         Description = "Site Introduction",
         GroupName = Global.Tabs.Rollover,
         Order = 6200)]
        [UIHint(UIHint.Textarea)]
        public virtual String SiteIntroduction { get; set; }

        [Display(
         Name = "Bedrooms Count",
         Description = "Bedrooms Count",
         GroupName = Global.Tabs.Rollover,
         Order = 6300)]
        public virtual String BedCount { get; set; }

        [Display(
         Name = "Bath Count",
         Description = "Bath Count",
         GroupName = Global.Tabs.Rollover,
         Order = 6400)]
        public virtual String BathCount { get; set; }

        [Display(
         Name = "Location",
         Description = "Location",
         GroupName = Global.Tabs.Rollover,
         Order = 6500)]
        [SelectOne(SelectionFactoryType = typeof(SelectRolloverLocation))]
        public virtual string Location { get; set; }

        #endregion Rollover

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 7100)]
        public virtual string GoogleAnalytics { get; set; }

        #endregion Google Analytics

        #region Email

        [Display(
             Name = "Share Property Subject",
             GroupName = Global.Tabs.EmailSetting,
             Description = "Share Property Subject",
             Order = 10000)]
        public virtual string SharePropertySubject { get; set; }

        [Display(
             Name = "Share Property Mail Body",
             GroupName = Global.Tabs.EmailSetting,
             Description = "Share Property Mail Body",
             Order = 10100)]
        public virtual XhtmlString SharePropertyMailBody { get; set; }

        [Display(
             Name = "Share Property Thank you Message",
             GroupName = Global.Tabs.EmailSetting,
             Description = "Share Property Thank you Message",
             Order = 10200)]
        [UIHint(UIHint.LongString)]
        public virtual string SharePropertyThankYouMessage { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNo; } }

        #endregion Email
    }
}