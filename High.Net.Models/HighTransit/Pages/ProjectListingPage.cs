using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName=SiteGroups.HT,Order=16030, DisplayName = "Project Listing Page", GUID = "391b2808-15dd-479e-a0ee-00d748ff6adc", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ProjectItemPage) })]    
    public class ProjectListingPage : HighTransitPageData
    {
        #region Content

        [Display(Name = "Short Text",
                  GroupName = Global.Tabs.Content,
                  Description = "Short Text",
                  Order = 3010)]
        [UIHint(UIHint.LongString)]
        public virtual string ShortText { get; set; }

        #endregion
    }
}