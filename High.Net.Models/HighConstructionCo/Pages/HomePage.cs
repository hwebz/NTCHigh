using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Constants;
using High.Net.Models.HighConstructionCo.Blocks;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using System;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.HighConstructionCo.Pages
{
    [SiteContentType(
        DisplayName = "Home Page",
        GroupName = SiteGroups.HCC,
        GUID = "15118404-C72C-4B14-B28D-CA184B70651F",
        Description = "Homepage of the website",
        Order = 17001)]
    [AvailableContentTypes(Availability.Specific, Include = new[] {
        typeof(ContentPage), typeof(ProjectCategoryListPage), typeof(NewsListingPage),
        typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(ContactUsPage),
        typeof(SearchPage)})]
    public class HomePage : HighConstructionCoPageData, IHome
    {
        #region Image

        [Display(
            Name = "Site Logo (Width : 322 , Height : 46)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
           Name = "Image Slider (Width : 1400 , Height : 600)",
           Description = "Image Slider",
           GroupName = Global.Tabs.Images,
           Order = 1200)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageSliders { get; set; }

        #endregion Image

        #region Content

        [Display(
           Name = "Services Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea ServiceContent { get; set; }

        [Display(
           Name = "Featured Work",
           GroupName = Global.Tabs.Content,
           Description = "(Project Item Pages to display in Featured Work Section)",
           Order = 2200)]
        public virtual LinkItemCollection FeatureWorkLinks { get; set; }

        [Display(
          Name = "Video Link",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2300)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [Display(
          Name = "Video Heading",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2400)]
        public virtual String VideoHeading { get; set; }

        [Display(
          Name = "Video Description",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2500)]
        public virtual XhtmlString VideoDescription { get; set; }

        [Display(
           Name = "Address",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2600)]
        public virtual String Address { get; set; }

        [Display(
           Name = "Contact",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2700)]
        public virtual String Contact { get; set; }

        [Display(
           Name = "Email ID",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2800)]
        public virtual String EmailID { get; set; }

        [Display(
           Name = "Footer Links",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2900)]
        public virtual LinkItemCollection FooterLinks { get; set; }

        [Display(
           Name = "Copy Right Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 3000)]
        public virtual String CopyRightText { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 3100)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion Content

        #region Social

        [Display(
           Name = "LinkedIn Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 3100)]
        public virtual EPiServer.Url LinkedInLink { get; set; }

        #endregion Social

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 4100)]
        public virtual string GoogleAnalytics { get; set; }

        #endregion Google Analytics

        #region Contact PageLink

        [Display(
             Name = "Contact page link",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 5100)]
        public virtual PageReference ContactUsPageLink { get; set; }

        #endregion Contact PageLink

        #region Solve360Category

        [Display(
              Name = "Solve 360 Category",
              GroupName = Global.Tabs.Content,
              Description = "Please select solve 360 category",
              Order = 6100)]
        [Required]
        [SelectOne(SelectionFactoryType = typeof(SelectSolve360CategoryTag))]
        public virtual string Solve360CategoryTag { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return Contact; } }

        #endregion Solve360Category
    }
}