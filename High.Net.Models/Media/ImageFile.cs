using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace High.Net.Models.Media
{
    [ContentType(GUID = "1C4D7F7C-F011-4885-9642-6C6D821C78D1")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <value>
        /// The copyright.
        /// </value>
        public virtual string Copyright { get; set; }
    }
}
