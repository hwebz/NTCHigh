using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HII,
        DisplayName = "Members Block", 
        GUID = "52b20b6c-7cf7-4007-a7db-82a1fa9c7407",
        Description = "",
        Order=4060)]
    public class MembersBlock : IndustriesBlockData
    {
        #region Image

        [Display(
            Name = "Profile Image (Width : 97 , Height : 121)",
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