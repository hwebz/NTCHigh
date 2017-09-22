using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.HighConcrete.ViewModels;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class FindRepresentativePageController : PageController<FindRepresentativePage>
    {
        public ActionResult Index(FindRepresentativePage currentPage)
        {
            var model = new FindRepresentativeModel(currentPage)
            {
               
            };
            return View("~/Views/HighConcrete/Pages/FindRepresentativePage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FindRepresentativePage currentPage, FindRepresentitiveForm FindRepresentitiveForm)
        {
            var model = new FindRepresentativeModel(currentPage)
            {

            };
            return View("~/Views/HighConcrete/Pages/FindRepresentativePage/Index.cshtml", model);
        }
    }
}