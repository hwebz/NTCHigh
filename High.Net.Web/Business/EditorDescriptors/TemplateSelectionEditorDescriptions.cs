using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using High.Net.Models.Business.SelectionFactory.HighNet;
using High.Net.Models.Business.SelectionFactory.Shared;
using System;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = HighUIHint.TestimonialSliderTemplateSelection)]
    public class TestimonialSliderTemplateSelectionEditorDescription : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, System.Collections.Generic.IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(TestimonialSliderTemplateFactory);
            ClientEditingClass = "highnet/editors/galleryViewTemplate";
            metadata.EditorConfiguration.Add("uiHint", HighUIHint.TestimonialSliderTemplateSelection);
            base.ModifyMetadata(metadata, attributes);
        }
    }


    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = HighUIHint.PhotosGalleryTemplateSelection)]
    public class PhotosGalleryViewTemplateSelectionEditorDescription : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, System.Collections.Generic.IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(PhotosGalleryTemplateFactory);
            ClientEditingClass = "highnet/editors/galleryViewTemplate";
            metadata.EditorConfiguration.Add("uiHint", HighUIHint.PhotosGalleryTemplateSelection);
            base.ModifyMetadata(metadata, attributes);
        }
    }

    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = HighUIHint.NumbericBlockTemplatesSelection)]
    public class NumbericContentViewTemplateSelectionEditorDescription : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, System.Collections.Generic.IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(NumbericContentBlockTemplateFactory);
            ClientEditingClass = "highnet/editors/galleryViewTemplate";
            metadata.EditorConfiguration.Add("uiHint", HighUIHint.NumbericBlockTemplatesSelection);
            base.ModifyMetadata(metadata, attributes);
        }
    }

    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = HighUIHint.ImageTextBlockTemplatesSelection)]
    public class ImageTextViewTemplateSelectionEditorDescription : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, System.Collections.Generic.IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(ImageTextBlockTemplateFactory);
            ClientEditingClass = "highnet/editors/galleryViewTemplate";
            metadata.EditorConfiguration.Add("uiHint", HighUIHint.ImageTextBlockTemplatesSelection);
            base.ModifyMetadata(metadata, attributes);
        }
    }

    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = HighUIHint.AuthorQuoteTemplatesSelection)]
    public class AuthorQuoteTemplatesSelectionEditorDescription : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, System.Collections.Generic.IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(AuthorQuoteTemplateFactory);
            ClientEditingClass = "highnet/editors/galleryViewTemplate";
            metadata.EditorConfiguration.Add("uiHint", HighUIHint.AuthorQuoteTemplatesSelection);
            base.ModifyMetadata(metadata, attributes);
        }
    }

    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = HighUIHint.CarouselTemplatesSelection)]
    public class CarouselTemplatesSelectionEditorDescription : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, System.Collections.Generic.IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(CarouselTemplateFactory);
            ClientEditingClass = "highnet/editors/galleryViewTemplate";
            metadata.EditorConfiguration.Add("uiHint", HighUIHint.CarouselTemplatesSelection);
            base.ModifyMetadata(metadata, attributes);
        }
    }
}