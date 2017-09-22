using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using EPiServer.Web;
using ImageVault.EPiServer;
using High.Net.Models.Shared.Pages;
using High.Net.Models.SteelServiceCentre.Blocks;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Home Page",
        GUID = "e4d28d1e-019a-4c47-bc3c-82992ba6dd26",
        Description = "Steel Service Centre Home Page",
        Order = 6010)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage), typeof(BrokerPage), typeof(NewsListingPage),
                         typeof(PropertyListingPage), typeof(High.Net.Models.Shared.Pages.ContainerPage),
                         typeof(VideoListingPage) , typeof(NewsListingPage) , typeof(ShippingAdvisorPage),
                         typeof(SearchPage) ,typeof(ContactUsPage)})]    
    public class HomePage : SteelServiceCentrePageData, ISteelServiceCentre, IHome
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 310 , Height : 59)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
          Name = "High-SL Logo (Width : 209 , Height : 79)",
          Description = "",
          GroupName = Global.Tabs.Images,
          Order = 1200)]
        public virtual MediaLink HighSLLogo { get; set; }

        [Display(
          Name = "High-SL Stainless Logo (Width : 209 , Height : 79)",
          Description = "",
          GroupName = Global.Tabs.Images,
          Order = 1300)]
        public virtual MediaLink HighSLStainlessLogo { get; set; }


        [Display(
         Name = "Red Bud Industries Logo (Width : 183 , Height : 30)",
         Description = "Right Logo with Link",
         GroupName = Global.Tabs.Images,
         Order = 1500)]
        public virtual MediaLink RedBudLogo { get; set; }


        #endregion

        #region Slider

        [Display(
          Name = "Slider Images (Width : 1400 , Height : 360)",
          Description = "Slider Image Items",
          GroupName = Global.Tabs.Sliders,
          Order = 1400)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Silders { get; set; }

        #endregion

        #region Content

        [Display(
        Name = "Products Content Area",
        Description = "Content Area for value added Services",
        GroupName = Global.Tabs.Content,
        Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(typeof(ServicesBlock))]
        public virtual ContentArea ServicesContentArea { get; set; }

        [Display(
         Name = "Contact",
         Description = "Contact No.",
         GroupName = Global.Tabs.EmailSetting,
         Order = 2200)]
        [CultureSpecific]
        public virtual String ContactNo { get; set; }

        [Display(
         Name = "Email ID",
         Description = "Email ID",
         GroupName = Global.Tabs.Content,
         Order = 2300)]
        [CultureSpecific]
        public virtual String EmailID { get; set; }

        [Display(
        Name = "Address",
        Description = "Address",
        GroupName = Global.Tabs.Content,
        Order = 2400)]
        [CultureSpecific]
        public virtual String Address { get; set; }

        [Display(
        Name = "Fax No",
        Description = "Fax No",
        GroupName = Global.Tabs.Content,
        Order = 2500)]
        [CultureSpecific]
        public virtual String FaxNo { get; set; }

        [Display(
        Name = "Partners",
        Description = "content area to display partners",
        GroupName = Global.Tabs.Content,
        Order = 2500)]
        [AllowedTypes(typeof(MediaLink))]
        public virtual ContentArea PartnersBlock { get; set; }

        [Display(
        Name = "Value Services Block",
        Description = "content area to display partners",
        GroupName = Global.Tabs.Content,
        Order = 2500)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea ValueServicesBlock { get; set; }

        [Display(
        Name = "Copyrights",
        Description = "Copyrights",
        GroupName = Global.Tabs.Content,
        Order = 2600)]
        [CultureSpecific]
        public virtual String Copyrights { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 2700)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Social

        [Display(
           Name = "Facebook Link",
           Description = "",
           GroupName = Global.Tabs.Social,
           Order = 3100)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
           Name = "Google Plus Link",
           Description = "",
           GroupName = Global.Tabs.Social,
           Order = 3200)]
        public virtual EPiServer.Url GooglePlusLink { get; set; }

        [Display(
           Name = "YouTube Link",
           Description = "",
           GroupName = Global.Tabs.Social,
           Order = 3300)]
        public virtual EPiServer.Url YoutubeLink { get; set; }

        [Display(
           Name = "LinkedIn Link",
           Description = "",
           GroupName = Global.Tabs.Social,
           Order = 3400)]
        public virtual EPiServer.Url LinkedInLink { get; set; }

        [Display(
           Name = "Twitter Link",
           Description = "",
           GroupName = Global.Tabs.Social,
           Order = 3500)]
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
              Order = 6100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNo; } }

        #endregion
    }
}