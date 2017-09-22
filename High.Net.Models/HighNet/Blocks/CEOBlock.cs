using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "CEO Block",
        GUID = "d7670a23-07fe-4ad2-b722-ffc20ead1fe7",
        Description = "",
        Order = 10550)]
    public class CEOBlock : HighNetBlockData
    {
        #region Image

        [Display(
            Name = "Image (Width : 132 , Height : 165)",
            Description = "Image",
            GroupName = Global.Tabs.Images,
            Order = 1100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Heading",
            Description = "Heading of Block",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        
        [Display(
            Name = "Text",
            Description = "Description of Block",
            GroupName = Global.Tabs.Content,
            Order = 2200)]
        [CultureSpecific]
        public virtual String Text { get; set; }

        #endregion
    }
}