using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Photo Gallery", 
        GUID = "337abbad-b24a-45dd-9e68-c78a334e8ac7",
        Description = "",
        Order = 10710)]
    public class PhotoGalleryBlock : HighNetBlockData
    {
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
        [ContentAreaItemsMaxAttribute(7)]
        //[ContentAreaItemsMinAttribute(3)]
        [AllowedTypes(typeof(PhotoGalleryItemBlock))]
        public virtual ContentArea PhotoGalleryContentArea { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ContentAreaItemsMaxAttribute : ValidationAttribute
    {
        private int _max;

        public ContentAreaItemsMaxAttribute(int max)
        {
            _max = max;
        }

        public override bool IsValid(object value)
        {
            if ((value != null) && !(value is ContentArea))
            {
                throw new ValidationException("ContentAreaItemsMaxAttribute is intended only for use with ContentArea properties");
            }

            var contentArea = value as ContentArea;

            if (contentArea.Count > _max)
            {
                ErrorMessage = string.Format("contentArea restricted to {0} content items", _max);
                return false;
            }
            return true;
        }

        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);
            if (result != null && !string.IsNullOrEmpty(result.ErrorMessage))
            {
                result.ErrorMessage = string.Format("{0} {1}", validationContext.DisplayName, ErrorMessage);
            }
            return result;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ContentAreaItemsMinAttribute : ValidationAttribute
    {
        private int _min;

        public ContentAreaItemsMinAttribute(int min)
        {
            _min = min;
        }

        public override bool IsValid(object value)
        {
            if ((value != null) && !(value is ContentArea))
            {
                throw new ValidationException("ContentAreaItemsMinAttribute is intended only for use with ContentArea properties");
            }

            var contentArea = value as ContentArea;

            if (contentArea.Count < _min)
            {
                ErrorMessage = string.Format("contentArea restricted to {0} content items", _min);
                return false;
            }
            return true;
        }

        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);
            if (result != null && !string.IsNullOrEmpty(result.ErrorMessage))
            {
                result.ErrorMessage = string.Format("{0} {1}", validationContext.DisplayName, ErrorMessage);
            }
            return result;
        }
    }
}