using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Tiles Container Block", GUID = "99AFB583-1B52-4176-BE5F-9F6946DF4683", Description = "", Order = 10580)]
    public class TilesContainerBlock : HighNetBlockData
    {
        [Display(
            Name = "Author Quote Items",
            Description = "Author Quote Items",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        [AllowedTypes(typeof(TweeterFeedBlock), typeof(OtherTilesBlock), typeof(OtherTileBlockWide), typeof(NewsBlock))]
        public virtual ContentArea TileItems { get; set; }
    }
}

