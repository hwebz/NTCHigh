using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using High.Net.Core;
using High.Net.Models.NewResidential.Blocks;

namespace High.Net.Web.Controllers.NewResidential
{
    [TemplateDescriptor( //Required as controllers for blocks are registered as MvcPartialController by default
        Tags = new[] { Global.ContentAreaTags.ResidentialHomePage , Global.ContentAreaTags.ResidentialHomePage })]
    public class NoSpacePhotoGridGalleryController : BaseBlockController<PhotosGridGalleryBlock>
    {
        public override ActionResult Index(PhotosGridGalleryBlock currentBlock)
        {
            return PartialView("~/Views/NewResidential/Blocks/StandardPhotoGridGallery.cshtml", currentBlock);
        }
    }
}
