using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Models.Residential.Blocks;
using High.Net.Core;
using EPiServer.Web;


namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(GroupName = SiteGroups.BR,
        DisplayName = "Content Page",
        GUID = "a6793647-74f9-4663-97a9-9854902885d6",
        Description = "standard page for site",
        Order = 5010)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(SalesListingPage) , typeof(ContentPage) , typeof(EventListingPage),
        typeof(ApplyNowPage)})]
    public class ContentPage : ResidentialPageData, IResidential
    {
        #region Content

        [Display(
          Name = "Content Area",
          Description = "",
          GroupName = Global.Tabs.Content,
          Order = 1100)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(TextBlock), typeof(GalleryBlock), typeof(StaffBlock) })]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}