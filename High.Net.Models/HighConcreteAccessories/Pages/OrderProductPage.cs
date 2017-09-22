using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighConcreteAccessories.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "Order Product Page",
        GUID = "E87527A2-C0AE-431A-AB18-F1BB2E2CF653",
        Description = "",
        Order = 15020)]    
    public class OrderProductPage : HighConcreteAccessoriesPageData, IHighConcreteAccessories
    {

    }
}