using System.Web;
using EPiServer.Web;

namespace High.Net.Core.Channels
{
    /// <summary>
    /// Defines the 'Web' content channel
    /// </summary>
    public class WebChannel : DisplayChannel
    {
        public override string ChannelName
        {
            get
            {
                return "web";
            }
        }

        public override bool IsActive(HttpContextBase context)
        {
            return !context.Request.Browser.IsMobileDevice;
        }
    }
}
