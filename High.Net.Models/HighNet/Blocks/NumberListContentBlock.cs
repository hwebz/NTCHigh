using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Blocks;
using High.Net.Models.Validation;
using System.ComponentModel.DataAnnotations;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Numbered-List Content Block",
        GUID = "b6262561-ea7c-412c-900f-9032cfe2d606",
        Description = "",
        Order = 10780)]
    public class NumberListContentBlock : HighNetBlockData, IHaveMultipleTemplates
    {
        [Display(
        Name = "Page Content",
        GroupName = Global.Tabs.Content,
        Description = "Content Area to display tasks",
        Order = 1100)]
        [AllowedTypes(typeof(NumberListContentItemBlock))]
        public virtual ContentArea NumberListContentContentArea { get; set; }

        [Display(
         Name = "Body",
         GroupName = Global.Tabs.Content,
         Description = "use to format text content",
         Order = 1200)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString Body { get; set; }

        [Display(
            Name = "Main Heading",
            GroupName = Global.Tabs.Content,
            Description = "Heading",
            Order = 1300)]
        [CultureSpecific]
        public virtual string MainHeading { get; set; }

        [Display(
        Name = "View Template",
        GroupName = Global.Tabs.TemplateSettings,
        Description = "View Template",
        Order = 180)]
        [UIHint(HighUIHint.NumbericBlockTemplatesSelection)]
        public virtual string ViewTemplate { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.ViewTemplate = NumbericContentViewTemplate.NumbericTextOnly;
        }

    }
}