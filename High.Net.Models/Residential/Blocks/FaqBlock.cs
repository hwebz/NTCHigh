using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR, 
        DisplayName = "Faq Block",
        GUID = "19cca9fb-b5de-4880-9d71-90605e865f2e",
        Description = "Block For Freaquently Asked Questions",
        Order = 5150)]
    public class FaqBlock : ResidentialBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(
            Name = "Question",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        [UIHint(UIHint.LongString)]
        public virtual String Question { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Answer",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1200)]
        [UIHint(UIHint.LongString)]
        public virtual String Answer { get; set; }

        #endregion

    }
}