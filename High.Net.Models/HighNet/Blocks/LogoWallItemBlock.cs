using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Logo Wall Item", GUID = "82026600-0d82-4e42-ac6f-49530432e202", Description = "", Order = 10730)]
    public class LogoWallItemBlock : HighNetBlockData
    {
        #region Content

        [Display(
           Name = "Logo Image",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 100)]
        public virtual MediaReference LogoImage { get; set; }

        [Display(
           Name = "Logo Url",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 200)]
        public virtual EPiServer.Url LogoUrl { get; set; }

        [Display(
            Name = "Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 210)]
        [UIHint(UIHint.LongString)]
        public virtual string Text { get; set; }

        #endregion
    }
}