using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(DisplayName = "VideoCarouselBlock", GUID = "e085471e-004c-45f8-afcf-0a3f137a7789", Description = "")]
    public class VideoCarouselBlock : BlockData
    {
        [AllowedTypes(typeof(VideoBlock))]
        public virtual ContentArea Videos { get; set; }
    }
}