using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.ListPropertyModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using static High.Net.Models.Constants.EditorConstants;
using EPiServer.DataAbstraction;

namespace High.Net.Models.Shared.Blocks
{
    [ContentType(
       GroupName = SiteGroups.Global,
       DisplayName = "Testimonials Slider Block",
       Order = 30,
       GUID = "E9CF40F5-ACA9-488D-8175-B2DAE4C73EDB",
       Description = "")]    
    public class TestimonialSliderBlock : BaseBlockData, IHaveMultipleTemplates
    {

        [Display(
             Name = "Title",
             Description = "Title",
             GroupName = Global.Tabs.Content,
             Order = 10)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Introduction",
            Description = "Introduction",
            GroupName = Global.Tabs.Content,
            Order = 20)]
        [UIHint(UIHint.LongString)]
        public virtual string Introduction { get; set; }

        [Display(
          Name = "Testimonial Items",
          Description = "Testimonial Items",
          GroupName = Global.Tabs.Content,
          Order = 20)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationModel>))]
        public virtual IList<TextInformationModel> TestimonialItems { get; set; }


        [Display(
          Name = "Testimonial Items",
          Description = "Testimonial Items",
          GroupName = Global.Tabs.TemplateSettings,
          Order = 20)]
        [UIHint(HighUIHint.TestimonialSliderTemplateSelection)]
        public virtual string ViewTemplate { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.ViewTemplate = TestimonialSliderViewTemplate.HighNetTestimonials;
        }
    }

}