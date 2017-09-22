using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.SteelServiceCentre.Blocks
{
    [ContentType(
        GroupName = SiteGroups.SSC,
        DisplayName = "Services Block",
        GUID = "94224e7c-0d11-49de-a0d7-101495237acf",
        Description = "Block to create value processing services",
        Order = 6520)]
    public class ServicesBlock : SteelServiceCentreBlockData
    {
        #region Image

        [Display(
           Name = "Service Image (Width : 325 , Height : 201)",
           GroupName = Global.Tabs.Images,
           Description = "Image for service",
           Order = 1100)]
        public virtual MediaReference ServiceImage { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Heading",
           GroupName = Global.Tabs.Content,
           Description = "Heading",
           Order = 2100)]
        public virtual string Heading { get; set; }

        [Display(
           Name = "Text",
           GroupName = Global.Tabs.Content,
           Description = "Text",
           Order = 2200)]
        public virtual XhtmlString Text { get; set; }

        [Display(
           Name = "Page Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2300)]
        public virtual EPiServer.Url LandingPage { get; set; }

        #endregion
    }
}