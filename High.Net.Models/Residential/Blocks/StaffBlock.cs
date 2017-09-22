using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR, 
        DisplayName = "Staff Block",
        GUID = "74c9cf2e-6387-488b-a8dc-396070f74ea9",
        Description = "Staff Details block",
        Order=5560)]
    public class StaffBlock : ResidentialBlockData
    {
        #region Image

        [Display(
            Name = "Profile photo (Width : 190 , Height : 190)",
            Description = "",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference ProfilePhoto { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual String Name { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Information",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 2200)]
        public virtual XhtmlString Information { get; set; }


        #endregion
    }
}