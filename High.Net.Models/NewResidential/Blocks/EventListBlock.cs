using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Events Block",
       GUID = "D21CAB5B-3D37-4997-BD3F-2590F49F6DB4",
       Description = "Block to display the events",
       Order = 5150)]
    public class EventListBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Event list title",
            GroupName = Global.Tabs.Content,
            Description = "Event list title",
            Order = 10)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Event items",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display event items",
            Order = 20)]
        [AllowedTypes(typeof(EventItemBlock))]
        public virtual ContentArea EventItems { get; set; }
    }
}

