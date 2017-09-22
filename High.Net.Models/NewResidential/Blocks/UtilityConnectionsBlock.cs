using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Core;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Utility Connections Block",
       GUID = "996A97E2-D39D-4075-AF5D-86522B766E55",
       Description = "",
       Order = 5150)]
    public class UtilityConnectionsBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = Global.Tabs.Content,
            Order = 10)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Utility connection Items",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 20)]
        [AllowedTypes(typeof(UtilityConnectionItemBlock))]
        public virtual ContentArea ConnectionItems { get; set; }
    }
}