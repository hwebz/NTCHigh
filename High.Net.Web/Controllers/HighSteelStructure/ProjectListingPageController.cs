using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighSteelStructure.Pages;
using High.Net.Core;

namespace High.Net.Web.Controllers.HighSteelStructure
{
    public class ProjectListingPageController : HighSteelStructureController<ProjectListingPage>
    {
        public ActionResult Index(ProjectListingPage currentPage, string ProjectType)
        {
            //var contentLoader = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();
            //if (!string.IsNullOrEmpty(ProjectType))
            //{
            //    var projectItemPages = contentLoader.GetChildren<ProjectItemPage>(currentPage.ContentLink);
            //    ViewBag.projectItemPages = from item in projectItemPages
            //                               where item.BridgeProjectType != null
            //                               from projectType in item.BridgeProjectType.Split(',')
            //                               where projectType == ProjectType
            //                               select item;

            //    foreach (var item in currentPage.ddProjectType)
            //    {
            //        item.Selected = false;
            //    }
            //    currentPage.ddProjectType.Where(x => x.Value == ProjectType).FirstOrDefault().Selected = true;
            //}
            //else
            //{
            //    ViewBag.projectItemPages = contentLoader.GetChildren<ProjectItemPage>(currentPage.ContentLink);
            //    foreach (var item in currentPage.ddProjectType)
            //    {
            //        item.Selected = false;
            //    }
            //}

            var model = PageViewModel.Create(currentPage);
            return View("~/Views/HighSteelStructure/Pages/ProjectListingPage/Index.cshtml", model);
        }
    }
}