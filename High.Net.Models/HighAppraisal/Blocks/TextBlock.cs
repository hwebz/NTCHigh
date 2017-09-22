using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighAppraisal.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HAPP,
        DisplayName = "Text Block",
        GUID = "dfec35ed-9f06-433a-a877-91ed3f930878",
        Description = "",
        Order=14010)]
    public class TextBlock : HighAppraisalBlockData
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