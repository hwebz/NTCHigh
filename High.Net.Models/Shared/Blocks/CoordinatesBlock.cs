using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Shared.Blocks
{
    [ContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Co-Ordinates Block",
        Order = 30,
        GUID = "6106bad1-493c-4f67-81e2-2de0cd1a0973",
        Description = "")]
    public class CoordinatesBlock : BaseBlockData
    {
        [Display(GroupName = SystemTabNames.Content, Name = "Lat")]
        public virtual double Latitude { get; set; }

        [Display(GroupName = SystemTabNames.Content, Name = "Lon")]
        public virtual double Longitude { get; set; }
    }
}