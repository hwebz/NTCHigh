using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.HighConstructionCo.Blocks;

namespace High.Net.Models.HighConstructionCo.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCC,
        DisplayName = "Content Page",
        GUID = "5874464e-2af9-493e-af14-6bc9ba28ad6f",
        Description = "",
        Order = 17010)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(ContentPage) } )]
    public class ContentPage : HighConstructionCoPageData
    {
        #region Content

        [Display(
           Name = "Main Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion
    }
}