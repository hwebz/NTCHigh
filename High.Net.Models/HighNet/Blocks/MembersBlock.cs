using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Members Block",
        GUID = "c57e9cae-d859-48c7-8285-f705985fc4ae",
        Description = "",
        Order=10570)]
    public class MembersBlock : HighNetBlockData
    {
        #region Image

        [Display(
            Name = "Profile Image (Width : 100 , Height : 125)",
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
        [UIHint(UIHint.LongString)]
        public virtual String Text { get; set; }

        #endregion

    }
}