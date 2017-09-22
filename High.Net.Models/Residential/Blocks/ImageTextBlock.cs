using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;


namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR,
    DisplayName = "Image Text Block",
    GUID = "7180afaf-ad8e-4e4b-b808-dbc15cfb8fe9",
    Description = "For image and text",
    Order = 5510)]
    public class ImageTextBlock : ResidentialBlockData
    {
        #region Image

        [Display(
            Name = "Image",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of Block",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "Description of Block",
            GroupName = Global.Tabs.Content,
            Order = 2200)]
        public virtual XhtmlString Description { get; set; }

        [Display(
            Name = "Page Link",
            Description = "Page Link",
            GroupName = Global.Tabs.Content,
            Order = 2300)]
        public virtual PageReference PageReferenceLink { get; set; }

        #endregion


    }
}