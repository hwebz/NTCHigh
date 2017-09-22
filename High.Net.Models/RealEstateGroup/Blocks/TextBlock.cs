using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(GroupName = SiteGroups.REG, DisplayName = "Text Block", Order = 8040, GUID = "107f035f-4bc7-43b9-b789-3f2f7163bbee", Description = "")]
    public class TextBlock : RealEstateGroupBlockData
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