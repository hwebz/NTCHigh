using High.Net.Core;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.Shared.Blocks;
using System.Web.Mvc;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Controllers.HighNet
{
    public class TestimonialSliderBlockController : BaseBlockController<TestimonialSliderBlock>
    {
        public override ActionResult Index(TestimonialSliderBlock currentBlock)            
        {

            var viewTemplate = currentBlock.ViewTemplate ?? TestimonialSliderViewTemplate.HighNetTestimonials;
            string viewName;
            switch (viewTemplate)

            {
                case TestimonialSliderViewTemplate.LeadershipTestimonials:                    
                    viewName = "~/Views/Leadership/Blocks/TestimonialSliderBlock.cshtml";
                    break;
                case TestimonialSliderViewTemplate.HighNetTestimonials:
                    viewName = "~/Views/HighNet/Blocks/TestimonialSliderBlock.cshtml";
                    break; 
                default:
                    viewName = "~/Views/HighNet/Blocks/TestimonialSliderBlock.cshtml";
                    break;
            }

            return PartialView(viewName, currentBlock);
        }
    }
}