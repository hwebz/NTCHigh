using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;

namespace High.Net.Models.Media
{
    [ContentType(GUID = "DF769CE8-E5DA-4151-972B-EEFC733253E8")]
    public class GenericMedia : MediaData
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual String Description { get; set; }
    }
}
