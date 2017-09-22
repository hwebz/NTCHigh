using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Framework.Web;
using EPiServer.Search;
using EPiServer.Web;
using EPiServer.Web.Hosting;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using High.Net.Web.Business.ViewModels;
using EPiServer.Framework.DataAnnotations;
using High.Net.Models.Constants;
using HAPP = High.Net.Models.HighAppraisal.Pages;
namespace High.Net.Web.Controllers.HighAppraisal
{
    [TemplateDescriptor(Name = SiteGroups.HAPP)]
    public class SearchPageController : BasePageController<SearchPage>
    {
        private const int MaxResults = 40;
        
        [ValidateInput(false)]
        public ViewResult Index(SearchPage currentPage, string q, int page = 1)
        {
            var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var _contentLoader = ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();

            var homePage = _contentLoader.GetAncestors(currentPage.ContentLink).Where(x => x.GetType().BaseType == typeof(HAPP.HomePage)).FirstOrDefault() as HAPP.HomePage;

            var model = new SearchContentModel(currentPage)
                {
                    SearchQuery = q
                };

            if (!string.IsNullOrWhiteSpace(q))
            {
                var hits = _dataLocator.Search(q.Trim(),
                    homePage.ContentLink,
                    this,
                    MaxResults,
                    page,
                    model);
            }

            return View("~/Views/HighAppraisal/Pages/SearchPage/Index.cshtml", model);
        }
    }
}
