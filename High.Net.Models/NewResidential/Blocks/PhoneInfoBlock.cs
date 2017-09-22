using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,DisplayName = "PhoneInfoBlock", GUID = "bb73cc83-52c2-41c0-88bd-627bd45d91d2", Description = "")]
    public class PhoneInfoBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Text",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 10)]
        public virtual string Text { get; set; }

        [Display(
            Name = "Phone number",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 20)]
        public virtual string PhoneNumber { get; set; }
    }
}