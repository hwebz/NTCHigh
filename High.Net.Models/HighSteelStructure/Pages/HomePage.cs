using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.HighSteelStructure.Blocks;
using High.Net.Models.Shared.Pages;
using EPiServer.Web;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "HomePage",
        GUID = "7dceead8-62b1-4315-9452-a956399807cf",
        Description = "Home page of website",
        Order = 18001)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectCategoryPage), typeof(ContentPage), 
        typeof(VideoListingPage), typeof(NewsListingPage) , typeof(High.Net.Models.Shared.Pages.ContainerPage),
        typeof(SearchPage),typeof(TechnicalResourcesPage) , typeof(ShippingAdvisorPage) , typeof(ContactUsPage),typeof(SteelDayPage) })]
    public class HomePage : HighSteelStructurePageData, IHome, IHighSteelStructure
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 360 , Height : 82)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        #endregion

        #region Slider

        [Display(
            Name = "Slider (Width : 1400 , Height : 360)",
            GroupName = Global.Tabs.Sliders,
            Description = "",
            Order = 1300)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea Slider { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Email Address",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2000)]
        public virtual String EmailAddress { get; set; }

        [Display(
            Name = "Ask High Steel Page Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2100)]
        public virtual EPiServer.Url HighSteelLink { get; set; }

        [Display(
            Name = "Product Pricing Page Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual EPiServer.Url ProductPricingLink { get; set; }

        [Display(
            Name = "Shiping Advicer Page Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        public virtual EPiServer.Url ShipingAdvicerLink { get; set; }

        [Display(
            Name = "Features Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2400)]
        public virtual String FeaturesHeading { get; set; }

        [Display(
            Name = "Main Content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2600)]
        [AllowedTypes(typeof(ProductsBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
            Name = "Products Services Page",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2700)]
        [AllowedTypes(typeof(ProductsBlock), typeof(TextBlock))]
        public virtual ContentArea ProductServicesContent { get; set; }

        [Display(Name = "Search Page Url",
          GroupName = Global.Tabs.Content,
          Description = "Search Page Reference",
          Order = 2800)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        [Display(Name = "Newslettter Subscription Link",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2900)]
        public virtual EPiServer.Url SubscriptionLink { get; set; }


        [Display(Name = "Brochure Link",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2950)]
        public virtual MediaReference PDFBrochureLink { get; set; }

        [Display(Name = "Quick Links",
          GroupName = Global.Tabs.Content,
          Description = "Links which will be displayed in link section",
          Order = 2975)]
        public virtual LinkItemCollection QuickLinks { get; set; }

        [Display(Name = "Footer Links",
          GroupName = Global.Tabs.Content,
          Description = "Links which will be displayed in footer section",
          Order = 3000)]
        public virtual LinkItemCollection FooterLinks { get; set; }

        #endregion

        #region Social

        [Display(
            Name = "Facebook Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 3100)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        #endregion

        #region Contact

        [Display(
           Name = "Contact",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 5100)]
        public virtual String Contact { get; set; }

        [Display(
           Name = "Address",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 5200)]
        public virtual String Address { get; set; }

        [Display(
           Name = "CopyRight Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 5400)]
        public virtual String CopyRightText { get; set; }

        [Display(
           Name = "High Companies Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 5500)]
        public virtual EPiServer.Url HighCompaniesLink { get; set; }

        #endregion

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 4100)]
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

        public string BusinessContactNumber { get { return Contact; } }

        #endregion
    }
}