using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using High.Net.Models.Commercial.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.Commercial.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.B2B,
        DisplayName = "Content Page",
        GUID = "a65edaa8-6baf-490f-90d5-00c65ec59dfb",
        Description = "Content Page",
        Order = 3020)]
    [AvailableContentTypes(
       Availability.None)]    
    public class ContentPage : CommercialPageData, ICommercial
    {
        #region Content

        [CultureSpecific]
        [Display(GroupName = Global.Tabs.Content,
           Description = "Page Content Area",
           Order = 2300)]
        [AllowedTypes(typeof(LinkItemBlock), typeof(TextBlock) , typeof(ImageGalleryBlock))]
        public virtual ContentArea PageContentArea { get; set; }


        #endregion
    }
}