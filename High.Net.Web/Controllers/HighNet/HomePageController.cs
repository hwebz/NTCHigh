using System.Web.Mvc;
using High.Net.Models.HighNet.Pages;
using High.Net.Core;
using High.Net.Models.Business.SelectionFactory;

namespace High.Net.Web.Controllers.HighNet
{
    public class HomePageController : HighNetController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            string viewPath;

            switch (currentPage.SiteViewTemplate)
            {
                case SelectHighSiteTemplate.FamilyTemplate:
                    viewPath = "~/Views/Family/Pages/HomePage/Index.cshtml";
                    break;
                case SelectHighSiteTemplate.LeadershipTemplate:
                    viewPath = "~/Views/Leadership/Pages/HomePage/Index.cshtml";
                    break;
                default:
                    viewPath = "~/Views/HighNet/Pages/HomePage/Index.cshtml";
                    break;
            }
            return View(viewPath, model);
        }
    }
}