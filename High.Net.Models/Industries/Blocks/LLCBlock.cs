using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;
using ImageVault.EPiServer;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(GroupName = SiteGroups.HII,
         Order = 4010,
        DisplayName = "LLC Block",
        GUID = "0f3f4fdb-834e-488d-a900-8ea886cfbfb4",
        Description = "LLC block for home page")]
    [SiteImageUrl]
    public class LLCBlock : IndustriesBlockData
    {
        
        #region Image

        [Display(Name = "LLC Image (Width : 204 , Height : 205)",
            Description = "LLC Image",
            GroupName = Global.Tabs.Images,
            Order = 100)]
        [CultureSpecific]
        public virtual MediaReference LLCImage { get; set; }

        [Display(Name = "Page Url", 
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 110)]
        public virtual EPiServer.Url PageUrl { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the LLC block",
            GroupName = Global.Tabs.Content,
            Order = 200)]
        public virtual String Heading { get; set; }

        #endregion
    }
}