using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Apartment Carousel Block",
       GUID = "A64B437C-7653-4F6C-A323-70B404250F20",
       Description = "Block to display the Apartments as the carousel",
       Order = 5150)]
    public class ApartmentsCarouselBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Title",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 10)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Auto play slider",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 20)]
        public virtual bool AutoPlay { get; set; }

        [Display(
            Name = "Image Items",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 100)]
        [AllowedTypes(typeof(ApartmentItemBlock))]
        public virtual ContentArea ApartmentItems { get; set; }

    }
}

