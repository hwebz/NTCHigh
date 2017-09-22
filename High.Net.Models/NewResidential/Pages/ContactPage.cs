using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Blocks;
using High.Net.Models.Shared.ListPropertyModel;

namespace High.Net.Models.NewResidential.Pages
{
    [ContentType(GroupName = SiteGroups.NewResidential,
        DisplayName = "Contact Page", 
        GUID = "8b29a19d-813a-4049-ad0e-f4ca5a172f51", 
        Description = "Contact page type")]
    public class ContactPage : ResidentialBasePageData
    {
        [Display(
            Description = "Contact form",
            GroupName = Global.Tabs.Content,
            Order = 30)]
        [AllowedTypes(typeof(FormContainerBlock))]
        public virtual ContentArea ContactForm { get; set; }

        [ClientEditor(ClientEditingClass = "googlemapseditor/Editor")]
        public virtual CoordinatesBlock Coordinates { get; set; }

        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationModel>))]
        public virtual IList<TextInformationModel> OfficeInfomation { get; set; }


        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.HeroLogoWidth = 300;
        }
    }
}