using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.SteelServiceCentre.Blocks
{
    [ContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Text Block",
        GUID = "fecf478d-6b15-4c68-8b31-5fecb62c5af0",
        Description = "",
        Order=6530)]
    public class TextBlock : SteelServiceCentreBlockData
    {
        #region Content

        [Display(
           Name = "Heading",
           GroupName = Global.Tabs.Content,
           Description = "Heading",
           Order = 1100)]
        public virtual string Heading { get; set; }

        [Display(
           Name = "Text",
           GroupName = Global.Tabs.Content,
           Description = "Text",
           Order = 1200)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}