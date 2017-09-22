using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighNet.Blocks;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.NewResidential.Blocks
{
    [ContentType(GroupName = SiteGroups.NewResidential,
       DisplayName = "Photos Grid Gallery Block",
       GUID = "98202375-E47E-488F-8E73-D0D12C7EE300",
       Description = "Block to display photo Gallery as grid",
       Order = 5150)]
    public class PhotosGridGalleryBlock : BaseBlockData, INewResidentialBlock
    {
        [Display(
           Name = "Photo Items",
           GroupName = Global.Tabs.Content,
           Description = "Content Area to display photo and link items",
           Order = 100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea PhotoItems { get; set; }

        [Display(
            Name = "Title",
            GroupName = Global.Tabs.Content,
            Description = "Title",
            Order = 110)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Number of columns",
            GroupName = Global.Tabs.BlockSettings,
            Description = "Number of columns",
            Order = 120)]
        [SelectOne(SelectionFactoryType = typeof(RowNumbersSelectionFactory))]
        public virtual int NumberOfColums { get; set; }

        [Display(
            Name = "Enable view full size",
            GroupName = Global.Tabs.BlockSettings,
            Description = "Enable view full size",
            Order = 130)]
        public virtual bool EnableViewFullSize { get; set; }

        [Display(
          Name = "Button Text",
          GroupName = Global.Tabs.BlockSettings,
          Description = "Text for the Button",
          Order = 140)]
        public virtual string ButtonText { get; set; }

        [Display(
           Name = "View Template",
           GroupName = Global.Tabs.TemplateSettings,
           Description = "View Template",
           Order = 180)]
        [UIHint(HighUIHint.PhotosGalleryTemplateSelection)]
        public virtual string ViewTemplate { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            NumberOfColums = 3;
            ViewTemplate = PhotoGalleryViewTemplates.GridNoButton;
        }
    }

    public class RowNumbersSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
                {new SelectItem() {Text = "3", Value = 3}, new SelectItem() {Text = "4", Value = 4}};
        }
    }
}