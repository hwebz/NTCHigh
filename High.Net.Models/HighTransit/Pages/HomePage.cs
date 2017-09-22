using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.HighTransit.Blocks;
using High.Net.Core.ContentTypes.Blocks;
using High.Net.Models.Shared.Pages;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName = SiteGroups.HT, Order = 16010, DisplayName = "Home Page", GUID = "72847d8c-9380-4946-8596-c5e359053807", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(VideoListingPage), 
          typeof(ServiceListingPage), typeof(MapPage) , typeof(ContactUsPage) ,typeof(ProjectListingPage), typeof(SearchPage)})]    
    public class HomePage : HighTransitPageData, IHighTransit, IHome
    {
        #region Images

        [Display(Name = "Site Logo (Width : 350 , Height : 49)",
           GroupName = Global.Tabs.Images,
           Description = "Site Logo",
           Order = 1010)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(Name = "Page Banner (Width : 1400 , Height : 360)",
           GroupName = Global.Tabs.Images,
           Description = "Page Banner",
           Order = 1020)]
        public virtual MediaReference PageBanner { get; set; }

        [Display(Name = "PMTA (Width : 200 , Height : 82)",
           GroupName = Global.Tabs.Images,
           Description = "PMTA",
           Order = 1030)]
        public virtual MediaLink PMTA { get; set; }

        [Display(Name = "SCRA (Width : 200 , Height : 87)",
           GroupName = Global.Tabs.Images,
           Description = "SCRA",
           Order = 1030)]
        public virtual MediaLink SCRA { get; set; }

        [Display(Name = "ATA (Width : 100 , Height : 75)",
         GroupName = Global.Tabs.Images,
         Description = "ATA",
         Order = 1030)]
        public virtual MediaLink ATA { get; set; }

        #endregion

        #region Slider

        [Display(
             Name = "Slider Images",
             Description = "Slider Image Items",
             GroupName = Global.Tabs.Sliders,
             Order = 1030)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Slider { get; set; }

        #endregion

        #region Contact Info

        [Display(Name = "Phone Number",
           GroupName = Global.Tabs.Content,
           Description = "Phone Number",
           Order = 2010)]
        public virtual string PhoneNumber { get; set; }

        [Display(Name = "Email Id",
           GroupName = Global.Tabs.Content,
           Description = "Email Id",
           Order = 2020)]
        public virtual string EmailId { get; set; }

        [Display(Name = "Address",
            GroupName = Global.Tabs.Content,
            Description = "Address",
            Order = 2030)]
        [UIHint(UIHint.LongString)]
        public virtual string Address { get; set; }

        #endregion

        #region Content

        [Display(Name = "About Us",
            GroupName = Global.Tabs.Content,
            Description = "About Us",
            Order = 3010)]
        public virtual XhtmlString IntroText { get; set; }

        [Display(Name = "Services Page Reference Link",
           GroupName = Global.Tabs.Content,
           Description = "Add Page",
           Order = 3020)]
        [AllowedTypes(typeof(ServiceListingPage))]
        public virtual PageReference ServicePageLink { get; set; }

        [Display(Name = "Map Area",
            GroupName = Global.Tabs.Content,
            Description = "Map Area",
            Order = 3030)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea MapArea { get; set; }

        [Display(Name = "Request A Quote Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Page Url",
            Order = 3040)]
        public virtual EPiServer.Url RequestQuoteLink { get; set; }

        [Display(Name = "Subscribe to Newsletter Page Url",
          GroupName = Global.Tabs.Content,
          Description = "Page Url",
          Order = 3050)]
        public virtual EPiServer.Url NewsLetterLink { get; set; }

        [Display(Name = "Footer Pages",
          GroupName = Global.Tabs.Content,
          Description = "Footer Pages",
          Order = 3060)]
        public virtual LinkItemCollection FooterPages { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 3070)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

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
              Order = 7100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }        

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return PhoneNumber; } }

        #endregion
    }
}