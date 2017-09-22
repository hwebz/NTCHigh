using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Associates.Pages;
using High.Net.Core;
using ImageVault.Common.Data;
using ImageVault.Client;

namespace High.Net.Web.Controllers.Associates
{
    public class HomePageController : AssociatesController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var client = ClientFactory.GetSdkClient();
            var category3 = client.Query<Category>().Where(c => c.Id == 3).FirstOrDefault();

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/Associates/Pages/HomePage/Index.cshtml",model);
        }
    }
}