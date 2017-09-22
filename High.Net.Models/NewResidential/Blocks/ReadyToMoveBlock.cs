using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Ready to move block",
       GUID = "CCB4292D-5BC4-4B38-A45D-BA1B9A270386",
       Description = "Block to call",
       Order = 5150)]
    public class ReadyToMoveBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Image background",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        public virtual MediaReference ImageBackground { get; set; }

        [Display(
            Name = "Header",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual string Header { get; set; }

        [Display(
            Name = "Text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1210)]
        [UIHint(UIHint.LongString)]
        public virtual string Text { get; set; }

        [Display(
            Name = "Url to apply",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1220)]
        public virtual EPiServer.Url ApplyNowUrl { get; set; }

        [Display(
            Name = "Apply button text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1230)]
        public virtual string ApplyNowText { get; set; }


        [Display(
            Name = "Url to make schedule",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1240)]
        public virtual EPiServer.Url ScheduleTourUrl { get; set; }

        [Display(
            Name = "Schedule button text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1250)]
        public virtual string ScheduleText { get; set; }

    }
}