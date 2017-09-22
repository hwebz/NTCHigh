using High.Net.Web.Business.Rendering;
using System.Linq;
using System.Web.Mvc;

namespace High.Net.Web.Business.Rendering
{
    /// <summary>
    /// Extends the Razor view engine to include the folders ~/Views/Shared/Blocks/ and ~/Views/Shared/PagePartials/
    /// when looking for partial views.
    /// </summary>
    public class SiteViewEngine : RazorViewEngine
    {
        private static readonly string[] AdditionalPartialViewFormats = new[] 
            { 
                TemplateCoordinator.SharedBlockFolder + "{0}.cshtml"
            };

        public SiteViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(AdditionalPartialViewFormats).ToArray();
        }
    }
}
