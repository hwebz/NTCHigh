using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core.ContentTypes.Blocks;
using EPiServer.Web;
using High.Net.Models.GreenfieldArchitects.Blocks;
using ImageVault.EPiServer;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.GreenfieldArchitects.Pages
{
    [SiteContentType(GroupName = SiteGroups.GAL,
        DisplayName = "Home Page",
        GUID = "DF3F7C83-2677-4725-9FC5-A7C4C1140144",
        Description = "Home page of the website",
        Order = 19001)]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(ServicePage), 
          typeof(High.Net.Models.Shared.Pages.NewsListingPage), typeof(PortfolioPage), typeof(ContactUsPage),
          typeof(SearchPage)})]
    public class HomePage : GreenfieldArchitectsPageData, IHome, IGreenfieldArchitects
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 297, Height : 69)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1000)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
          Name = "Slider Images (Width : 1400, Height : 600)",
          Description = "Size: 1400 x 600",
          GroupName = Global.Tabs.Sliders,
          Order = 1010)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> SliderImages { get; set; }

        [Display(
            Name = "Inner Page Banner Image (Width : 1400, Height : 350)",
            GroupName = Global.Tabs.Images,
            Description = "Size: 1400x290",
            Order = 1020)]
        public virtual MediaReference InnerPageBanner { get; set; }

        #endregion

        #region Social

        [Display(
          Name = "LinkedIn Profile Link",
          GroupName = Global.Tabs.Social,
          Description = "LinkedIn Profile Link",
          Order = 2100)]
        public virtual EPiServer.Url LinkedInLink { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Services Root Page",
           Description = "Services Root Page",
           GroupName = Global.Tabs.Content,
           Order = 3100)]
        [CultureSpecific]
        [AllowedTypes(typeof(ServicePage))]
        public virtual PageReference ServiceRoot { get; set; }

        [Display(
           Name = "Video Details",
           Description = "Video Details",
           GroupName = Global.Tabs.Content,
           Order = 3110)]
        public virtual VideoBlock VideoDetails { get; set; }

        [Display(
           Name = "The American Institute of Architects",
           Description = "The American Institute of Architects",
           GroupName = Global.Tabs.Content,
           Order = 3120)]
        public virtual MediaLink InstitureofArchitects { get; set; }

        [Display(
           Name = "U.S. Green Building Council",
           Description = "U.S. Green Building Council",
           GroupName = Global.Tabs.Content,
           Order = 3130)]
        public virtual MediaLink USGBC { get; set; }

        [Display(
           Name = "Featured Work",
           Description = "Featured Work (portfolio item pages to show in featured work)",
           GroupName = Global.Tabs.Content,
           Order = 3140)]
        public virtual LinkItemCollection FeaturedWorkLinks { get; set; }

        [Display(
           Name = "Footer Links",
           Description = "",
           GroupName = Global.Tabs.Content,
           Order = 3150)]
        public virtual LinkItemCollection FooterLinks { get; set; }

        [Display(
           Name = "Copyright Text",
           Description = "",
           GroupName = Global.Tabs.Content,
           Order = 3160)]
        public virtual String CopyrightText { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 3170)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }


        #endregion

        #region Contact Info

        [Display(
           Name = "Contact No",
           Description = "Contact No",
           GroupName = Global.Tabs.EmailSetting,
           Order = 4100)]
        [CultureSpecific]
        public virtual String ContactNo { get; set; }

        [Display(
           Name = "Address",
           Description = "Address",
           GroupName = Global.Tabs.Content,
           Order = 4200)]
        [CultureSpecific]
        public virtual String Address { get; set; }

        [Display(
           Name = "Email ID",
           Description = "Email ID",
           GroupName = Global.Tabs.Content,
           Order = 4300)]
        [CultureSpecific]
        public virtual String EmailID { get; set; }

        #endregion

        #region Google Analytics

        [Display(
            Name = "Google Analytics Code",
            Description = "Google Analytics",
            GroupName = Global.Tabs.Content,
            Order = 5100)]
        public virtual string GoogleAnalytics { get; set; }

        #endregion

        #region ContactUs PageLink

        [Display(
           Name = "Contact Us Pagelink",
           Description = "",
           GroupName = Global.Tabs.Content,
           Order = 6100)]
        public virtual PageReference ContactUsPageLink { get; set; }

        #endregion

        #region Solve360Category

        [Display(
              Name = "Solve 360 Category",
              GroupName = Global.Tabs.Content,
              Description = "Please select solve 360 category",
              Order = 7100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }

         public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNo; } }

        #endregion
    }
}