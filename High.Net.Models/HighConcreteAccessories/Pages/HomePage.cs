using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Shared.Pages;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighConcreteAccessories.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "Home Page",
        GUID = "38edf3a6-0f55-4c5c-8627-b78331a48a59",
        Description = "",
        Order = 15001)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage), typeof(High.Net.Models.Shared.Pages.ContainerPage), 
        typeof(SearchPage), typeof(OrderProductPage) , typeof(NewsLetterPage) , typeof(AskTheExpertPage), typeof(ContactUsPage) })]
    public class HomePage : HighConcreteAccessoriesPageData, IHome, IHighConcreteAccessories
    {
        #region Image

        [Display(
            Name = "Site Logo (Width : 253 , Height : 44)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(
            Name = "Header Image (Width : 300 , Height : 34)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1200)]
        public virtual MediaReference HeaderImage { get; set; }

        [Display(
            Name = "Banner Image (Width : 460 , Height : 247)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1300)]
        public virtual MediaReference BannerImage { get; set; }

        [Display(
            Name = "About Content Image (Width : 285 , Height : 208)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1400)]
        public virtual MediaReference ContentImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Banner Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2110)]
        public virtual String BannerText { get; set; }

        [Display(
            Name = "About Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2120)]
        public virtual XhtmlString AboutText { get; set; }

        [Display(
            Name = "Order Product Bar Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2130)]
        public virtual String OrderProductHeading { get; set; }

        [Display(
            Name = "Order Product Bar Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2140)]
        public virtual XhtmlString OrderProductText { get; set; }

        [Display(
            Name = "Order Product Bar Link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2150)]
        public virtual EPiServer.Url OrderProductLink { get; set; }

        [Display(
           Name = "Order Product Free Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2150)]
        public virtual XhtmlString OrderProductFreeText { get; set; }

        [Display(
            Name = "Address",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2160)]
        public virtual String Address { get; set; }

        [Display(
            Name = "Contact",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2170)]
        public virtual String Contact { get; set; }

        [Display(
            Name = "Email Id",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2180)]
        public virtual String EmailID { get; set; }

        [Display(
            Name = "Copy Right Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2190)]
        public virtual String CopyRightText { get; set; }

        [Display(
            Name = "Fax No",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual String FaxNo { get; set; }

        [Display(
            Name = "High net link",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2210)]
        public virtual EPiServer.Url HighNetLink { get; set; }

        [Display(Name = "Search Page Url",
          GroupName = Global.Tabs.Content,
          Description = "Search Page Reference",
          Order = 2220)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Commerce Settings

        [Display(
          Name = "My Account Url",
          GroupName = Global.Tabs.Commerce,
          Description = "",
          Order = 3200)]
        public virtual String MyAccountUrl { get; set; }

        [Display(
        Name = "View Cart URL",
        GroupName = Global.Tabs.Commerce,
        Description = "",
        Order = 3300)]
        public virtual String ViewCartURL { get; set; }

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

        public string BusinessContactNumber { get { return Contact; } }

        #endregion

    }
}