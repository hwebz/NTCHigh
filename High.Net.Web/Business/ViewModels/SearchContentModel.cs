using System.Collections.Generic;
using System.Web;
using High.Net.Models.Shared.Pages;
using High.Net.Core;
using EPiServer.Core;
using EPiServer.Find.UnifiedSearch;
using System.Web.Routing;

namespace High.Net.Web.Business.ViewModels
{
    public class SearchContentModel : PageViewModel<SearchPage>
    {
        public SearchContentModel(SearchPage currentPage) : base(currentPage)
        {
            this.PagerLinks = new List<CustomLink>();
        }

        public UnifiedSearchResults Results { get; set; }
        public string SearchQuery { get; set; }
        public int TotalHits { get; set; }
        public List<CustomLink> PagerLinks { get; set; }

        public class CustomLink
        {
            public bool IsActivePage { get; set; }
            public string LinkText { get; set; }
            public string Url { get; set; }
            public RouteValueDictionary Route { get; set; }
        }
    }
}
