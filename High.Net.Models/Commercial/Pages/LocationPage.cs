using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.Commercial.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.B2B,
        DisplayName = "Corporate Center Map",
        GUID = "30fd1978-a56c-449f-adf0-4b5f4738dadd",
        Description = "Location Page",
        Order = 3040)]
    [AvailableContentTypes(
       Availability.None)]    
    public class LocationPage : CommercialPageData, ICommercial
    {
        #region Content
        
        [Display(
            Name = "Polygon Co-ordinates",
            Description = "Polygon Co-ordinates",
            GroupName = Global.Tabs.Content,
            Order = 1110)]
        [UIHint(UIHint.LongString)]
        public virtual string PolygonCoordinates { get; set; }

        #endregion
    }
}