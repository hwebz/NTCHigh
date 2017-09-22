using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Models.Constants;
using Global = High.Net.Core.Global;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Feature Positions Item", GUID = "64ee0600-b1d1-473f-b5fd-e749b958d7eb", Description = "", Order = 10770)]
    public class FeaturePositionItemBlock : HighNetBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Job Location",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [UIHint(UIHint.LongString)]
        public virtual string JobLocation { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Body",
            Description = "Body",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [UIHint(UIHint.LongString)]
        public virtual string Body { get; set; }

        [Display(
           Name = "Apply Now Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 400)]
        public virtual Url ApplyNowLink { get; set; }

        [Display(
          Name = "Add Sharing Button",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 401)]
        public virtual bool EnableSharing { get; set; }

    }
}