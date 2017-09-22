using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;
using ImageVault.EPiServer;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "News Tiles: Dynamic", GUID = "4c4471b9-917f-425f-b167-f7bd10862561", Description = "", Order = 10620)]
    public class NewsBlock : HighNetBlockData
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
            Name = "BackGround Image",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1040)]

        public virtual MediaReference BackGroundImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "BackGround Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1050)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1060)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string TextColor { get; set; }


       



    }
}