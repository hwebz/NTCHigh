using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighConstructionCo.Blocks
{
     [ContentType(
        GroupName = SiteGroups.HCC,
        DisplayName = "ImageTextBlock",
        GUID = "72958C96-C368-458A-A4ED-1F10CF799DE9",
        Description = "Use to display image with text and link",
        Order = 17001)]
    public class ImageTextBlock : HighConstructionCoBlockData
    {
        #region Images

        [Display(
           Name = "Image (Width : 94 , Height : 94)",
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
        public virtual XhtmlString Text { get; set; }

        [Display(
           Name = "Target Page Link",
           GroupName = Global.Tabs.Content,
           Description = "Link to target page",
           Order = 2200)]
        public virtual EPiServer.Url TargetLink { get; set; }

        #endregion
    }
}
