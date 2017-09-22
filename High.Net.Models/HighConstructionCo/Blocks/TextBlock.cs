using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighConstructionCo.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HCC,
        DisplayName = "Text Block",
        GUID = "1db36682-4dd1-4424-af79-e3755ecb881b",
        Description = "",
        Order=17010)]
    public class TextBlock : HighConstructionCoBlockData
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