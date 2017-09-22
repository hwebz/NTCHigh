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

namespace High.Net.Models.HighTransit.Pages
{
    [SiteContentType(GroupName = SiteGroups.HT, Order = 16040, DisplayName = "Project Item Page", GUID = "4badee3c-d4a5-4c07-b7a6-7df780199b33", Description = "")]
    [SiteImageUrl]
    public class ProjectItemPage : HighTransitPageData
    {
        #region Images

        [Display(Name = "Page Icon (Width : 313 , Height : 296)",
         GroupName = Global.Tabs.Images,
         Description = "Page Icon",
         Order = 1010)]
        public virtual MediaReference PageIcon { get; set; }

        [Display(
         Name = "Project Gallery (Width : 227 , Height : 173)",
         Description = "Project Gallery",
         GroupName = Global.Tabs.Images,
         Order = 1020)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ProjectGallery { get; set; }

        #endregion

        #region Content

        [Display(Name = "Page Short description",
           GroupName = Global.Tabs.Content,
           Description = "Page Short description",
           Order = 2020)]
        [UIHint(UIHint.LongString)]
        public virtual string PageIntroText { get; set; }

        [Display(Name = "Page Detail Text",
          GroupName = Global.Tabs.Content,
          Description = "Page Detail Text",
          Order = 2030)]
        public virtual XhtmlString PageDetailText { get; set; }

        #endregion
    }
}