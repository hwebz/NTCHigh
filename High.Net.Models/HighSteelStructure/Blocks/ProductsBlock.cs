using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.HighSteelStructure.Blocks
{
    [ContentType(
         GroupName = SiteGroups.HSS,
        DisplayName = "Products Block",
        GUID = "266f2d8b-c9d9-4aad-ad72-5808ce0c39e1",
        Description = "",
        Order=18040)]
    public class ProductsBlock : HighSteelStructureBlockData
    {
        #region Image

        [Display(
            Name = "Image (Width : 311 , Height : 253)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "Heading",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 2100)]
        public virtual String Heading { get; set; }

        [Display(
            Name = "Intro Text",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2200)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
            Name = "Link page",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 2300)]
        public virtual PageReference LinkPage { get; set; }

        #endregion
    }
}