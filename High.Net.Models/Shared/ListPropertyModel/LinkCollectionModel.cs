using EPiServer.SpecializedProperties;
using High.Net.Models.HighNet.Blocks;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.Shared.ListPropertyModel
{
    public class LinkCollectionModel
    {
        public LinkItemCollection Links { get; set; }

        [Display(Name = "End With Contact Item")]
        public bool EndWithContactItem { get; set; }
    }
}