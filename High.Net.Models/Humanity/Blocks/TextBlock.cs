using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Humanity.Pages;
using High.Net.Models.Shared.Pages;

namespace High.Net.Models.Humanity.Blocks
{
    [ContentType(
        GroupName = SiteGroups.EOH,
        DisplayName = "Text Block",
        Order = 1010,
        GUID = "bc2007dd-f695-4797-b147-5a204c1de123",
        Description = "Text Block Area")]
    [SiteImageUrl]
    public class TextBlock : HumanityBlockData
    {
        #region Content

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title of the block",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text of the block",
            GroupName = Global.Tabs.Content,
            Order = 200)]
        public virtual XhtmlString Text { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Read more page",
            Description = "Link to read more page",
            GroupName = Global.Tabs.Content,
            Order = 300)]
        [AllowedTypes(typeof(HumanityPageData),typeof(NewsItemPage))]
        public virtual PageReference ReadMore { get; set; }
      
        #endregion

    }
}