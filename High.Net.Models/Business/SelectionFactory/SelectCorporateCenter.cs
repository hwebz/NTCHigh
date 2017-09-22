using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer;

namespace High.Net.Models.Business.SelectionFactory
{
    /// <summary>
    /// Provides a list of options corresponding to ContactPage pages on the site
    /// </summary>
    /// <seealso cref="ContactPageSelector"/>
    public static class SelectCorporateCenter
    {
        public static IEnumerable<ISelectItem> GetCorporateCenter()
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var corporateCenters = contentRepository.GetChildren<High.Net.Models.Commercial.Pages.HomePage>(EPiServer.Core.PageReference.RootPage);
            return new List<SelectItem>(corporateCenters.Select(c => new SelectItem { Value = c.ContentLink, Text = c.Name }));
        }
    }
}
