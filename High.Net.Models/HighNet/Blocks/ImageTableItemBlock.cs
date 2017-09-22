using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Image Table Item", GUID = "ABB37CED-81F8-4C87-B953-F0D2231A7C2E", Description = "", Order = 10910)]
    public class ImageTableItemBlock : HighNetBlockData
    {
        #region Content

        [Display(
           Name = "Logo Image",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 100)]
        public virtual MediaReference LogoImage { get; set; }

        [Display(
           Name = "Logo Url",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 200)]
        public virtual EPiServer.Url LogoUrl { get; set; }

        #endregion
    }
}