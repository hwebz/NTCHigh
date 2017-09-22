using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.Industries.Blocks
{
    [ContentType(GroupName=SiteGroups.HII,
        Order=4070,
        DisplayName = "Carousel Block", GUID = "7a112bfd-0f8a-4f2a-9795-4287e70e6529", Description = "")]
    public class CarouselBlock : IndustriesBlockData
    {
        #region Image

        [Display(Name = "Image (Width :  , Height : )",
             Description = "Image",
             GroupName = Global.Tabs.Images,
             Order = 100)]
        public virtual MediaReference Image { get; set; }

        #endregion

        #region Content
       
        [Display(
           Name = "Heading",
           Description = "Heading",
           GroupName = Global.Tabs.Content,
           Order = 200)]
        public virtual String Heading { get; set; }

        [Display(Name = "Heading Url",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 210)]
        public virtual EPiServer.Url HeadingUrl { get; set; }

        [Display(
            Name = "Sub Heading",
            Description = "Sub Heading",
            GroupName = Global.Tabs.Content,
            Order = 220)]
        [UIHint(UIHint.LongString)]
        public virtual String SubHeading { get; set; }

        [Display(Name = "Learn More Url",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 230)]
        public virtual EPiServer.Url LearnMoreUrl { get; set; }

        [Display(
            Name = "Contact",
            Description = "Contact",
            GroupName = Global.Tabs.Content,
            Order = 240)]
        public virtual string Contact { get; set; }

        #endregion
    }
}