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
using High.Net.Models.HighConcrete.Blocks;
using High.Net.Core.ContentTypes.Blocks;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Product Item Page",
        GUID = "2233f409-28a2-4b0f-b9dd-44ba53895eaa",
        Description = "",
        Order=13110)]    
    [AvailableContentTypes(Availability.None)]
    public class ProductItemPage : LeftNavigationPage
    {
        #region Images

        [Display(
           Name = "Product Images (Width : 277 , Height : 322)",
           Description = "",
           GroupName = Global.Tabs.Images,
           Order = 1100)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Images { get; set; }

        #endregion

        #region Content

        [Display(
         Name = "Main Content Area",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1200)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageTextBlock), typeof(ExpandCollapseBlock), typeof(PopupBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        #endregion 
    }
}