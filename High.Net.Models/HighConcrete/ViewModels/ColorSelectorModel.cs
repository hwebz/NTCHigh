using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using EPiServer.Search;
using High.Net.Models.HighConcrete.Blocks;

namespace High.Net.Models.HighConcrete.ViewModels
{
    public class ColorSelectorModel : PageViewModel<ColorSelectorListingPage>
    {
        public ColorSelectorModel(ColorSelectorListingPage colorSelectorListingPage)
            : base(colorSelectorListingPage)
        {
            this.colorSelectorForm = new ColorSelectorForm();
            this.PagerLinks = new List<CustomLink>();
        }

        public ColorSelectorForm colorSelectorForm { get; set; }

        public List<ColorFinishesBlock> ColorSelectorItemPageList { get; set; }

        public object Results { get; set; }
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

    public class ColorSelectorForm
    {
        public string color { get; set; }

        public string texture { get; set; }

        public string pattern { get; set; }

    }

   

}
