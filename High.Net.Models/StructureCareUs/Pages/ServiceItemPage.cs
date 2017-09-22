using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.StructureCareUs.Blocks;
using EPiServer.Web;

namespace High.Net.Models.StructureCareUs.Pages
{
    [SiteContentType(GroupName = SiteGroups.SCU, Order = 9050, DisplayName = "Service Item Page", GUID = "02fa37c5-49be-4a35-b41e-d013e71d66be", Description = "")]
    [SiteImageUrl]    
    public class ServiceItemPage : StructureCareUsPageData
    {

        #region Images

        [Display(Name = "Page Image",
        GroupName = Global.Tabs.Images,
        Description = "Page Image",
        Order = 1010)]
        public virtual MediaReference PageImage { get; set; }


        [Display(Name = "Page Icon (Width :80 , Height : 80)",
        GroupName = Global.Tabs.Images,
        Description = "Page Icon",
        Order = 1020)]
        public virtual MediaReference PageIcon { get; set; }

        [Display(
         Name = "Service Images",
         Description = "Images",
         GroupName = Global.Tabs.Images,
         Order = 1030)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ServiceImages { get; set; }
        
        #endregion

        #region Content

        [Display(Name = "Introduction Text",
        GroupName = Global.Tabs.Content,
        Description = "Introduction Text",
        Order = 2110)]
        [UIHint(UIHint.LongString)]
        public virtual string IntroText { get; set; }

        [Display(Name = "Main Content Area",
        GroupName = Global.Tabs.Content,
        Description = "Content Area",
        Order = 2120)]
        [AllowedTypes(typeof(TextBlock),typeof(ImageTextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion

    }
}