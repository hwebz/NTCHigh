using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.Shared.ListPropertyModel
{
    public class IconLinkModel
    {
        public Url Link { get; set; }

        public string AltText { get; set; }

        [UIHint(UIHint.Image)]
        public ContentReference Icon { get; set; }
    }
}