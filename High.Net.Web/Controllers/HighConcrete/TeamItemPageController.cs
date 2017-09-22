using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class TeamItemPageController : PageController<TeamItemPage>
    {
        public ActionResult Index(TeamItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighConcrete/Pages/TeamItemPage/Index.cshtml", model);
        }
    }
}