using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using EPiServer.Shell.ObjectEditing;
using EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Layered Image Content Block",
        GUID = "c5f5ac38-b910-489c-ab0d-3c6f843c7f0d",
        Description = "",
        Order = 10790)]
    public class CSSLayeredImageContentBlock : HighNetBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title of the block",
            GroupName = SystemTabNames.Content,
            Order = 1000)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Body",
            Description = "Body of the block",
            GroupName = SystemTabNames.Content,
            Order = 1010)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString Body { get; set; }

        [Display(
           Name = "Background Color",
           Description = "",
           GroupName = SystemTabNames.Content,
           Order = 1020)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
           Name = "Font Color",
           Description = "",
           GroupName = SystemTabNames.Content,
           Order = 1030)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string FontColor { get; set; }

        [Display(
            Name = "Bullet Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1032)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BulletColor { get; set; }

        [Display(
           Name = "Hyperlink",
           Description = "",
           GroupName = SystemTabNames.Content,
           Order = 1040)]
        public virtual Url Hyperlink { get; set; }

        #endregion

        #region Image

        [Display(
            Name = "Background Image",
            Description = "",
            GroupName = High.Net.Core.Global.Tabs.Images,
            Order = 1200)]
        public virtual MediaReference BackGroundImage { get; set; }

        #endregion
    }
}