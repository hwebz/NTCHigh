using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using ImageVault.EPiServer;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(DisplayName = "UtilityConnectionItemBlock", GUID = "88e013f4-6c40-460a-a58b-80e86bc41266", Description = "")]
    public class UtilityConnectionItemBlock : BlockData
    {

        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Name { get; set; }

        [Display(
            Name = "Url",
            Description = "Url",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        public virtual EPiServer.Url Url { get; set; }

        [Display(
            Name = "Icon",
            Description = "Icon",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual MediaReference Icon { get; set; }

        [Display(
            Name = "Detail",
            Description = "Detail",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString Detail { get; set; }

    }
}