using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.HighConcrete.Blocks;
using High.Net.Models.Shared.Pages;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Home Page",
        GUID = "11887f41-e75d-43bb-b3fb-0ff45509400d",
        Description = "HomePage of the website",
        Order = 13001)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { 
                            typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage),
                            typeof(VideoListingPage), typeof(ProjectCategoryPage), typeof(GetQuotePage),
                            typeof(ProductCategoryPage) , typeof(High.Net.Models.Shared.Pages.NewsListingPage) , typeof(BoxLunchSignUpFormPage),
                            typeof(TeamTypeListingPage), typeof(FindRepresentativePage) ,typeof(ContactUsPage), typeof(TeamListingPage),
                            typeof(EventListingPage), typeof(SearchPage)})]
    public class HomePage : HighConcretePageData, IHome, IHighConcrete
    {
        #region Image

        [Display(
            Name = "Site Logo (Width : 311 , Height : 82)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
           Name = "Slider (Width : 1400 , Height : 360)",
           Description = "Image Slider",
           GroupName = Global.Tabs.Content,
           Order = 1200)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea Slider { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Quick Links",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(QuickLinkBlock))]
        public virtual ContentArea QuickLinksContent { get; set; }

        [Display(
           Name = "Request Quote Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1200)]
        public virtual String QuoteText { get; set; }

        [Display(
           Name = "Get Quote",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1300)]
        public virtual EPiServer.Url GetQuoteLink { get; set; }

        [Display(
           Name = "Sample request link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1300)]
        public virtual EPiServer.Url RequestLink { get; set; }

        [Display(
           Name = "Social Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1400)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea SocialContentArea { get; set; }

        [Display(
          Name = "Copy Right Text",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 1500)]
        public virtual String CopyRightText { get; set; }

        [Display(
          Name = "Footer Links",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 1510)]
        public virtual LinkItemCollection FooterLinks { get; set; }

        [Display(
           Name = "Get CEUS link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1520)]
        public virtual EPiServer.Url CEUSlink { get; set; }

        [Display(
           Name = "Join our team link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1530)]
        public virtual EPiServer.Url Teamlink { get; set; }

        [Display(
         Name = "Product Color Selector",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1540)]
        public virtual XhtmlString ProductColorSelector { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 1550)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        [Display(Name = "News Widget Headline Url",
            GroupName = Global.Tabs.Content,
            Description = "This page reference is used to display headline on news widget",
            Order = 1560)]
        [AllowedTypes(typeof(NewsItemPage))]
        public virtual PageReference NewsWidgetHeadline { get; set; }

         [Display(
         Name = "Video Title",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1570)]
        public virtual XhtmlString VideoTitle { get; set; }

         [Display(
         Name = "Video Count",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1580)]
         public virtual int VideoCount { get; set; }

         [Display(
          Name = "Porfolio Project Count",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 1590)]
         public virtual int PorfolioProjectCount { get; set; }

        #endregion

        #region Contact

        [Display(
          Name = "Address",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 3100)]
        public virtual XhtmlString Address { get; set; }

        [Display(
          Name = "Toll Free Contact",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 3200)]
        public virtual String Contact { get; set; }

        [Display(
          Name = "Fax",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 3300)]
        public virtual String Fax { get; set; }

        [Display(
          Name = "Email",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 3400)]
        public virtual String Email { get; set; }

        #endregion

        #region Social

        [Display(
         Description = "Facebook Link",
         GroupName = Global.Tabs.Content,
         Order = 4110)]
        [CultureSpecific]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
         Description = "Twitter Link",
         GroupName = Global.Tabs.Content,
         Order = 4120)]
        [CultureSpecific]
        public virtual EPiServer.Url TwitterLink { get; set; }

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
              Order = 7100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }     
       
        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return Contact; } }

        #endregion
    }
}