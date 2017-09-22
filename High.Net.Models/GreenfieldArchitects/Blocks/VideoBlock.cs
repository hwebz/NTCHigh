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
        DisplayName = "Video Block",
        GUID = "5DD8E070-6B5D-4D76-8130-8EF25FB54FE1",
        Description = "Video Block",
        Order = 19010)]
    public class VideoBlock : GreenfieldArchitectsBlockData
    {
        #region Content

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

        #endregion

        #region Url

        [CultureSpecific]
        [Display(
            Name = "Video Url",
            Description = "Video Url",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual EPiServer.Url VideoUrl { get; set; }

        #endregion
    }
}