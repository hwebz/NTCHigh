using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.StructureCareUs.Blocks;
using High.Net.Core.ContentTypes.Blocks;
using EPiServer.Web;
using High.Net.Models.Shared.Pages;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.StructureCareUs.Pages
{
    [SiteContentType(GroupName = SiteGroups.SCU, Order = 9010, DisplayName = "Home Page", GUID = "0be91e64-9aca-40e8-9b59-7b752454c8c4", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] {typeof(ServiceListingPage), typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage),
           typeof(ServiceListingPage) ,typeof(ContactUsPage),typeof(SearchPage)})]
    public class HomePage : StructureCareUsPageData, IHome, IStructureCareUs
    {
        #region Images

        [Display(Name = "Site Logo (Width : 586 , Height : 91)",
          GroupName = Global.Tabs.Images,
          Description = "Site Logo",
          Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
              Name = "Slider Images (Width : 1400 , Height : 390)",
              Description = "Slider Image Items",
              GroupName = Global.Tabs.Images,
              Order = 1120)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Slider { get; set; }

        [Display(Name = "About Us Image (Width : 460 , Height : 269)",
             GroupName = Global.Tabs.Images,
             Description = "About Us Image",
             Order = 1130)]
        public virtual MediaReference AboutUsImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Header Text",
            GroupName = Global.Tabs.Content,
            Description = "Header Text",
            Order = 2110)]
        public virtual string HeaderText { get; set; }

        [Display(Name = "Service Listing Page",
            GroupName = Global.Tabs.Content,
            Description = "Service Listing",
            Order = 2120)]
        [AllowedTypes(typeof(ServiceListingPage))]
        public virtual PageReference ServiceListingPage { get; set; }

        [Display(Name = "About",
            GroupName = Global.Tabs.Content,
            Description = "About",
            Order = 2130)]
        public virtual XhtmlString AboutUsText { get; set; }

        [Display(Name = "Footer details",
            GroupName = Global.Tabs.Content,
            Description = "Footer details",
            Order = 2140)]
        public virtual string FooterDetails { get; set; }

        [Display(Name = "Footer Pages",
            GroupName = Global.Tabs.Content,
            Description = "Miscellaneous pages",
            Order = 2150)]
        public virtual LinkItemCollection FooterPages { get; set; }

        [Display(Name = "How we can help you information page",
           GroupName = Global.Tabs.Content,
           Description = "How we can help you information page",
           Order = 2170)]
        public virtual PageReference HowWeCanHelpYouInformationPage { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 2180)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Social

        [Display(Name = "Phone Number",
            GroupName = Global.Tabs.Content,
            Description = "Phone Number",
            Order = 3100)]
        public virtual string PhoneNumber { get; set; }

        [Display(Name = "Email ID",
            GroupName = Global.Tabs.Content,
            Description = "Email ID",
            Order = 3120)]
        public virtual string EmailID { get; set; }

        [Display(Name = "Address",
            GroupName = Global.Tabs.Content,
            Description = "Address",
            Order = 3130)]
        public virtual string ContactAddress { get; set; }

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

        public string BusinessContactNumber { get { return PhoneNumber; } }

        #endregion
    }
}