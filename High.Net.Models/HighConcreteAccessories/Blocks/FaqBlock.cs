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
        DisplayName = "Faq Block", 
        GUID = "f6d96a8e-2ee2-411a-a320-ac01b98fa48e",
        Description = "",
        Order=15010)]    
    public class FaqBlock : HighAccessoriesBlockData
    {
        #region Content

        [Display(
            Name = "Question",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        public virtual String Question { get; set; }

        [Display(
            Name = "Text",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1200)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}