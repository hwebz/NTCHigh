using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.Shared.Pages;
using EPiServer.Web;
using High.Net.Models.HighHotels.Blocks;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighHotels.Pages
{
    [SiteContentType(GroupName = SiteGroups.HH,
        Order = 12010, DisplayName = "Home Page", GUID = "2cba03a0-ee87-4935-ad12-4a632483bd96", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), typeof(NewsListingPage), typeof(VideoListingPage), typeof(PortfolioListPage), typeof(ContactUsPage), typeof(SearchPage) })]
    public class HomePage : HighHotelsPageData, IHighHotels, IHome
    {
        #region Images

        [Display(Name = "Site Logo (Width : 385 , Height : 82)",
             GroupName = Global.Tabs.Images,
             Description = "Site Logo",
             Order = 1010)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
             Name = "Slider Images (Width : 1400 , Height : 360)",
             Description = "Slider Image Items",
             GroupName = Global.Tabs.Images,
             Order = 1020)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Slider { get; set; }

        [Display(
            Name = "Tag Line",
            Description = "Tag Line",
            Order = 1030)]
        [CultureSpecific]
        public virtual string TagLine { get; set; }

        [Display(
             Name = "Hotel Images",
             Description = "Hotel Images",
             GroupName = Global.Tabs.Images,
             Order = 1040)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> HotelImages { get; set; }
        #endregion

        #region Content

        [Display(Name = "Features Block",
            GroupName = Global.Tabs.Content,
            Description = "Features",
            Order = 2010)]
        [AllowedTypes(typeof(FeaturesBlock))]
        public virtual ContentArea FeaturesArea { get; set; }


        [Display(Name = "About Description",
             GroupName = Global.Tabs.Content,
             Description = "About Description",
             Order = 2020)]
        public virtual XhtmlString AboutDescription { get; set; }

        [Display(
            Name = "Footer Links",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2030)]
        public virtual LinkItemCollection FooterLinks { get; set; }

        #endregion

        #region Contact

        [CultureSpecific]
        [Display(
            Name = "Contact Number",
            Description = "Contact Number",
            GroupName = Global.Tabs.EmailSetting,
            Order = 3010)]
        public virtual String ContactNumber { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Address",
            Description = "Address",
            GroupName = Global.Tabs.Content,
            Order = 3020)]
        [UIHint(UIHint.LongString)]
        public virtual String ContactAddress { get; set; }

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

        #endregion

        #region SearchPage

        [Display(
         Name = "Search Page link",
         GroupName = Global.Tabs.Content,
         Description = "this page will be use to show search result",
         Order = 6001)]
        public virtual EPiServer.Url SearchPageUrl { get; set; }

        #endregion

        #region Social

        [Display(
            Name = "Facebook link",
            GroupName = Global.Tabs.Social,
            Description = "",
            Order = 7001)]
        public virtual EPiServer.Url FacebookLink { get; set; }

        [Display(
            Name = "Pinterest link",
            GroupName = Global.Tabs.Social,
            Description = "",
            Order = 7010)]
        public virtual EPiServer.Url PinterestLink { get; set; }

        [Display(
                Name = "LinkedIn link",
                GroupName = Global.Tabs.Social,
                Description = "",
                Order = 7020)]
        public virtual EPiServer.Url LinkedInLink { get; set; }    

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNumber; } }

        #endregion

    }
}