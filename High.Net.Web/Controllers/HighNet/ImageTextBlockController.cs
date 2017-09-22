using High.Net.Core;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.NewResidential.Blocks;
using System.Web.Mvc;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Controllers.HighNet
{
    public class ImageTextBlockController : BaseBlockController<ImageTextBlock>
    {
        public override ActionResult Index(ImageTextBlock currentBlock)            
        {

            var viewTemplate = currentBlock.ViewTemplate ?? ImageTextViewTemplate.ImageInLeft;
                ;
            string viewName;
            switch (viewTemplate)

            {
                case ImageTextViewTemplate.ImageInLeft:                    
                    viewName = "~/Views/HighNet/Blocks/ImageTextBlock.cshtml";
                    break;
                case ImageTextViewTemplate.ImageBelow:
                    viewName = "~/Views/Leadership/Blocks/ImageTextBlock.cshtml";
                    break;
                case ImageTextViewTemplate.FullImage:
                    viewName = "~/Views/Family/Blocks/ImageTextBlock.cshtml";
                    break;
                default:
                    viewName = "~/Views/HighNet/Blocks/ImageTextBlock.cshtml";
                    break;
            }

            return PartialView(viewName, currentBlock);
        }
    }
}