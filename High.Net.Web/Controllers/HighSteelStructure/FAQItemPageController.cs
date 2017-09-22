﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class FAQItemPageController : HighSteelStructureController<FAQItemPage>
    {
        public ActionResult Index(FAQItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighSteelStructure/Pages/FAQItemPage/Index.cshtml", model);
        }
    }
}