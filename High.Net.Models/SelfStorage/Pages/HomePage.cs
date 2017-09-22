using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core.ContentTypes.Blocks;
using EPiServer.Web;
using High.Net.Models.SelfStorage.Blocks;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.SelfStorage.Pages
{
    [SiteContentType(GroupName = SiteGroups.PSS,
        DisplayName = "Home Page",
        GUID = "fe9758f6-0eb9-4b8b-b65c-11aa9c0a9f40",
        Description = "Home page of the website",
        Order = 2001)]

    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(High.Net.Models.Shared.Pages.SearchPage) })]
    public class HomePage : SelfStoragePageData, IHome, ISelfStorage
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 186 , Height : 91)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        #endregion

        #region Slider

        [Display(
           Name = "Image Slider  (Width : 926 , Height : 289)",
           Description = "Image Slider",
           GroupName = Global.Tabs.Sliders,
           Order = 1200)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSlider { get; set; }

        #endregion

        #region Social

        [Display(
             Name = "Facebook Link",
             GroupName = Global.Tabs.Social,
             Description = "Facebook Link",
             Order = 2100)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
         Name = "Twitter Link",
         GroupName = Global.Tabs.Social,
         Description = "Twitter Link",
         Order = 2200)]
        public virtual EPiServer.Url TwitterLink { get; set; }

        #endregion

        #region Content

        [Display(
           Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 4100)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(TextBlock) })]
        public virtual ContentArea ContentArea { get; set; }


        [Display(
           Description = "Partners",
           GroupName = Global.Tabs.Content,
           Order = 4200)]
        [CultureSpecific]
        [AllowedTypes(typeof(MediaLink))]
        public virtual ContentArea Partners { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 4300)]
        [AllowedTypes(typeof(High.Net.Models.Shared.Pages.SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Url

        [Display(
         Name = "High Associates Link",
         GroupName = Global.Tabs.Content,
         Description = "High Associates Link",
         Order = 5100)]
        public virtual MediaLink HighAssociatesLink { get; set; }


        [Display(
         Name = "Tenant Login Link",
         GroupName = Global.Tabs.Content,
         Description = "Tenant Login",
         Order = 5200)]
        public virtual EPiServer.Url TenantLogin { get; set; }

        [Display(
         Name = "Current Speacial Link",
         GroupName = Global.Tabs.Content,
         Description = "Current Speacial",
         Order = 5300)]
        public virtual EPiServer.Url CurrentSpecialLink { get; set; }

        #endregion

        #region Contact

        [Display(
           Name = "Contact",
           Description = "Contact No",
           GroupName = Global.Tabs.EmailSetting,
           Order = 6100)]
        [CultureSpecific]
        public virtual String ContactNo { get; set; }

        [Display(
           Name = "Address",
           Description = "Address",
           GroupName = Global.Tabs.Content,
           Order = 6200)]
        [CultureSpecific]
        public virtual String Address { get; set; }

        #endregion

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 7100)]
        public virtual string GoogleAnalytics { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNo; } }

        #endregion

    }
}