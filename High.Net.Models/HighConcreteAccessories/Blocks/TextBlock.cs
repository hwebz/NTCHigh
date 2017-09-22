using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;

namespace High.Net.Models.HighConcreteAccessories.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "Text Block",
        GUID = "34c7e818-d219-4bdc-808b-f1a8d40a70ba",
        Description = "",
        Order=15001)]  
    public class TextBlock : HighAccessoriesBlockData
    {
        #region Content

        [Display(
            Name = "Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        public virtual XhtmlString Description { get; set; }

        #endregion

    }
}