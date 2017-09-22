using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Core.Attributes;
using High.Net.Core.ContentTypes.Blocks;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Constants;
using High.Net.Models.Humanity.Blocks;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Humanity.Pages
{
    [SiteContentType(
       GroupName = SiteGroups.EOH,
       DisplayName = "Home Page",
       Order = 1010,
       GUID = "4ced4de9-d59b-4f44-ad4a-2ef91922114f",
       Description = "Essence of Humanity - Home page")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage), typeof(NewsListingPage), typeof(ToolkitPage), typeof(SearchPage), typeof(ContactUsPage) })]
    public class HomePage : HumanityPageData, IHome, IHumanity
    {
        #region Images

        [Display(Name = "Site Logo (Width : 354 , Height : 216)",
            GroupName = Global.Tabs.Images,
            Description = "Site Logo",
            Order = 1100)]
        //[MedSettingsAttribute(10, 10)]
        public virtual MediaReference SiteLogo { get; set; }

        [Display(Name = "Broadcast News Logo (Width : 115 , Height : 48)",
          GroupName = Global.Tabs.Images,
           Description = "View Broadcast Image",
          Order = 1200)]
        public virtual MediaLink BroadcastNewsLogoImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Header Text",
            GroupName = Global.Tabs.Content,
            Description = "Header Text",
            Order = 2100)]
        [UIHint(UIHint.Textarea)]
        public virtual string HeaderText { get; set; }

        [Display(Name = "Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2200)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(Name = "Contact No",
            GroupName = Global.Tabs.EmailSetting,
            Description = "Contact No",
            Order = 2300)]
        public virtual string ContactNo { get; set; }

        [Display(Name = "Search Page Url",
          GroupName = Global.Tabs.Content,
          Description = "Search Page Reference",
          Order = 2800)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageUrl { get; set; }

        #endregion

        #region Google Analytics

        [Display(
             Name = "Google Analytics Code",
             Description = "Google Analytics",
             GroupName = Global.Tabs.Content,
             Order = 3100)]
        public virtual string GoogleAnalytics { get; set; }

        public string NameInEmail { get { return Name; } }

        public string BusinessContactNumber { get { return ContactNo; } }

        #endregion
    }
}
