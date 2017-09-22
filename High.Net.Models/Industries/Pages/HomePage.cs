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
using High.Net.Models.Industries.Blocks;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.Industries.Pages
{
    [SiteContentType(GroupName = SiteGroups.HII,
        Order = 4010,
        DisplayName = "Home Page",
        GUID = "860f093e-6333-4487-a70a-f7559f206c4b",
        Description = "Home Page")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage), typeof(NewsListingPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), 
           typeof(LocationPage) , typeof(ContactUsPage) ,typeof(SearchPage)})]
    public class HomePage : IndustriesPageData, IHome, IIndustries
    {
        #region Images

        [Display(Name = "Site Logo (Width : 194 , Height : 45)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        #endregion

        #region Slider

        [Display(
           Name = "Slider (Width : 1400 , Height : 360)",
           Description = "Image Slider",
           GroupName = Global.Tabs.Sliders,
           Order = 1200)]
        [AllowedTypes(typeof(CarouselBlock))]
        public virtual ContentArea Slider { get; set; }

        [Display(
           Name = "Banner Image Slider (Width : 1400 , Height : 360)",
           Description = "Latest Project Image Slider",
           GroupName = Global.Tabs.Sliders,
           Order = 1140)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> BannerImageSliders { get; set; }

        [Display(
           Name = "project Image Slider (Width : 425 , Height : 337)",
           Description = "Latest Project Image Slider",
           GroupName = Global.Tabs.Sliders,
           Order = 1150)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSliders { get; set; }

        #endregion

        #region Social

        [Display(Name = "Phone Number",
            GroupName = Global.Tabs.Content,
            Description = "Phone Number",
            Order = 2100)]
        public virtual string PhoneNumber { get; set; }

        [Display(Name = "Email Address",
          GroupName = Global.Tabs.Content,
          Description = "Email Address",
          Order = 2110)]
        public virtual string EmailAddress { get; set; }

        #endregion

        #region Content

        [Display(Name = "Main Heading",
           Description = "Main Heading",
           GroupName = Global.Tabs.Content,
           Order = 3000)]
        public virtual XhtmlString MainHeading { get; set; }

        [Display(Name = "Page Content",
           Description = "Page Content",
           GroupName = Global.Tabs.Content,
           Order = 3010)]
        public virtual XhtmlString PageContent { get; set; }

        [Display(Name = "Our Services Area",
           Description = "Our Services Area",
           GroupName = Global.Tabs.Content,
           Order = 3100)]
        [CultureSpecific]
        [AllowedTypes(typeof(LLCBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(Name = "About High",
           Description = "About High",
           GroupName = Global.Tabs.Content,
           Order = 3110)]
        [CultureSpecific]
        public virtual XhtmlString AboutHigh { get; set; }

        [Display(Name = "Project Gallery Title",
          Description = "Project Gallery Title",
          GroupName = Global.Tabs.Content,
          Order = 3120)]
        public virtual string ProjectGalleryTitle { get; set; }

        [Display(Name = "Footer Pages",
            GroupName = Global.Tabs.Content,
            Description = "Miscellaneous pages",
            Order = 3130)]
        public virtual LinkItemCollection FooterPages { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 3140)]
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
              Order = 5100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }      

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return PhoneNumber; } }

        #endregion
    }
}