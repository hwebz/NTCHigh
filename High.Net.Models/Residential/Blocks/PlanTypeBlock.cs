using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR, 
        DisplayName = "Plan Type Block",
        GUID = "588225cb-f26a-44d1-a534-2dc273fa702d",
        Description = "",
        Order=5530)]
    public class PlanTypeBlock : ResidentialBlockData
    {
        #region content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Name field's description",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "FloorPlanArea",
            Description = "Name field's description",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        [AllowedTypes( new[] { typeof(FloorPlansBlock)})]
        public virtual ContentArea FloorPlanArea { get; set; }

        #endregion
    }
}