using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.Global, DisplayName = "Logo Wall", GUID = "a32119e7-6e23-46ad-b8f7-5d19c085ce49", Description = "", Order = 10720)]
    public class LogoWallBlock : HighNetBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(
            Name = "Wall Heading",
            Description = "Wall heading",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string WallHeading { get; set; }

        [Display(
            Name = "Logo Wall Item",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display logo wall items",
            Order = 200)]
        [AllowedTypes(typeof(LogoWallItemBlock))]
        public virtual ContentArea LogoWallItems { get; set; }

        #endregion

    }
}