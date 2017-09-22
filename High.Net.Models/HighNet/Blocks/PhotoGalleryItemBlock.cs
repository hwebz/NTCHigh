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
        DisplayName = "Photo Gallery Item", 
        GUID = "009d3473-0b11-4f94-9ce6-87dd417c41e6", 
        Description = "",
        Order = 10700)]
    public class PhotoGalleryItemBlock : HighNetBlockData
    {
         [Display(
         Name = "Image",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1100)]
         public virtual MediaReference Image { get; set; }

         [Display(
         Name = "Html Text",
         GroupName = Global.Tabs.Content,
         Description = "use to format text content",
         Order = 1300)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString HtmlText { get; set; }
    }
}