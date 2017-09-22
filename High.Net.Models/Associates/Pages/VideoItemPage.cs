using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(GroupName = SiteGroups.HA,
        DisplayName = "Video Item Page",
        GUID = "c73aa914-8a52-41f8-b30f-e11f886fec13",
        Description = "Page to display single video",
        Order = 7060)]    
    public class VideoItemPage : AssociatesPageData, IAssociates
    {
        #region Content

        [Display(
          Name = "Heading",
          Description = "Heading for page",
          GroupName = Global.Tabs.Content,
          Order = 1100)]
        public virtual String Heading { get; set; }

        [Display(
          Name = "Video Link",
          Description = "Livk for video",
          GroupName = Global.Tabs.Content,
          Order = 1200)]
        public virtual EPiServer.Url VideoLink { get; set; }

        [Display(
          Name = "Video Details",
          Description = "Information about video",
          GroupName = Global.Tabs.Content,
          Order = 1300)]
        public virtual XhtmlString VideoDetails { get; set; }

        #endregion
    }
}