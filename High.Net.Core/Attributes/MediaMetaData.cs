using ImageVault.Common.Data;
using ImageVault.Client.Descriptors;

namespace High.Net.Core.Attributes
{
    public class MediaMetaData : MediaItem
    {
        [Metadata(Name = "Caption")]
        public string Caption { get; set; }

        [Metadata(Name = "Descriptions")]
        public string Descriptions { get; set; }

        [Metadata(Name = "Tags")]
        public string Tags { get; set; }
    }
}
