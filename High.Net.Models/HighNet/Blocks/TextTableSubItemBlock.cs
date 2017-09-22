using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Text Table Sub-Item", 
        GUID = "5800b9f4-6e73-4fa2-b660-48836e856b34",
        Description = "",
        Order = 10820)]
    public class TextTableSubItemBlock : HighNetBlockData
    {
       [CultureSpecific]
       [Display(
          Name = "Main Heading",
          Description = "",
          GroupName = Global.Tabs.Content,
          Order = 1200)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
             Name = "Content Body",
             GroupName = Global.Tabs.Content,
             Description = "",
             Order = 1300)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString Body { get; set; }

        [CultureSpecific]
        [Display(
             Name = "Link",
             GroupName = Global.Tabs.Content,
             Description = "",
             Order = 1400)]
        public virtual EPiServer.Url Link { get; set; }

        [CultureSpecific]
        [Display(
         Name = "Link Text",
         Description = "",
         GroupName = Global.Tabs.Content,
         Order = 1500)]
        public virtual string LinkText { get; set; }

    }
}
