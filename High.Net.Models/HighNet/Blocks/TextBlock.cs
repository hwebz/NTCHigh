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
        DisplayName = "TextBlock",
        GUID = "894f94ec-12cc-4274-8e7a-3f12df6e3232",
        Description = "",
        Order=10510)]
    public class TextBlock : HighNetBlockData
    {        
        #region Content 

        [Display(
           Name = "Heading",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        [Display(
           Name = "Descripiton",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString Descripiton { get; set; }

        #endregion

    }
}