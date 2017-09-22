using EPiServer.Web.Mvc;
using High.Net.Core;
using System.Web.Mvc;
using High.Net.Models.NewResidential.Pages;


namespace High.Net.Web.Controllers.NewResidential
{
    public class ContentPageController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/NewResidential/Pages/ContentPage/Index.cshtml", model);
        }
    }
}