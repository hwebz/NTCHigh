using System.Collections.Generic;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.ListPropertyModel;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Faq Block",
       GUID = "54291D5C-9815-42E3-A401-2C2AD5CACFC9",
       Description = "Block to display Faq",
       Order = 5150)]
    public class FaqBlock : BaseBlockData, INewResidentialBlock
    {
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationModel>))]
        public virtual IList<TextInformationModel> FAQItems { get; set; }
    }
}

