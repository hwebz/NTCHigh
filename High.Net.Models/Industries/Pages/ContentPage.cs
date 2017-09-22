using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.Industries.Blocks;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.Industries.Pages
{
    [SiteContentType(GroupName = SiteGroups.HII,
        Order = 4020, DisplayName = "Content Page", GUID = "48f44c7e-9f46-473b-9259-aaeae3d0c765", Description = "Content Page")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage), typeof(CommonListingPage), typeof(LocationPage) })]
    public class ContentPage : IndustriesPageData
    {
        #region Content

        [Display(Name = "Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2110)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock), typeof(AboutBlock), typeof(MembersBlock), typeof(CEOBlock), typeof(BusinessBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion

    }
}