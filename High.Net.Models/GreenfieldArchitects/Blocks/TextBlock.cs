using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.GreenfieldArchitects.Blocks
{
    [ContentType(GroupName = SiteGroups.GAL,
        DisplayName = "Text Block",
        GUID = "E3093C3F-C912-4087-833A-C38858FF7F3E",
        Description = "Standard text block",
        Order = 19001)]
    public class TextBlock : GreenfieldArchitectsBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "Description",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual XhtmlString Description { get; set; }
    }
}