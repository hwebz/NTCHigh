using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential, 
        DisplayName = "ApartmentItemBlock", 
        GUID = "a1d0824b-6ed3-49c8-82c8-42325d58989e",
        Description = "")]
    public class ApartmentItemBlock : BaseBlockData
    {
        [Display(
            Name = "Name",
            Description = "Name",
            GroupName = Global.Tabs.Content,
            Order = 10)]
        public virtual string Name { get; set; }

        [Display(
            Name = "Description",
            Description = "Description",
            GroupName = Global.Tabs.Content,
            Order = 20)]
        [UIHint(UIHint.LongString)]
        public virtual string Description { get; set; }

        [Display(
            Name = "Image",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 30)]
        public virtual MediaReference Image { get; set; }

        [Display(
            Name = "Detail",
            Description = "Detail",
            GroupName = Global.Tabs.Content,
            Order = 40)]
        public virtual XhtmlString Detail { get; set; }

        [Display(
            Name = "Url to apply",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 50)]
        public virtual EPiServer.Url ApplyNowUrl { get; set; }

        [Display(
            Name = "Apply button text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 60)]
        public virtual string ApplyNowText { get; set; }


        [Display(
            Name = "Url to make schedule",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 70)]
        public virtual EPiServer.Url ScheduleTourUrl { get; set; }

        [Display(
            Name = "Schedule button text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 80)]
        public virtual string ScheduleText { get; set; }

    }
}