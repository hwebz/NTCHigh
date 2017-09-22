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
        DisplayName = "Image Table",
        GUID = "6041c3dc-ddde-4398-b929-3ff53c95dae6",
        Description = "",
        Order = 10790)]
    public class ImageTable : HighNetBlockData
    {
        [Display(
            Name = "Image Items",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display image items",
            Order = 100)]
        [AllowedTypes(typeof(ImageTableItemBlock))]
        public virtual ContentArea ImageItems { get; set; }
    }
}