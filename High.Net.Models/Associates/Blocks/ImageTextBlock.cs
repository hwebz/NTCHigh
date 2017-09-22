using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.Associates.Blocks
{
    [ContentType(
        GroupName= SiteGroups.HA,
        DisplayName = "Image Text Block",
        GUID = "25b896df-3d9f-4299-9d16-21edaf1bcd0a",
        Description = "",
        Order=7530)]
    public class ImageTextBlock : AssociatesBlockData
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
           Name = "Heading",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        [Display(
           Name = "Text",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2200)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual String Text { get; set; }

        #endregion
    }
}