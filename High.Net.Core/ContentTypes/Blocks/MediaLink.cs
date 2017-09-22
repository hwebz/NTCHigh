using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using EPiServer;
using ImageVault.EPiServer;
using ImageVault.Client.Descriptors.Effects;

namespace High.Net.Core.ContentTypes.Blocks
{
    /// <summary>
    /// Used to provide a composite property on the start page to set site logotype settings
    /// </summary>
    [SiteContentType(
        DisplayName = "Media Link",
        GroupName= Global.Tabs.Global,
          Order = 20,
        GUID = "8F05226B-F00D-48FD-A03E-094C39CDAE1D", 
        AvailableInEditMode = true)] // Should be/not be created and added to content areas by editors, the MediaReferencetypeBlock is only used as a property type
    [SiteImageUrl]
    public class MediaLink : BaseBlockData
    {
        [DefaultDragAndDropTarget]
        [Display(
         Name = "Image",
         Description = "Image")]
        [ResizeEffect(Width = 50)]
        public virtual MediaReference Media { get; set; }
        
        [Display(Description = "Page Url")]
        public virtual Url PageUrl { get; set; }
    }
}
