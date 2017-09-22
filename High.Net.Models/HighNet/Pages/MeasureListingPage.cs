using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighNet.Pages
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Measure Listing Page",
        GUID = "114d59a3-d31b-405d-b896-b2ea9708e660",
        Description = "",
        Order=10030)]    
    [AvailableContentTypes(Availability.Specific , Include = new [] { typeof(MeasureItemPage) } )]
    public class MeasureListingPage : HighNetPageData, IHighNet
    {
        
    }
}