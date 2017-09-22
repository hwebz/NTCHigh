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

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName = SiteGroups.HT, Order = 16060, DisplayName = "Service Item Page", GUID = "8e97c1b3-80bd-468c-b64d-7e196d6a698b", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage) })]    
    public class ServiceItemPage : HighTransitPageData
    {
        #region Images

        [Display(Name = "Page Icon (Width : 205 , Height : 160)",
         GroupName = Global.Tabs.Images,
         Description = "Page Icon",
         Order = 1010)]
        public virtual MediaReference PageIcon { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Page Short description",
           GroupName = Global.Tabs.Content,
           Description = "Page Short description",
           Order = 2010)]
        [UIHint(UIHint.LongString)]
        public virtual string PageIntroText { get; set; }

        [Display(
           Name = "Page description",
           GroupName = Global.Tabs.Content,
           Description = "Page description",
           Order = 2020)]
        [AllowedTypes(typeof(EquipmentBlock) ,typeof(TextBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}