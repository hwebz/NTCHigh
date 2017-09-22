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
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "Project Item Page", 
        GUID = "58642203-aa10-4cc7-b651-3c375958bb4a",
        Description = "",
        Order=18030)]    
    public class ProjectItemPage : HighSteelStructurePageData
    {
        #region Image

        [Display(
            Name = "Project Image (Width : 262 , Height : 232)",
            GroupName = Global.Tabs.Images,
            Description = "Image is used on listing pages",
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        [Display(
            Name = "Project Image Slider (Width : 454 , Height : 337)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Slider { get; set; }

        #endregion   

        #region Content

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2100)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Image text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        public virtual String ImageText { get; set; }

        [Display(
            Name = "Intro text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
            Name = "Description",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2400)]
        public virtual XhtmlString Description { get; set; }

        [Display(
            Name = "Bridge Project Type",
            GroupName = Global.Tabs.Content,
            Description = "Bridge Project Type",
            Order = 2500)]
        [SelectMany(SelectionFactoryType = typeof(SelectBridgeProjectType))]
        public virtual String BridgeProjectType { get; set; }

        #endregion 
    }
}