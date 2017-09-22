using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Web;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Testimonials", GUID = "81074aa1-66f2-47f2-bcc6-d648ba270da4", Description = "", Order = 10610)]
    public class TestimonialBlock : HighNetBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1010)]
        public virtual string Name { get; set; }
        [CultureSpecific]
        [Display(
            Name = "Quote",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1020)]
        [UIHint(UIHint.LongString)]
        public virtual string Quote { get; set; }

    }
}