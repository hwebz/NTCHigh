using EPiServer.DataAnnotations;

namespace High.Net.Core
{
    /// <summary>
    /// Attribute used for site content types to set default attribute values
    /// </summary>
    public class SiteContentType : ContentTypeAttribute
    {
        public SiteContentType()
        {
            GroupName = Global.Tabs.Global;
        }
    }
}
