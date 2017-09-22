using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Models.Commercial.Blocks
{
    [ContentType(
        GroupName = SiteGroups.B2B, 
        DisplayName = "Image Text Block",
        GUID = "8ff1188c-f66b-488d-8767-4aacf87b569c",
        Description = "",
        Order=3550)]
    public class ImageTextBlock : CommercialBlockData
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