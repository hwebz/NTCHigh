using High.Net.Core;
using High.Net.Models.NewResidential.Blocks;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.NewResidential
{
    public class FaqBlockController : BaseBlockController<FaqBlock>
    {
        public override ActionResult Index(FaqBlock currentBlock)
        {
            return PartialView("~/Views/NewResidential/Blocks/FaqBlock.cshtml", currentBlock);
        }
    }
}