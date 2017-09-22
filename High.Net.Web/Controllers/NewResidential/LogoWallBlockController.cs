using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighNet.Blocks;

namespace High.Net.Web.Controllers.NewResidential
{
    [TemplateDescriptor(
        Tags = new[]
        {
            Global.ContentAreaTags.ResidentialHomePage,
            Global.ContentAreaTags.ResidentialContentPage
        },
        AvailableWithoutTag = false)]
    public class LogoWallBlockController : BlockController<LogoWallBlock>
    {
        public override ActionResult Index(LogoWallBlock currentBlock)
        {
            return PartialView("~/Views/NewResidential/Blocks/LogoWallBlock.cshtml", currentBlock);
        }
    }
}
