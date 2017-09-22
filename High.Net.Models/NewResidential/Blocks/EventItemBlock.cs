using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential, 
        DisplayName = "EventItemBlock", 
        GUID = "add11dae-d624-42fd-931a-2c682dd89684", Description = "")]
    public class EventItemBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
            Name = "Name",
            Description = "Event's name",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Name { get; set; }

        [Display(
            Name = "Image",
            Description = "Image",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual MediaReference Image { get; set; }

        [Display(
            Name = "Start date",
            Description = "Start date",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual DateTime StartDate { get; set; }

        [Display(
            Name = "End date",
            Description = "End date",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual DateTime EndDate { get; set; }

        [Display(
            Name = "Description",
            Description = "Description",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual XhtmlString Description { get; set; }

    }
}