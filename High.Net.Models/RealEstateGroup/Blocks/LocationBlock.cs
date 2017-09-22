using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(
        GroupName = SiteGroups.REG, 
        DisplayName = "Location Block", 
        Order = 8070, 
        GUID = "61407785-8C04-44D0-98F8-AEDC64316FDB",
        Description = "Location Block")]
    public class LocationBlock : RealEstateGroupBlockData
    {
        #region Content

        [Display(
           Name = "Location Data",
           Description = "Location Data",
           GroupName = Global.Tabs.Content,
           Order = 1110)]
        public virtual MediaReference LocationData { get; set; }

        #endregion
    }
}