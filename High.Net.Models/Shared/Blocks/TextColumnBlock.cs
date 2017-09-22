using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.Constants;
using High.Net.Models.Shared.ListPropertyModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.Shared.Blocks
{
    [ContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Text-Column Block",
        Order = 30,
        GUID = "C807F3A3-A642-47BE-93FB-31BA46A5886B",
        Description = "")]
    public class TextColumnBlock : BaseBlockData
    {

        [Display(
         Name = "Header",
        Description = "Header",
        GroupName = Global.Tabs.Content,
        Order = 80)]
        [UIHint(UIHint.LongString)]
        public virtual string Header { get; set; }


        [Display(
         Name = "Header Position",
        Description = "Header Position",
        GroupName = Global.Tabs.Content,
        Order = 85)]  
        [SelectOne(SelectionFactoryType = typeof(SelectColumnPosition))]
        public virtual int HeaderPosition { get; set; }


        [Display(
          Name = "Column Text Content",
        Description = "Column Text Content",
        GroupName = Global.Tabs.Content,
        Order = 90)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextModel>))]
        public virtual IList<TextModel> ColumnContent { get; set; }

        
    }
}