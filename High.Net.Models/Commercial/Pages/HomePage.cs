using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using High.Net.Models.Constants;
using High.Net.Models.Commercial.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.SpecializedProperties;

using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.Commercial.Pages
{
    [SiteContentType(
       GroupName = SiteGroups.B2B,
       DisplayName = "Home Page",
       GUID = "65E91682-E286-43F5-B69D-6CBB1E66E666",
       Description = "B2B - Home page",
       Order = 3010)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage), typeof(NewsListingPage), typeof(PropertyListingPage), typeof(PropertyTypePage),
           typeof(High.Net.Models.Shared.Pages.ContainerPage) , typeof(BrokerListingPage), typeof(LocationPage) , typeof(ContactUsPage), typeof(SearchPage) })]
    
    public class HomePage : CommercialPageData, IHome, ICommercial
    {
        #region Images

        [Display(
            Name = "Site Logo (Width : 300 , Height : 53)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
           Name = "Slider Images (Width : 1400 , Height : 360)",
           Description = "Size: 1400x360",
           GroupName = Global.Tabs.Images,
           Order = 1120)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> SliderImages { get; set; }

        [Display(
           Name = "Pages Banner Image (Width : 1400 , Height : 360)",
           GroupName = Global.Tabs.Images,
           Description = "Size: 1400x360",
           Order = 1130)]
        public virtual MediaReference SiteBannerImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Site Managed By Link",
            GroupName = Global.Tabs.Content,
            Description = "This site is Managed By Link",
            Order = 2100)]
        public virtual MediaLink ManagedBy { get; set; }

        [Display(
            Name = "Item List Heading",
            Description = "Item List Heading",
            GroupName = Global.Tabs.Content,
            Order = 2110)]
        [CultureSpecific]
        public virtual string ItemListHeading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "About Us Text",
            Description = "About Us Text",
            GroupName = Global.Tabs.Content,
            Order = 2120)]
        public virtual XhtmlString AboutUsText { get; set; }

        [Display(GroupName = Global.Tabs.Content,
           Description = "News Page Root",
           Order = 2130)]
        public virtual PageReference NewsPageRoot { get; set; }

        [Display(
           Name = "Footer Page Links",
           GroupName = Global.Tabs.Content,
           Description = "Footer Page Links",
           Order = 2140)]
        public virtual LinkItemCollection FooterPageLinks { get; set; }


        [Display(
            Name = "Video Carousel",
            Description = "Carousel using image video",
            GroupName = Global.Tabs.Content,
            Order = 2150)]
        [CultureSpecific]
        [AllowedTypes(typeof(VideoBlock))]
        public virtual ContentArea VideoCarousel { get; set; }

        [Display(Name = "Search Page Url",
            GroupName = Global.Tabs.Content,
            Description = "Search Page Reference",
            Order = 2160)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Url

        [Display(
            Name = "Tennent Login Link",
            GroupName = Global.Tabs.Content,
            Description = "Tennent Login Link",
            Order = 3100)]
        public virtual EPiServer.Url TennentLoginLink { get; set; }

        #endregion

        #region Contact

        [Display(
           Name = "Office Address",
           GroupName = Global.Tabs.Content,
           Description = "Address Text",
           Order = 4100)]
        public virtual string Address { get; set; }

        [Display(
           Name = "Contact Number",
           GroupName = Global.Tabs.Content,
           Description = "Contact Number",
           Order = 4110)]
        public virtual string ContactNumber { get; set; }

        [Display(
           Name = "Google Location Url",
           GroupName = Global.Tabs.Content,
           Description = "Google Location Url",
           Order = 4120)]
        public virtual EPiServer.Url GoogleLocation { get; set; }

        [Display(
           Name = "Email Id",
           GroupName = Global.Tabs.Content,
           Description = "Email Id",
           Order = 4130)]
        public virtual string EmailId { get; set; }

        #endregion

        #region Rollover

        [Display(
          Name = "Site Image (Width : 360 , Height : 250)",
          GroupName = Global.Tabs.Rollover,
          Description = "Site Logo",
          Order = 6100)]
        public virtual MediaReference SiteImage { get; set; }

        [Display(
         Name = "Site Introduction",
         Description = "Site Introduction",
         GroupName = Global.Tabs.Rollover,
         Order = 6200)]
        [UIHint(UIHint.Textarea)]
        public virtual String SiteIntroduction { get; set; }

        [Display(
         Name = "Bedrooms Count",
         Description = "Bedrooms Count",
         GroupName = Global.Tabs.Rollover,
         Order = 6300)]
        public virtual int BedroomsCount { get; set; }

        [Display(
         Name = "Bath Count",
         Description = "Bath Count",
         GroupName = Global.Tabs.Rollover,
         Order = 6400)]
        public virtual int BathCount { get; set; }

        [Display(
         Name = "Location",
         Description = "Location",
         GroupName = Global.Tabs.Rollover,
         Order = 6500)]
        [SelectOne(SelectionFactoryType = typeof(SelectRolloverLocation))]
        public virtual string Location { get; set; }

        #endregion

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 7100)]
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

        [Display(Name = "Contact No",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Contact No",
           Order = 2300)]
        public virtual string ContactNo { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get {return ContactNo; } }

        #endregion
    }
}
