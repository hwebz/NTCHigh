using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Associates.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.Associates
{
    public class ServiceListPageController : AssociatesController<ServiceListPage>
    {
        public ActionResult Index(ServiceListPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/ServiceListPage/Index.cshtml", model);
        }
    }
}