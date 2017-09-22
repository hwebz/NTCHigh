using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighHotels.Blocks;

namespace High.Net.Models.HighHotels.Pages
{
    [SiteContentType(GroupName= SiteGroups.HH, Order = 12020, DisplayName = "Content Page", GUID = "577ef695-ce00-4762-81a9-ef9feb260edd", Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.Specific,
      Include = new[] { typeof(ContentPage) })]    
    public class ContentPage : HighHotelsPageData
    {
        #region Content

        [Display(Name = "Content Area",
        Description = "Content Area",
        GroupName = Global.Tabs.Content,
        Order = 100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea PageContentArea { get; set; }


        #endregion
    }
}