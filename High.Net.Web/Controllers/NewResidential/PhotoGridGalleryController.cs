using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using High.Net.Core;
using High.Net.Models.NewResidential.Blocks;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Controllers.NewResidential
{
    public class PhotoGridGalleryController : BaseBlockController<PhotosGridGalleryBlock>
    {
        public override ActionResult Index(PhotosGridGalleryBlock currentBlock)
        {
            string viewLocation;
            var selectedViewTemplate = currentBlock.ViewTemplate ?? PhotoGalleryViewTemplates.GridNoButton;
            if (selectedViewTemplate.Equals(PhotoGalleryViewTemplates.GridWithButton))
            {
                viewLocation = "~/Views/NewResidential/Blocks/PhotosGridGalleryBlock/GridWithButton.cshtml";
            }
            else if (selectedViewTemplate.Equals(PhotoGalleryViewTemplates.GridNoSpaceNoButton))
            {
                viewLocation = "~/Views/NewResidential/Blocks/PhotosGridGalleryBlock/GridNoSpaceNoButton.cshtml";
            }
            else if(selectedViewTemplate.Equals(PhotoGalleryViewTemplates.GridWithButton))
            {
                viewLocation = "~/Views/NewResidential/Blocks/PhotosGridGalleryBlock/GridNoButton.cshtml";
            }
            else 
            {
                viewLocation= "~/Views/Leadership/Blocks/PhotosGridGalleryBlock/GridSliderNoButton.cshtml";
            }
            return PartialView(viewLocation, currentBlock);
        }
    }
}
