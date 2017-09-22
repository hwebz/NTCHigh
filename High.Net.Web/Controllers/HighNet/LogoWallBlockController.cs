using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using High.Net.Core;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Web.Controllers.HighNet
{
    [TemplateDescriptor(
        Tags = new[] { Global.ContentAreaTags.FullWidth,
            Global.ContentAreaTags.ThreeFourthWidth,
            Global.ContentAreaTags.TwoThirdsWidth,
            Global.ContentAreaTags.HalfWidth,
            Global.ContentAreaTags.OneThirdWidth,
            Global.ContentAreaTags.OneFourthWidth,
            Global.ContentAreaTags.OneFifthWidth,
            Global.ContentAreaTags.OneTwelfthWidth},
        AvailableWithoutTag = false)]
    public class LogoWallBlockController : BaseBlockController<LogoWallBlock>
    {
        public override ActionResult Index(LogoWallBlock currentBlock)
        {
            return PartialView("~/Views/HighNet/Blocks/LogoWallBlock.cshtml",currentBlock);
        }
    }
}
