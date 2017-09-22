using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using High.Net.Web.Business;
using High.Net.Web.Business.ViewModels;
using EPiServer.Web;
using High.Net.Models.Constants;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighHotels
{
    [TemplateDescriptor(Name = SiteGroups.HH)]
    public class SearchPageController : BasePageController<SearchPage>
    {
        private const int MaxResults = 40;

        [ValidateInput(false)]
        public ViewResult Index(SearchPage currentPage, string q, int page = 1)
        {
            var _dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            var model = new SearchContentModel(currentPage)
            {
                SearchQuery = q
            };

            if (!string.IsNullOrWhiteSpace(q))
            {
                var hits = _dataLocator.Search(q.Trim(),
                    SiteDefinition.Current.StartPage,
                    this,
                    MaxResults,
                    page,
                    model);
            }

            return View("~/Views/HighHotels/Pages/SearchPage/Index.cshtml", model);
        }
    }
}