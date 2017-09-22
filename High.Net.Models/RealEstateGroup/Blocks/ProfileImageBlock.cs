using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(GroupName = SiteGroups.REG, 
        DisplayName = "Profile Block", 
        GUID = "db2f5d22-805d-4d0a-a92a-c59798710f93", 
        Description = "Profile contains profile image along with designation",
        Order = 8050)]
    public class ProfileImageBlock : RealEstateGroupBlockData
    {
        #region Images

        [Display(Name = "Profile Image (Width : 126 , Height : 154)",
           Description = "Profile Image",
           GroupName = Global.Tabs.Images,
           Order = 100)]
        public virtual MediaReference ProfileImage { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Name",
           Description = "Name of the person",
           GroupName = Global.Tabs.Content,
           Order = 200)]
        public virtual String Name { get; set; }

        [Display(
            Name = "Designation",
            Description = "Designation of the person",
            GroupName = Global.Tabs.Content,
            Order = 300)]
        public virtual String Designation { get; set; }

        #endregion
    }
}