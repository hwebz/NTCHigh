using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using High.Net.Models.HighNet.Pages;
using High.Net.Core;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Web.Business.Helpers;

namespace High.Net.Web.Controllers.HighNet
{
    public class ContentPageController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            var startPage = SiteDefinition.Current.StartPage.GetContent<HomePage>();

            var model = PageViewModel.Create(currentPage);
            string viewPath;

            switch (startPage.SiteViewTemplate)
            {
                case SelectHighSiteTemplate.FamilyTemplate:
                    viewPath = "~/Views/Family/Pages/ContentPage/Index.cshtml";
                    break;
                case SelectHighSiteTemplate.LeadershipTemplate:
                    viewPath = "~/Views/Leadership/Pages/ContentPage/Index.cshtml";
                    break;
                default:
                    viewPath= "~/Views/HighNet/Pages/ContentPage/Index.cshtml";
                    break;
            }

            return View(viewPath, model);
        }
    }
}