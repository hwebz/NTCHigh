using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.ListPropertyModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Group Text Information Block",
       GUID = "82E0F464-7B12-432F-ABD5-77CB3079EE60",
       Description = "Group Text Information Block",
       Order = 5150)]
    public class TextInformationGroupedBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
           Description = "Footer",
           GroupName = Global.Tabs.Content,
           Order = 80)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationModel>))]
        public virtual IList<TextInformationModel> Content { get; set; }
    }
}