using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "History Block",
        GUID = "08a69ac6-77b0-46af-8b58-242602b60711",
        Description = "",
        Order=10560)]
    public class HistoryBlock : HighNetBlockData
    {
        #region Content

        [Display(
           Name = "History Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea HistoryContent  { get; set; }

        #endregion
    }
}