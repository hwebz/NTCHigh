using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.Commercial.Blocks
{
    [ContentType(
        GroupName = SiteGroups.B2B, 
        DisplayName = "Text Block", 
        GUID = "b31e9b8f-ff29-4404-83b9-96f1ad91ee06",
        Description = "Text Block with heading and text",
        Order = 3510)]
    public class TextBlock : CommercialBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(Name = "Heading",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(Name = "Text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}