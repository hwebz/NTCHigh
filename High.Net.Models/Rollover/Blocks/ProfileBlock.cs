using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(GroupName = SiteGroups.RO, Order = 11070,DisplayName = "Profile Block", GUID = "3de53981-74b5-48c1-b38c-0741698f0b79", Description = "")]
    public class ProfileBlock : RolloverBlockData
    {
        #region Images

        [Display(Name = "Person Image",
            Description = "Person Image",
            GroupName = Global.Tabs.Images,
            Order = 1000)]
        [CultureSpecific]
        public virtual MediaReference PersonImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Name",
            Description = "Name",
            GroupName = Global.Tabs.Content,
            Order = 2000)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string Name { get; set; }

        [Display(Name = "Contact",
            Description = "Contact",
            GroupName = Global.Tabs.Content,
            Order = 2010)]
        [CultureSpecific]
        public virtual string Contact { get; set; }

        [Display(Name = "Email",
      Description = "Email",
      GroupName = Global.Tabs.Content,
      Order = 2020)]
        [CultureSpecific]
        public virtual string Email { get; set; }
        #endregion
    }
}