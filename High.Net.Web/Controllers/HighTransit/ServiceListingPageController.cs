using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighTransit.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighTransit
{
    public class ServiceListingPageController : HighTransitController<ServiceListingPage>
    {
        public ActionResult Index(ServiceListingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighTransit/Pages/ServiceListingPage/Index.cshtml", model);
        }
    }
}