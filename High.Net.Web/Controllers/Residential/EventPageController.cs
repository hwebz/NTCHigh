using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.Residential.Pages;
using High.Net.Core;
using EPiServer.ServiceLocation;
using System;

namespace High.Net.Web.Controllers.Residential
{
    public class EventPageController : ResidentialController<EventPage>
    {
        public ActionResult Index(EventPage currentPage)
        {
            IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();
            if (currentPage.endDate < currentPage.startDate)
            {
                var clone = (EventPage)currentPage.CreateWritableClone();
                clone.endDate = currentPage.startDate;
                _contentRepo.Save(clone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                var model = PageViewModel.Create(clone);
                return View("~/Views/Residential/Pages/EventPage/Index.cshtml", model);
            }
            else
            {
                var model = PageViewModel.Create(currentPage);
                return View("~/Views/Residential/Pages/EventPage/Index.cshtml", model);
            }
        }

    }
}