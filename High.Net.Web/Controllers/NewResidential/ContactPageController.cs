using System.Linq;
using System.Web.Mvc;
using High.Net.Core;
using High.Net.Models.NewResidential.Pages;

namespace High.Net.Web.Controllers.NewResidential
{
    public class ContactPageController : BasePageController<ContactPage>
    {
        public ActionResult Index(ContactPage currentPage)
        {
            if (Request.RawUrl.Contains("scheduleatour"))
            {
                ViewData["Title"] = "Schedule a Tour";
            }
            else
            {
                ViewData["Title"] = currentPage.Title;
            }
            var model = PageViewModel.Create(currentPage);
            return View("~/Views/NewResidential/Pages/ContactPage/Index.cshtml", model);
        }
    }
}