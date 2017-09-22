using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Humanity.Blocks
{
    [ContentType(
        GroupName= SiteGroups.EOH,
        DisplayName = "Plain Text Block",
        GUID = "bd656661-597c-48c5-a070-1532cbf08627",
        Description = "",
        Order=1030)]
    public class PlainTextBlock : HumanityBlockData
    {
        #region Content

        
        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text of the block",
            GroupName = Global.Tabs.Content,
            Order = 200)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}