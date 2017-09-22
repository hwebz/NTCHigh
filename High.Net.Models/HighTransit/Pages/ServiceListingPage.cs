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

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName = SiteGroups.HT, Order = 16050, DisplayName = "Service Listing Page", GUID = "ff3e7b69-9531-4fbb-981b-d0d4adc6cccf", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ServiceItemPage) })]    
    public class ServiceListingPage : HighTransitPageData
    {
        #region Images

        [Display(Name = "Page Image Site Logo (Width : 485 , Height : 485)",
         GroupName = Global.Tabs.Images,
         Description = "Page Image",
         Order = 1010)]
        public virtual MediaReference PageImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Page description",
           GroupName = Global.Tabs.Content,
           Description = "Page description",
           Order = 2020)]
        public virtual XhtmlString PageDescription { get; set; }

        #endregion
    }
}