using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Web;
using ImageVault.EPiServer;
using EPiServer.Shell.ObjectEditing;
using EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "News Tiles: Single", GUID = "494130f5-ad48-42df-b492-1d1e8e569c74", Description = "", Order = 10100)]
    public class OtherTilesBlock : HighNetBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Tile Name",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1010)]
        public virtual string TileName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Worker Name",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1020)]
        public virtual string Workername { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Tile Text",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1030)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString TileText { get; set; }

        [CultureSpecific]
        [Display(
            Name = "BackGround Image",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1040)]

        public virtual MediaReference BackGroundImage { get; set; }

        [Display(
            Name = "BackGround Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1050)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
            Name = "Text Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1060)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string TextColor { get; set; }

        [Display(
            Name = "Bullet Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1062)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BulletColor { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Redirect Link",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1070)]

        public virtual Url RedirectUrl { get; set; }
    }
}