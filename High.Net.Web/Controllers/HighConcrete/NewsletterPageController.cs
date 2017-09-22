using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.HighConcrete.ViewModels;
using System;
using High.Net.Web.Business;
using EPiServer.ServiceLocation;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class NewsletterPageController : PageController<NewsLetterPage>
    {
        public ActionResult Index(NewsLetterPage currentPage)
        {
            var model = new NewsletterModel(currentPage);
            return View("~/Views/HighConcrete/Pages/NewsletterPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NewsLetterPage currentPage, String Email)
        {
            var model = new NewsletterModel(currentPage) { };
            if (!string.IsNullOrEmpty(Email))
            {
                model.NewsLetterForm.Email = Email;
            }
            return View("~/Views/HighConcrete/Pages/NewsletterPage/Index.cshtml", model);
        }
    }
}