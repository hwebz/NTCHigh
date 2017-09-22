using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Associates.Blocks;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using System;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(GroupName = SiteGroups.HA,
        DisplayName = "Home Page",
        GUID = "377ae4d1-eee2-4469-b674-c2255f80e021",
        Description = "Home page of website",
        Order = 7001)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(High.Net.Models.HighAppraisal.Pages.HomePage), typeof(ContentPage), typeof(ServiceListPage), typeof(VideoListingPage),
            typeof(PropertyListingPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(High.Net.Models.Shared.Pages.SearchPage),
            typeof(NewsListingPage), typeof(LocationPage) , typeof(SignUpPage) })]
    public class HomePage : AssociatesPageData, IHome, IAssociates
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 317 , Height : 57)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        #endregion Images

        #region Slider

        [Display(
          Name = "Image Slider (Width : 1400 , Height : 360)",
          Description = "Size: 1400x360",
          GroupName = Global.Tabs.Sliders,
          Order = 1200)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSliders { get; set; }

        #endregion Slider

        #region Content

        [Display(
          Name = "Contact Address Content Area",
          Description = "Contact Area",
          GroupName = Global.Tabs.Content,
          Order = 2200)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea Contact { get; set; }

        [Display(
          Name = "MainContent Content Area",
          Description = "Content Area",
          GroupName = Global.Tabs.Content,
          Order = 2300)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
            Name = "Footer Pages",
            GroupName = Global.Tabs.Content,
            Description = "Miscellaneous Footer pages",
            Order = 2400)]
        public virtual LinkItemCollection FooterPages { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 2500)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        [Display(Name = "Property Page link",
            GroupName = Global.Tabs.Content,
            Description = "Link of the property page",
            Order = 2600)]
        [AllowedTypes(typeof(PropertyListingPage))]
        public virtual PageReference PropertyPageLink { get; set; }

        [Display(Name = "Brokerage Listing Page link",
            GroupName = Global.Tabs.Content,
            Description = "Link of the Brokerage list page",
            Order = 2700)]
        [AllowedTypes(typeof(BrokerListPage))]
        public virtual PageReference BrokersPageLink { get; set; }

        [Display(Name = "Videos Page link",
            GroupName = Global.Tabs.Content,
            Description = "Link of the Brokerage list page",
            Order = 2800)]
        [AllowedTypes(typeof(VideoListingPage))]
        public virtual PageReference VideosPageLink { get; set; }

        [Display(Name = "Services Page link",
            GroupName = Global.Tabs.Content,
            Description = "Link of the Services page",
            Order = 2900)]
        [AllowedTypes(typeof(ServiceListPage))]
        public virtual PageReference ServicesPageLink { get; set; }

        #endregion Content

        #region Contact

        [Display(
         Name = "Lancaster Contact No.",
         Description = "Lancaster Contact No. (Please specify mutiple with ',' Separator)",
         GroupName = Global.Tabs.Content,
         Order = 3100)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual String LancasterNo { get; set; }

        [Display(
         Name = "Harrisburg Contact No.",
         Description = "Harrisburg  Contact No. (Please specify mutiple with ',' Separator)",
         GroupName = Global.Tabs.Content,
         Order = 3100)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual String HarrisburgNo { get; set; }

        #endregion Contact

        #region Social

        [Display(
         Description = "Facebook Link",
         GroupName = Global.Tabs.Content,
         Order = 4100)]
        [CultureSpecific]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
         Description = "Youtube Link",
         GroupName = Global.Tabs.Content,
         Order = 4110)]
        [CultureSpecific]
        public virtual EPiServer.Url YouTubeLink { get; set; }

        [Display(
         Description = "LinkedIn Link",
         GroupName = Global.Tabs.Content,
         Order = 4120)]
        [CultureSpecific]
        public virtual EPiServer.Url LinkedInLink { get; set; }

        [Display(
          Description = "Help Page Link",
          GroupName = Global.Tabs.Content,
          Order = 4200)]
        [CultureSpecific]
        public virtual EPiServer.Url HelpPageLink { get; set; }

        #endregion Social

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 5100)]
        [CultureSpecific]
        public virtual string GoogleAnalytics { get; set; }

        [Display(Name = "Contact No",
         GroupName = Global.Tabs.EmailSetting,
         Description = "Contact No",
         Order = 2300)]
        [ScaffoldColumn(false)]
        public virtual string ContactNo { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNo; } }

        #endregion Google Analytics
    }
}