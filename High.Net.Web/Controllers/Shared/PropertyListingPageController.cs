using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Shared.Pages;
using High.Net.Core;
using High.Net.Models.Shared.ViewModels;
using EPiServer.ServiceLocation;
using EPiServer.DataAbstraction;
using EPiServer.Find.Framework;
using EPiServer.Find.Cms;
using EPiServer.Find;
using High.Net.Web.Business;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Web.Controllers.Commercial
{
    [TemplateDescriptor(Name = SiteGroups.B2B)]
    public class PropertyListingPageController : BasePageController<PropertyListingPage>
    {
        [ValidateInput(false)]
        public ActionResult Index(PropertyListingPage currentPage, PropertySearchForm propertySearchForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            var model = new PropertyPageModel(currentPage)
            {
                propertySearchForm = propertySearchForm
            };

            model.propertySearchForm.SearchResult = dataLocator.SearchProperty(model);

            return View("~/Views/Commercial/Pages/PropertyListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Associates
{
    [TemplateDescriptor(Name = SiteGroups.HA)]
    public class PropertyListingPageController : BasePageController<PropertyListingPage>
    {
        [ValidateInput(false)]
        public ActionResult Index(PropertyListingPage currentPage, PropertySearchForm propertySearchForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            var model = new PropertyPageModel(currentPage)
            {
                propertySearchForm = propertySearchForm
            };

            model.propertySearchForm.RootPage = model.propertySearchForm.RootPage != null ? model.propertySearchForm.RootPage : PageReference.RootPage;
            model.propertySearchForm.SearchResult = dataLocator.SearchProperty(model);

            return View("~/Views/Associates/Pages/PropertyListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.RealEstateGroup
{
    [TemplateDescriptor(Name = SiteGroups.REG)]
    public class PropertyListingPageController : BasePageController<PropertyListingPage>
    {
        [ValidateInput(false)]
        public ActionResult Index(PropertyListingPage currentPage, PropertySearchForm propertySearchForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            var model = new PropertyPageModel(currentPage)
            {
                propertySearchForm = propertySearchForm
            };

            model.propertySearchForm.RootPage = model.propertySearchForm.RootPage != null ? model.propertySearchForm.RootPage : PageReference.RootPage;
            model.propertySearchForm.SearchResult = dataLocator.SearchProperty(model);

            return View("~/Views/RealEstateGroup/Pages/PropertyListingPage/Index.cshtml", model);
        }
    }
}

namespace High.Net.Web.Controllers.Rollover
{
    [TemplateDescriptor(Name = SiteGroups.RO)]
    public class PropertyListingPageController : BasePageController<PropertyListingPage>
    {
        [ValidateInput(false)]
        public ActionResult Index(PropertyListingPage currentPage, PropertySearchForm propertySearchForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            var model = new PropertyPageModel(currentPage)
            {
                propertySearchForm = propertySearchForm
            };

            model.propertySearchForm.RootPage = model.propertySearchForm.RootPage != null ? model.propertySearchForm.RootPage : PageReference.RootPage;
            model.propertySearchForm.SearchResult = dataLocator.SearchProperty(model);

            return View("~/Views/Rollover/Pages/PropertyListingPage/Index.cshtml", model);
        }
    }
}