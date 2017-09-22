using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Sub-header Text Block",
        GUID = "b5b919a5-bdde-40fd-8cba-d004d10c549b",
        Description = "")]
    public class StaticQuoteBlock : HighNetBlockData
    {
       
          [CultureSpecific]
          [Display(
              Name = "Name",
              Description = "Name field's description",
              GroupName = SystemTabNames.Content,
              Order = 1100)]
          public virtual string Text { get; set; }

          [Display(
              Name = "Background Color",
              Description = "Background Color",
              GroupName = SystemTabNames.Content,
              Order = 1200)]
          [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
          public virtual string BackGroundColor { get; set; }

          [Display(
              Name = "Font Color",
              Description = "Font Color",
              GroupName = SystemTabNames.Content,
              Order = 1300)]
          [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
          public virtual string FontColor { get; set; }
        
    }
}