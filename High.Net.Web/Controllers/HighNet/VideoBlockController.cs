using System.Web.Mvc;
using EPiServer.Web.Mvc;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Web.Controllers.HighNet
{
    public class VideoBlockController : BlockController<VideoBlock>
    {
        public override ActionResult Index(VideoBlock currentBlock)
        {
            return PartialView("~/Views/HighNet/Blocks/VideoBlock.cshtml", currentBlock);
        }
    }
}
