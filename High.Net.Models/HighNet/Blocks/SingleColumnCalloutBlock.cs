using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Constants;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Single-Column Call Out",
        GUID = "55668089-ee06-4f07-8861-95800518e727",
        Description = "",
        Order=10740)]
    public class SingleColumnCalloutBlock : HighNetBlockData
    {
        
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Name field's description",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual string Title { get; set; }

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

        [Display(
           Name = "BackGround Color",
           Description = "",
           GroupName = SystemTabNames.Content,
           Order = 1500)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BackGroundColor { get; set; }

        [Display(
            Name = "Bullet Color",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1502)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string BulletColor { get; set; }
      
        [CultureSpecific]
        [Display(
            Name = "Url Text",
            Description = "Name field's description",
            GroupName = Global.Tabs.Content,
            Order = 1600)]
        public virtual string UrlText { get; set; }

        [Display(
       Name = "Font Color",
       Description = "",
       GroupName = SystemTabNames.Content,
       Order = 1700)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string FontColor{ get; set; }
    }
}