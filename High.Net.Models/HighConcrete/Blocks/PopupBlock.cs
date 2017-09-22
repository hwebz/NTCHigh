using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Models.HighConcrete.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Popup Block",
        GUID = "CAED5F53-24F4-468D-8587-39BAC8941171",
        Description = "Popup Block",
        Order = 13080)]
    public class PopupBlock : HighConcreteBlockData
    {
        #region Content

        [Display(
            Name = "Popup Heading",
            GroupName = Global.Tabs.Content,
            Description = "Popup Heading",
            Order = 1100)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Id",
            GroupName = Global.Tabs.Content,
            Description = "Id",
            Order = 1200)]
        public virtual String ID { get; set; }

        [Display(
            Name = "Popup Content",
            GroupName = Global.Tabs.Content,
            Description = "Popup Content",
            Order = 1300)]
        public virtual XhtmlString PopupContent { get; set; }

        [Display(
            Name = "Rating",
            GroupName = Global.Tabs.Content,
            Description = "Rating",
            Order = 1400)]
        public virtual int Rating { get; set; }

        #endregion
    }
}