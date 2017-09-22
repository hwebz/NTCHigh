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
        DisplayName = "Google Map Block",
        GUID = "4F110CE9-BF90-44EB-A8FF-2ACAA5EF2CD8",
        Description = "",
        Order = 10950)]
    public class GoogleMapBlock : HighNetBlockData
    {
        #region Content

        [Display(
            Name = "Location Data",
            Description = "Location Data",
            GroupName = Global.Tabs.Content,
            Order = 1000)]
        public virtual MediaReference LocationData { get; set; }
        
        #endregion

    }
}