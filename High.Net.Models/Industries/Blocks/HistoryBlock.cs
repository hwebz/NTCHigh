using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HII,
        DisplayName = "History Block",
        GUID = "e2059e67-8eea-4034-baef-079561468a94",
        Description = "",
        Order=4060)]
    public class HistoryBlock : IndustriesBlockData
    {
        #region Content

        [Display(
            Name = "History Content",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea HistoryContent { get; set; }

        #endregion
    }
}