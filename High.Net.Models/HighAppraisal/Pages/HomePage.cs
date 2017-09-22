using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.HighAppraisal.Blocks;
using High.Net.Models.Shared.Pages;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighAppraisal.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HAPP,
        DisplayName = "Home Page",
        GUID = "11106071-281f-4e7b-898d-46501f50ed5a",
        Description = "Home page of website",
        Order = 14001)]
    [SiteImageUrl]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage), typeof(VideoListingPage), typeof(High.Net.Models.Shared.Pages.NewsListingPage), typeof(SearchPage), typeof(ContactUsPage) })]
    public class HomePage : HighAppraisalPageData, IHome, IHighAppraisal
    {
        #region Images

        [Display(
            Name = "Site Logo ( Width : 327, Height : 56 )",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
            Name = "Banner Image (Width : 1400, Height : 419)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1200)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Slider

        [Display(
           Name = "Slider Images (Width : 1400, Height : 419)",
           GroupName = Global.Tabs.Sliders,
           Description = "",
           Order = 1300)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Slider { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Phone Number",
            GroupName = Global.Tabs.Content,
            Description = "Phone Number",
            Order = 2100)]
        public virtual string PhoneNumber { get; set; }

        [Display(
            Name = "Address",
            GroupName = Global.Tabs.Content,
            Description = "Address",
            Order = 2200)]
        public virtual String Address { get; set; }

        [Display(
            Name = "Main Content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageTextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
            Name = "About Us Content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2400)]
        public virtual XhtmlString AboutContent { get; set; }

        [Display(Name = "Search Page Url",
           GroupName = Global.Tabs.Content,
           Description = "Search Page Reference",
           Order = 2700)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        [Display(Name = "Footer Links",
           GroupName = Global.Tabs.Content,
           Description = "Footer link in Footer",
           Order = 2800)]
        public virtual LinkItemCollection FooterLinks { get; set; }

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
              Order = 6100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return PhoneNumber; } }

        #endregion
    }
}