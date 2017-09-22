using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.HighConcreteAccessories.Blocks
{
    [ContentType(GroupName = SiteGroups.HCA, DisplayName = "Specifications Block", GUID = "2e56772f-8a5c-4ada-86e1-53ddad50d93a", Description = "", Order = 15030)]
    public class SpecificationsBlock : HighAccessoriesBlockData
    {
        #region Images

        [Display(
            Name = "About Content Image (Width : 66 , Height : 66)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1400)]
        public virtual MediaReference ContentImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 2100)]
        public virtual string ContentTitle { get; set; }

        [Display(Name = "Content",
             GroupName = Global.Tabs.Content,
             Description = "Content",
             Order = 2120)]
        public virtual XhtmlString Content { get; set; }

        #endregion
    }
}