using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;

namespace High.Net.Models.Commercial.Blocks
{
    [ContentType(
        GroupName = SiteGroups.B2B, 
        DisplayName = "Link Item Block", 
        GUID = "45f56207-970a-4236-b185-1619ebbb3def", 
        Description = "Links to various Pages",
        Order = 3520)]
    [SiteImageUrl]
  
    public class LinkItemBlock : CommercialBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(Name = "Title",
            Description = "Title of the section",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual String Title { get; set; }

        [Display(Name = "Page Links",
          GroupName = Global.Tabs.Content,
          Description = "Links to various pages",
          Order = 200)]
        public virtual LinkItemCollection PageLinks { get; set; }

        #endregion
    }
}