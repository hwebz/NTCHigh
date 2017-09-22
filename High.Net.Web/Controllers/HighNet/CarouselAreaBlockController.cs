using EPiServer.Web.Mvc;
using High.Net.Models.HighNet.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.HighNet
{
    public class CarouselAreaBlockController : BlockController<CarouselAreaBlock>
    {
        public override ActionResult Index(CarouselAreaBlock currentBlock)
        {
            return PartialView("~/Views/Family/Blocks/CarouselAreaBlock.cshtml", currentBlock);
        }
    }
}