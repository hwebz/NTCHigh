using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Standard Content/Image Block",
        GUID = "649fb4e9-e51f-494d-859c-bbfc95015ee9",
        Description = "",
        Order=10940)]
    public class StandardContentImageBlock : HighNetBlockData
    {

        [Display(
           Name = "Html Text",
           GroupName = Global.Tabs.Content,
           Description = "use to format text content",
           Order = 1100)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString HtmlText { get; set; }

        [Display(
            Name = "Heading",
            GroupName = Global.Tabs.Content,
            Description = "Heading",
            Order = 1200)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(
             Name = "Image",
             GroupName = Global.Tabs.Content,
             Description = "",
             Order = 1300)]
        public virtual MediaReference Image { get; set; }

        [Display(
             Name = "Apply Now Link",
             GroupName = Global.Tabs.Content,
             Description = "",
             Order = 1400)]
        public virtual EPiServer.Url ApplyNowLink { get; set; }

        [Display(
             Name = "Apply Now Link Text",
             GroupName = Global.Tabs.Content,
             Description = "",
             Order = 1500)]
        public virtual string ApplyNowLinkText { get; set; }

    }
}