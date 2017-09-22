using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Header Banner Item", GUID = "7BD483BC-6475-4DCD-AEEE-AC7CD0334821", Description = "", Order = 10650)]
    public class HeaderBannerItemBlock : HighNetBlockData
    {

        #region Images

        [Display(
           Name = "Banner Image",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1110)]
        public virtual string Heading { get; set; }

        #endregion

    }
}