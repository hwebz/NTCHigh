using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.HighNet.Pages;
using High.Net.Web.Business.Helpers;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Controllers.HighNet
{
    public class CarouselBlockController : BlockController<CarouselBlock>
    {
        public override ActionResult Index(CarouselBlock currentBlock)
        {
            string viewPath;
            var viewTemplate = string.IsNullOrEmpty(currentBlock.ViewTemplate)? CarouselViewTemplate.HighNetCarousel:currentBlock.ViewTemplate;

            switch (viewTemplate)
            {
                case CarouselViewTemplate.HighNetCarousel:
                    viewPath = "~/Views/HighNet/Blocks/CarouselBlock.cshtml";
                    break;
                case CarouselViewTemplate.LeadershipCarousel:
                    viewPath = "~/Views/Leadership/Blocks/CarouselBlock.cshtml";
                    break;
                case CarouselViewTemplate.FamilyCarouselLeftImage:
                    viewPath = "~/Views/Family/Blocks/CarouselBlock.cshtml";
                    break;
                case CarouselViewTemplate.FamilyCarouselRightImage:
                    viewPath = "~/Views/Family/Blocks/CarouselBlock.cshtml";
                    break;
                default:
                    viewPath = "~/Views/HighNet/Blocks/CarouselBlock.cshtml";
                    break;
            }
            return PartialView(viewPath, currentBlock);
        }
    }
}
