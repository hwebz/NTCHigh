using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighTransit.Blocks
{
    [ContentType(GroupName = SiteGroups.HT, Order = 16070, DisplayName = "Text Block", GUID = "17b3a2c5-24ba-4c93-85c3-94c7062cdf53", Description = "")]
    public class TextBlock : HighTransitBlockData
    {
        #region Content

        [Display(
          Name = "Heading",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 1100)]
        public virtual String Heading { get; set; }

        [Display(
          Name = "Description",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 1200)]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}