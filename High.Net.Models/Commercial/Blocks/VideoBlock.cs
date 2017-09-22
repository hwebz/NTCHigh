using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.Commercial.Blocks
{
    [ContentType(GroupName = SiteGroups.B2B,
        DisplayName = "Video Block",
        GUID = "52107c19-042d-49eb-bc74-2c16407639ca",
        Description = "Block For Image With Video",
        Order = 3500)]

    public class VideoBlock : CommercialBlockData
    {
        #region Url

        [Display(
            Name = "Video Link",
            Description = "Link of video",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual EPiServer.Url VideoUrl { get; set; }

        #endregion
    }
}