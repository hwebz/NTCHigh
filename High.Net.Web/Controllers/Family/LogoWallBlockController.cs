using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Web.Controllers.Family
{
    [TemplateDescriptor(
        Tags = new[]
        {
            Global.ContentAreaTags.FamilyContentPage
        },
        AvailableWithoutTag = false)]
    public class LogoWallBlockController : BlockController<LogoWallBlock>
    {
        public override ActionResult Index(LogoWallBlock currentBlock)
        {
            return PartialView("~/Views/Family/Blocks/LogoWallBlock.cshtml", currentBlock);
        }
    }
}
