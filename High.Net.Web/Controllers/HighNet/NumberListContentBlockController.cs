using High.Net.Core;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.NewResidential.Blocks;
using System.Web.Mvc;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Controllers.HighNet
{
    public class NumberListContentBlockController : BaseBlockController<NumberListContentBlock>
    {
        public override ActionResult Index(NumberListContentBlock currentBlock)            
        {

            var viewTemplate = currentBlock.ViewTemplate ?? NumbericContentViewTemplate.NumbericTextOnly;
            string viewName;
            switch (viewTemplate)

            {
                case NumbericContentViewTemplate.NumbericWithPhotosGallery:                    
                    viewName = "~/Views/Leadership/Blocks/NumberListContentBlock.cshtml";
                    break;
                case NumbericContentViewTemplate.NumbericTextOnly:
                    viewName = "~/Views/HighNet/Blocks/NumberListContentBlock.cshtml";
                    break; 
                default:
                    viewName = "~/Views/HighNet/Blocks/NumberListContentBlock.cshtml";
                    break;
            }

            return PartialView(viewName, currentBlock);
        }
    }
}