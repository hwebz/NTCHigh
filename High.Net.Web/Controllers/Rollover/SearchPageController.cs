using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Pages;
using High.Net.Web.Business;
using High.Net.Web.Business.ViewModels;
using System.Linq;
using System.Web.Mvc;
using RO = High.Net.Models.Rollover.Pages;
namespace High.Net.Web.Controllers.Rollover
{
    [TemplateDescriptor(Name = SiteGroups.RO)]
    public class SearchPageController : BasePageController<SearchPage>
    {
        private const int MaxResults = 40;

        [ValidateInput(false)]
        public ViewResult Index(SearchPage currentPage, string q, int page = 1)
        {
            var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var _contentLoader = ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();

            var homePage = _contentLoader.GetAncestors(currentPage.ContentLink).Where(x => x.GetType().BaseType == typeof(RO.HomePage)).FirstOrDefault() as RO.HomePage;

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

            return View("~/Views/Rollover/Pages/SearchPage/Index.cshtml", model);
        }
    }
}
