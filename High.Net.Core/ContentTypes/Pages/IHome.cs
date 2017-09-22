using ImageVault.EPiServer;
using System;

namespace High.Net.Core
{
    public interface IHome
    {
        MediaReference SiteLogo { get; set; }
        //String ContactNo { get; set; }

        string NameInEmail { get; }

        string BusinessContactNumber { get; }

        string GoogleAnalytics { get; set; }
    }
}