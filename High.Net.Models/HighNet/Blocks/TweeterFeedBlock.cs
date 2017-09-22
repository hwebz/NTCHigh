using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "News Tiles: Social", GUID = "fa8f9244-5f47-4e43-bafb-49d99fdf9a2f", Description = "", Order = 10590)]
    public class TweeterFeedBlock : HighNetBlockData
    {

       
        [Display(
            Name = "Image",
            GroupName = SystemTabNames.Content,
            Order = 1010)]
        public virtual MediaReference Image { get; set; }

        [Display(
           Name = "Header Text",
           GroupName = SystemTabNames.Content,
           Order = 1020)]
        public virtual String HeaderText { get; set; }

    }


}