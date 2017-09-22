using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Models.SelfStorage.Blocks;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;

namespace High.Net.Models.SelfStorage.Pages
{
    [SiteContentType(GroupName = SiteGroups.PSS,
        DisplayName = "Content Page",
        GUID = "91eb9485-8e84-4aa8-8fa2-483062a0be7c",
        Description ="Standard content page",
        Order=2010
        )]    
    [AvailableContentTypes(
      Availability.None)]
    public class ContentPage : SelfStoragePageData, ISelfStorage
    {

        #region Images

        [Display(GroupName = Global.Tabs.Images,
            Description = "Image Banner",
            Order = 1100)]
        public virtual MediaReference ImageBanner { get; set; }

        #endregion

        #region Content

        [Display(
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}