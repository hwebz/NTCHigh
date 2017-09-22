using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Constants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Text Table Item", 
        GUID = "e08e4504-002d-4d6d-8c19-523e232f0248",
        Description = "",
        Order = 10810)]
    public class TextTableItemBlock : HighNetBlockData
    {
        [CultureSpecific]
        [Display(
           Name = "Main Heading",
           Description = "",
           GroupName = Global.Tabs.Content,
           Order = 1200)]
        public virtual string Heading { get; set; }

        [Display(
           Name = "BackGround Color",
           Description = "",
           GroupName = SystemTabNames.Content,
           Order = 1200)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
           Name = "Page Content",
           GroupName = Global.Tabs.Content,
           Description = "Content Area to display tasks",
           Order = 1100)]
        [AllowedTypes(typeof(TextTableSubItemBlock))]
        public virtual ContentArea TextTableSubContentArea { get; set; }

      

    }
}