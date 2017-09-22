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
        DisplayName = "Home Page",
        Order = 8010,
        GUID = "7AC055F6-CB16-4A01-8CC8-1717B3D98129",
        Description = "Real Estate Home Page")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(High.Net.Models.Rollover.Pages.HomePage), typeof(ContentPage), typeof(NewsListingPage),
           typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(PropertyListingPage), typeof(SearchPage), typeof(LocationPage) , typeof(ProjectPortfolioListingPage) , typeof(ContactUsPage), typeof(RealEstateMattersPage) })]
    public class HomePage : RealEstateGroupPageData, IHome, IRealEstateGroup
    {
        #region Images

        [Display(Name = "Site Logo (Width : 327 , Height : 43)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(Name = "Image Slider (Width : 1140 , Height : 360)",
         Description = "Image Slider",
         GroupName = Global.Tabs.Images,
         Order = 1120)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSliders { get; set; }

        #endregion

        #region Contact

        [Display(Name = "Contact Address",
        GroupName = Global.Tabs.Content,
        Description = "Contact Address",
        Order = 2110)]
        [UIHint(UIHint.LongString)]
        public virtual string ContactAddress { get; set; }

        [Display(Name = "Phone Number",
           GroupName = Global.Tabs.Content,
           Description = "Phone Number",
           Order = 2120)]
        public virtual string PhoneNumber { get; set; }

        [Display(Name = "Email ID",
           GroupName = Global.Tabs.Content,
           Description = "Email ID",
           Order = 2130)]
        public virtual string EmailID { get; set; }

        #endregion

        #region Content

        [Display(Name = "Top Content Area",
            Description = "Top Content Area",
            GroupName = Global.Tabs.Content,
            Order = 3110)]
        [CultureSpecific]
        [AllowedTypes(typeof(AssetsBlock), typeof(MainBlock))]
        public virtual ContentArea TopContentArea { get; set; }

        [Display(Name = "Assets Content Area",
            Description = "Assets Content Area",
            GroupName = Global.Tabs.Content,
            Order = 3130)]
        [CultureSpecific]
        [AllowedTypes(typeof(AssetsBlock), typeof(MainBlock))]
        public virtual ContentArea AssetsContentArea { get; set; }

        [Display(Name = "Bottom Content Area",
            Description = "Bottom Content Area",
            GroupName = Global.Tabs.Content,
            Order = 3140)]
        [CultureSpecific]
        [AllowedTypes(typeof(AssetsBlock), typeof(MainBlock))]
        public virtual ContentArea BottomContentArea { get; set; }

        [Display(Name = "Footer Pages",
            GroupName = Global.Tabs.Content,
            Description = "Miscellaneous pages",
            Order = 3150)]
        public virtual LinkItemCollection FooterPages { get; set; }


        [Display(Name = "Copyright Text",
            GroupName = Global.Tabs.Content,
            Description = "Copyright Text",
            Order = 3160)]
        public virtual string CopyrightText { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 3170)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        [Display(
          Name = "Show Real Estate Matters Section",
          Description = "Show Real Estate Matters Section",
          GroupName = Global.Tabs.Content,
          Order = 3190)]
        public virtual bool RealEstateMatters { get; set; }

        [Display(Name = "Announcement Block Content Area",
            Description = "Announcement Block Content Area",
            GroupName = Global.Tabs.Content,
            Order = 3200)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea AnnouncementBlockContentArea { get; set; }


        #endregion

        #region Social

        [Display(Name = "Facebook URL",
           GroupName = Global.Tabs.Social,
           Description = "Facebook URL",
           Order = 4110)]
        public virtual EPiServer.Url FBUrl { get; set; }

        [Display(Name = "Twitter URL",
         GroupName = Global.Tabs.Social,
         Description = "Page url twitter",
         Order = 4120)]
        public virtual EPiServer.Url TwitterUrl { get; set; }

        [Display(Name = "Google URL",
         GroupName = Global.Tabs.Social,
         Description = "Page url fb",
         Order = 4130)]
        public virtual EPiServer.Url GoogleUrl { get; set; }

        [Display(Name = "PinInterest URL",
         GroupName = Global.Tabs.Social,
         Description = "Page url pin",
         Order = 4140)]
        public virtual EPiServer.Url PinInterestUrl { get; set; }

        [Display(Name = "LinkedIn URL",
           GroupName = Global.Tabs.Social,
           Description = "Linkedin URL",
           Order = 4150)]
        public virtual EPiServer.Url LinkedinUrl { get; set; }

        #endregion

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 5100)]
        public virtual string GoogleAnalytics { get; set; }

        #endregion

        #region Solve 360 Category

        [Display(
              Name = "Solve 360 Category",
              GroupName = Global.Tabs.Content,
              Description = "Please select solve 360 category",
              Order = 5100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return PhoneNumber; } }

        #endregion
    }
}