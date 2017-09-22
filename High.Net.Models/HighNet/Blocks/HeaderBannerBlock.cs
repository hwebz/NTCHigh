using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Header Banner", GUID = "f15180c6-806e-4e0d-9a06-80f765701498", Description = "", Order = 10640)]
    public class HeaderBannerBlock : HighNetBlockData
    {

        #region Content

        [Display(
            Name = "Background Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1010)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
            Name = "Text Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1020)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string TextColor { get; set; }

        [Display(
            Name = "Header Banner Item",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display header banner items",
            Order = 1030)]
        [AllowedTypes(typeof(HeaderBannerItemBlock))]
        public virtual ContentArea HeaderBanner { get; set; }

        #endregion

    }
}