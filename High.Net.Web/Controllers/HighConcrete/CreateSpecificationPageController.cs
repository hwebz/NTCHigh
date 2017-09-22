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
    public class CreateSpecificationPageController : PageController<CreateSpecificationPage>
    {
        public ActionResult Index(CreateSpecificationPage currentPage)
        {
            var model = new CreateSpecificationModel(currentPage)
            {

            };
            return View("~/Views/HighConcrete/Pages/CreateSpecificationPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateSpecificationPage currentPage, CreateSpecificationForm createSpecificationForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new CreateSpecificationModel(currentPage) { };
            if (ModelState.IsValid)
            {
                try
                {
                    string mailBody = String.Format(Convert.ToString(currentPage.MailBody),
                    createSpecificationForm.ProductType, createSpecificationForm.ProjectName,
                    createSpecificationForm.Address1, createSpecificationForm.Address2,
                    createSpecificationForm.City, createSpecificationForm.State,
                    createSpecificationForm.PostalCode, createSpecificationForm.ProjectSize,
                    createSpecificationForm.FirmName, createSpecificationForm.FirmContact,
                    createSpecificationForm.FirmEmail, createSpecificationForm.SpecificationFormat,
                    createSpecificationForm.SpecificationType);

                    dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailIds, null, "", true, null,createSpecificationForm.FirmEmail);
                    model.createSpecificationForm.IsFormSubmitted = true;
                    return View("~/Views/HighConcrete/Pages/CreateSpecificationPage/Index.cshtml", model);
                }
                catch (Exception)
                {
                }
            }
            createSpecificationForm.IsFormSubmitted = false;
            return View("~/Views/HighConcrete/Pages/CreateSpecificationPage/Index.cshtml", model);
        }
    }
}