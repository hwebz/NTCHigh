using High.Net.Core;
using High.Net.Models.NewResidential.Pages;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.NewResidential
{
    public class HomePageController : BasePageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/NewResidential/Pages/HomePage/Index.cshtml", model);
        }
    }
}