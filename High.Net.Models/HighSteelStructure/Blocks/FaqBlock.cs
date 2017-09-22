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
        DisplayName = "Faq Block",
        GUID = "c7a5800d-8a4c-44a5-b160-ac9784e18a50",
        Description = "",
        Order=18040)]
    public class FaqBlock : HighSteelStructureBlockData
    {
        #region Content

        [Display(
            Name = "Question",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1100)]
        public virtual String Question { get; set; }

        [Display(
            Name = "Answer",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1200)]
        public virtual XhtmlString Answer { get; set; }

        #endregion
    }
}