using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Rollover.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.RO,
        DisplayName = "Service Item Page",
        Order = 11020,
        GUID = "ebfcc52f-21da-4ade-be59-9271ea682929",
        Description = "Service Item Page")]    
    [AvailableContentTypes(Availability.None)]
    public class ServiceItemPage : RolloverPageData
    {
        #region Image

        [Display(Name = "Service Image (Width : 360 , Height : 224)",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1000)]
        [CultureSpecific]
        public virtual MediaReference ServiceImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the block",
            GroupName = Global.Tabs.Content,
            Order = 2000)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Introduction Text",
            Description = "Introduction Text",
            GroupName = Global.Tabs.Content,
            Order = 2010)]
        public virtual XhtmlString IntroText { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Service Description",
            Description = "Service Description",
            GroupName = Global.Tabs.Content,
            Order = 2020)]
        public virtual XhtmlString ServiceDescription { get; set; }

        #endregion
    }
}