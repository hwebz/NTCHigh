using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighSteelStructure.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "TextBlock",
        GUID = "b822b3da-8868-4cdb-8bb8-b0d01a930b1b",
        Description = "",
        Order=18010)]
    public class TextBlock : HighSteelStructureBlockData
    {
        #region Content

            [Display(
                Name = "Heading",
                GroupName = Global.Tabs.Content,
                Description = "",
                Order = 1100)]
            public virtual String Heading { get; set; }

            [Display(
                Name = "Text",
                GroupName = Global.Tabs.Content,
                Description = "",
                Order = 1200)]
            public virtual XhtmlString Text { get; set; }

        #endregion
    }
}