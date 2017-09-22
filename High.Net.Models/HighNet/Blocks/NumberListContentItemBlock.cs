using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Validation;
using ImageVault.EPiServer;
using System.ComponentModel.DataAnnotations;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Numbered-List Content Item",
        GUID = "e4755327-6ac4-4459-8b78-ae242c195042",
        Description = "",
        Order = 10790)]
    public class NumberListContentItemBlock : HighNetBlockData
    {
        [Display(
          Name = "BackGround Color",
          Description = "",
          GroupName = SystemTabNames.Content,
          Order = 1200)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
             Name = "Html Text",
             GroupName = Global.Tabs.Content,
             Description = "use to format text content",
             Order = 1300)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString HtmlText { get; set; }

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "Heading",
            Order = 1400)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Background Char",
            GroupName = Global.Tabs.Content,
            Description = "Background Char",
            Order = 1500)]
        [CultureSpecific]
        public virtual string BackgroundChar { get; set; }

        [Display(
            Name = "Images Collection",
            GroupName = Global.Tabs.Images,
            Description = "Images collection",
            Order = 1520)]
        [CultureSpecific]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> ImageCollection { get; set; }

        [Display(
            Name = "Image Caption",
            GroupName = Global.Tabs.Images,
            Description = "Image caption",
            Order = 1530)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString ImageCaption { get; set; }

        [Display(
            Name = "View All Images Text",
            GroupName = Global.Tabs.Images,
            Description = "View All Images Text",
            Order = 1500)]
        [CultureSpecific]
        public virtual string ViewAllImagesText { get; set; }
        
    }
}