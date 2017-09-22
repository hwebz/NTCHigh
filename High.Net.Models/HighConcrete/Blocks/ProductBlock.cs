using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using ImageVault.EPiServer;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighConcrete.Blocks
{
    [ContentType(GroupName = SiteGroups.HC, DisplayName = "Product Block", Order = 13090, GUID = "3101130f-6f7c-4fd2-b42c-ba491913bdf1", Description = "")]
    public class ProductBlock : HighConcreteBlockData
    {
        #region Images

        [Display(
           Name = "Image (Width : 116 , Height : 116)",
           GroupName = Global.Tabs.Images,
           Description = "",
           Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        [CultureSpecific]
        public virtual string Text { get; set; }

        [Display(
           Name = "Target link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2200)]
        public virtual PageReference TargetLink { get; set; }

        #endregion
    }
}