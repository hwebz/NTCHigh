using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Pages;
using High.Net.Models.HighNet;
using High.Net.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Full-Width Call Out",
        GUID = "a370eb88-d2b8-4d71-9763-51a871954202",
        Description = "",
        Order = 10750)]
    public class FullWidthCalloutBlock : HighNetBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title of the block",
            GroupName = SystemTabNames.Content,
            Order = 1022)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Body",
            Description = "Body of the block",
            GroupName = SystemTabNames.Content,
            Order = 1030)]
        [DataType(DataType.MultilineText)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString Body { get; set; }

        [Display(
            Name = "BackGround Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1040)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
            Name = "Text Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1050)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string TextColor { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Hyperlink",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1060)]

        public virtual Url Hyperlink { get; set; }

        #endregion
    }
}