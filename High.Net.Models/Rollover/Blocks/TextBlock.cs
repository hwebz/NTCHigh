using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(GroupName = SiteGroups.RO, DisplayName = "Text Block", Order = 11050, GUID = "a09c65ac-b3e9-451e-b324-76ab6c613b3c", Description = "")]
    public class TextBlock : RolloverBlockData
    {
        #region Content
            
        [CultureSpecific]
        [Display(
            Name = "Introduction Text",
            Description = "Text Area",
            GroupName = Global.Tabs.Content,
            Order = 200)]
        public virtual XhtmlString IntroText { get; set; }

        #endregion
    }
}