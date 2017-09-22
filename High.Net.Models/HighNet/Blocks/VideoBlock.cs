      using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Video Block",
        GUID = "990227f8-f4ab-4235-a165-71b4ff870d16",
        Description = "",
        Order=10530)]
    public class VideoBlock : HighNetBlockData
    {
        

        #region Content

        [Display(
           Name = "Video Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        public virtual EPiServer.Url VideoLink { get; set; }
         

        #endregion
    }
}