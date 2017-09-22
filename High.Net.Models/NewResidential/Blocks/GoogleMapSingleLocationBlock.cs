using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Google map Single Location Block",
       GUID = "86619083-24B9-4AE1-9B3F-0269A0CE6CF7",
       Description = "Block to display Single Location map",
       Order = 5150)]
    public class GoogleMapSingleLocationBlock : BaseBlockData, INewResidentialBlock
    {
        //[ClientEditor(ClientEditingClass = "googlemapseditor/Editor")]
        //public virtual CoordinatesBlock Coordinates { get; set; }

        [ClientEditor(ClientEditingClass = "googlemapseditor/Editor")]
        [Display(
            Name = "Coordinate",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 10)]
        public virtual string LatLng { get; set; }

        [ClientEditor(ClientEditingClass = "googlemapseditor/Editor")]
        [Display(
            Name = "Complex coordinates",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 15)]
        public virtual string ComplexCoordinates { get; set; }


        [Display(
            Name = "Address",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 20)]
        [UIHint(UIHint.LongString)]
        public virtual string Address { get; set; }

        [Display(
            Name = "Description",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 30)]
        public virtual XhtmlString Description { get; set; }


        [Display(
            Name = "Contact us button",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 40)]
        public virtual string ContactUsButton { get; set; }

        [Display(
            Name = "Call us button",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 50)]
        public virtual string CallUsButton { get; set; }
    }
}