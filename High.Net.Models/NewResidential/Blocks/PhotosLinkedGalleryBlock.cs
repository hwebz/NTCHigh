using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Photos Linked Gallery Block",
       GUID = "42248DBD-2D71-4EC2-8489-23B8F8D61460",
       Description = "Block the gallery of photos with link",
       Order = 5150)]
    public class PhotosLinkedGalleryBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Image Items",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display photo and link items",
            Order = 100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea PhotoLinkedItems { get; set; }
    }
}