using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR, 
        DisplayName = "Projects Block",
        GUID = "f72ed933-1714-4d69-8418-9bd901bdf6c3",
        Description = "",
        Order=5570)]
    public class ProjectsBlock : ResidentialBlockData
    {
        #region content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Address",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual XhtmlString Address { get; set; }

        #endregion
    }
}