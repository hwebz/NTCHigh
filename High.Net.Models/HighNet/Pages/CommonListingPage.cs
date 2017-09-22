using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Pages
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Common Listing Page",
        GUID = "C28703EA-3A68-4BF6-A1DF-A332244A8351",
        Description = "Common Listing Page",
        Order=10040)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(CommonItemPage), typeof(CommonListingPage) })]
    public class CommonListingPage : HighNetPageData, IHighNet
    {
        #region Content

        [Display(
           Name = "Page Description",
           GroupName = Global.Tabs.Content,
           Description = "Page Description appears on top of page.",
           Order = 2200)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString PageDescription { get; set; }

        #endregion
    }
}