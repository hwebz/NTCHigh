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
using High.Net.Models.SteelServiceCentre.Blocks;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [ContentType(
        GroupName = SiteGroups.SSC, 
        DisplayName = "Project Item Page",
        GUID = "6d8676c1-1085-4c08-abed-0a52481170dc",
        Description = "",
        Order=6060)]    
    public class ProjectItemPage : SteelServiceCentrePageData
    {
        #region Images

        [Display(
        Name = "Project Image (Width : 360 , Height : 239)",
        GroupName = Global.Tabs.Images,
        Description = "",
        Order = 1100)]
        public virtual MediaReference ProjectImage { get; set; }

        [Display(
        Name = "Project Image Slider (Width : 442 , Height : 379)",
        GroupName = Global.Tabs.Images,
        Description = "",
        Order = 1200)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ProjectImageSlider { get; set; }

        #endregion

        #region Content

        [Display(
        Name = "Project Name",
        GroupName = Global.Tabs.Images,
        Description = "",
        Order = 2200)]
        public virtual String ProjectName { get; set; }

        [Display(
        Name = "Project Owner",
        GroupName = Global.Tabs.Images,
        Description = "",
        Order = 2200)]
        public virtual String ProjectOwner { get; set; }

        [Display(
        Name = "Project Intro Text",
        GroupName = Global.Tabs.Images,
        Description = "",
        Order = 2300)]
        [UIHint(UIHint.LongString)]
        public virtual String ProjectIntroText { get; set; }

        [Display(
        Name = "Project Summery",
        GroupName = Global.Tabs.Content,
        Description = "",
        Order = 2400)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

    
        #endregion
    }
}