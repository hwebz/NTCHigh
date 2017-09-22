using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;
using High.Net.Models.Shared.Blocks;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Image Text Block",
        GUID = "ea8209eb-3527-47d9-ade3-90088757d0a3",
        Description = "",
        Order = 10520)]
    public class ImageTextBlock : HighNetBlockData, IHaveMultipleTemplates
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

        [Display(
           Name = "Html Text",
           GroupName = Global.Tabs.Content,
           Description = "use to format text content",
           Order = 2300)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString HtmlText { get; set; }

        [Display(
           Name = "Site Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2400)]
        public virtual EPiServer.Url SiteLink { get; set; }               

        [Display(
          Name = "View Template",
          GroupName = Global.Tabs.TemplateSettings,
          Description = "View Template",
          Order = 180)]
        [UIHint(HighUIHint.ImageTextBlockTemplatesSelection)]
        public virtual string ViewTemplate { get; set; }
        #endregion

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.ViewTemplate = ImageTextViewTemplate.ImageInLeft;
        }
    }
}