using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Task Block",
        GUID = "6e758c98-011d-4585-9772-b38f902a8cf8",
        Description = "",
        Order=10500)]
    public class TaskBlock : HighNetBlockData
    {
        #region Content

        [Display(
            Name = "Task Heading",
            GroupName = Global.Tabs.Content,
            Description = "Heading of task",
            Order = 1100)]
        public virtual String TaskHeading { get; set; }

        [Display(
            Name = "Task Description",
            GroupName = Global.Tabs.Content,
            Description = "Description of task",
            Order = 1200)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString TaskDescription { get; set; }

        #endregion
    }
}