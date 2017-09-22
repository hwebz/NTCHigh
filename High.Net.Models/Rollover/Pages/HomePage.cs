using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Constants;
using High.Net.Models.Rollover.Blocks;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using System;
using System.ComponentModel.DataAnnotations;
namespace High.Net.Models.Rollover.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.RO,
        DisplayName = "Home Page",
        Order = 11001,
        GUID = "b1a83721-b859-4d4f-8ad5-af53838db9bc",
        Description = "Rollover Home Page")]    
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
      Include = new[] { typeof(ContentPage), typeof(NewsListingPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), 
          typeof(PropertyListingPage), typeof(FindAnApartmentPage), typeof(OpportunityListingPage), 
          typeof(FindAnSpacePage), typeof(ContactUsPage), typeof(SearchPage) })]

    public class HomePage : RolloverPageData, IHome, IRollover
    {
        #region Images

        [Display(Name = "Site Logo (Width : 327 , Height : 43)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
           Name = "Slider Images (Width : 1400 , Height : 360)",
           Description = "Slider Image Items",
           GroupName = Global.Tabs.Sliders,
           Order = 1110)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> SliderImages { get; set; }

        #endregion

        #region Content

        [Display(Name = "Is Property Search on slider?",
               GroupName = Global.Tabs.Content,
               Description = "Is Property Search on slider?",
               Order = 2100)]
        public virtual bool IsPropertySearch { get; set; }

        [Display(Name = "Is Property Search on navigation?",
             GroupName = Global.Tabs.Content,
             Description = "Is Property Search on navigation?",
             Order = 2110)]
        public virtual bool IsPropertySearchOnMenu { get; set; }

        [Display(Name = "Is Home Page visible on navigation?",
             GroupName = Global.Tabs.Content,
             Description = "Is Home Page visible on navigation?",
             Order = 2120)]
        public virtual bool IsHomePageOnMenu { get; set; }

        [Display(Name = "Is Contact and Social link visible navigation?",
             GroupName = Global.Tabs.Content,
             Description = "Is Contact and Social link visible navigation?",
             Order = 2121)]
        public virtual bool IsContactStrip { get; set; }

        [Display(Name = "Banner Heading",
           GroupName = Global.Tabs.Content,
           Description = "Banner Heading",
           Order = 2130)]
        [UIHint(UIHint.Textarea)]
        public virtual String BannerHeading { get; set; }

        [Display(Name = "Phone number",
           GroupName = Global.Tabs.Content,
           Description = "Phone number",
           Order = 2140)]
        public virtual String PhoneNo { get; set; }

        [Display(Name = "Email Address",
           GroupName = Global.Tabs.Content,
           Description = "Email",
           Order = 2145)]
        public virtual String EmailAddress { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Content Area",
            Description = "Content Area for Blocks",
            GroupName = Global.Tabs.Content,
            Order = 2150)]
        [AllowedTypes(typeof(MainBlock), typeof(CommercialMultiFamily), typeof(ResidentialMultiFamily), typeof(PortfolioListingBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Name = "Select Rollover Site",
           GroupName = Global.Tabs.Content,
           Description = "This property helps to load appropriate css.",
           Order = 2160)]
        [SelectOne(SelectionFactoryType = typeof(SelectRolloverSite))]
        public virtual String RolloverSite { get; set; }

        [Display(Name = "Footer Pages",
           GroupName = Global.Tabs.Content,
           Description = "Miscellaneous pages",
           Order = 2170)]
        public virtual LinkItemCollection FooterPages { get; set; }

        [Display(Name = "Address",
           GroupName = Global.Tabs.Content,
           Description = "Address",
           Order = 2180)]
        public virtual string Address { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 2190)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Social

        [Display(
           Name = "facebook Link",
           GroupName = Global.Tabs.Social,
           Description = "",
           Order = 3100)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
           Name = "Twitter Link",
           GroupName = Global.Tabs.Social,
           Description = "",
           Order = 3120)]
        public virtual EPiServer.Url TwitterLink { get; set; }

        [Display(
           Name = "Google Plus Link",
           GroupName = Global.Tabs.Social,
           Description = "",
           Order = 3130)]
        public virtual EPiServer.Url GoogleLink { get; set; }

        [Display(
           Name = "PinInterestLink Link",
           GroupName = Global.Tabs.Social,
           Description = "",
           Order = 3140)]
        public virtual EPiServer.Url PinInterestLink { get; set; }

        #endregion

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 5100)]
       public virtual string GoogleAnalytics { get; set; }

        #endregion

        #region Solve360Category

        [Display(
              Name = "Solve 360 Category",
              GroupName = Global.Tabs.Content,
              Description = "Please select solve 360 category",
              Order = 5100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }
                
         public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return PhoneNo; } }
        #endregion
    }
}