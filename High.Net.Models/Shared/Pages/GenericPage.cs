using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Shared.Blocks;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;
using EPiServer.Framework.DataAnnotations;

namespace High.Net.Models.Shared.Pages
{
    [ContentType(GroupName = SiteGroups.Global, DisplayName = "Generic Page", GUID = "5cae98d0-d939-4298-83cc-0bf98fa048e2", Description = "", Order = 85)]
    [AvailableContentTypes(IncludeOn=new Type[]{typeof(BasePageData)})]
    [SiteImageUrl]
    public class GenericPage : BasePageData
    {
        #region Content

        [Display(
           Name = "Select Container Type",
           Description = "Select Container Type",
           GroupName = Global.Tabs.Content,
           Order = 1100)]
        [SelectOne(SelectionFactoryType = typeof(SelectContainerType))]
        public virtual string SelectContainerType { get; set; }
        
        [Display(
           Name = "Select Page Background Color",
           Description = "Select Background Color for Page",
           GroupName = Global.Tabs.Content,
           Order = 1110)]
        [SelectOne(SelectionFactoryType = typeof(SelectBackgroundColor))]
        public virtual string SelectBackgroundColor { get; set; }

        [Display(
           Name = "Header Content Area",
           Description = "Header Content Area",
           GroupName = Global.Tabs.Content,
           Order = 1120)]
        [AllowedTypes(typeof(GenericBlock))]
        public virtual ContentArea HeaderContentArea { get; set; }

        [Display(
           Name = "Body Content Area",
           Description = "Body Content Area",
           GroupName = Global.Tabs.Content,
           Order = 1130)]
        [AllowedTypes(typeof(GenericBlock))]
        public virtual ContentArea BodyContentArea { get; set; }

        [Display(
           Name = "Footer Content Area",
           Description = "Footer Content Area",
           GroupName = Global.Tabs.Content,
           Order = 1140)]
        [AllowedTypes(typeof(GenericBlock))]
        public virtual ContentArea FooterContentArea { get; set; }

        #endregion
    }
}