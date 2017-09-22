using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.Media
{
    [ContentType(GUID = "8387E604-13A6-4301-BFF6-0F6CC98E7AF4")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoFile : VideoData
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public virtual string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
    }
}
