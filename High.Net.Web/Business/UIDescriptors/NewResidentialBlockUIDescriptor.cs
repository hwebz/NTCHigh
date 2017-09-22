using EPiServer.Shell;
using High.Net.Models.NewResidential.Blocks;

namespace High.Net.Web.Business.UIDescriptors
{
    /// <summary>
    /// Describes how the UI should appear for <see cref="INewResidentialBlock"/> content.
    /// </summary>
    [UIDescriptorRegistration]
    public class NewResidentialBlockUIDescriptor : UIDescriptor<INewResidentialBlock>
    {
        public NewResidentialBlockUIDescriptor()
            : base(ContentTypeCssClassNames.SharedBlock)
        {
            DefaultView = CmsViewNames.AllPropertiesView;
        }
    }
}