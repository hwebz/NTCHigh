using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.HighConcrete.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "ImageTextBlock", 
        GUID = "eaf780dc-cb4f-49bc-a807-005016098922",
        Description = "Use to display image with text",
        Order=13001)]
    public class ImageTextBlock : HighConcreteBlockData
    {
        #region Images

        [Display(
           Name = "Image",
           GroupName = Global.Tabs.Images,
           Description = "",
           Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
          Name = "Open Link In New Window",
          Description = "Open Link In New Window",
          GroupName = Global.Tabs.Content,
          Order = 2100)]
        public virtual bool OpenLinkInNewWindow { get; set; }

        [Display(
           Name = "Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2120)]
        [CultureSpecific]
        public virtual XhtmlString Text { get; set; }

        [Display(
           Name = "Target link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2140)]
        public virtual PageReference TargetLink { get; set; }

        #endregion
    }
}