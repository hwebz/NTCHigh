using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcreteAccessories.Pages;
using High.Net.Models.HighConcreteAccessories.ViewModels;
using System;
using High.Net.Web.Business;
using EPiServer.ServiceLocation;
using System.Text;
using EPiServer.Web.Routing;

namespace High.Net.Web.Controllers.HighConcreteAccessories
{
    public class CreateSpecificationPageController : PageController<CreateSpecificationPage>
    {
        public ActionResult Index(CreateSpecificationPage currentPage)
        {
            var model = new CreateSpecificationPageModel(currentPage)
            {

            };
            return View("~/Views/HighConcreteAccessories/Pages/CreateSpecificationPage/Index.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateSpecificationPage currentPage, CreateSpecificationPageForm createSpecificationPageForm)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            var model = new CreateSpecificationPageModel(currentPage) { createSpecificationPageForm = createSpecificationPageForm };
            {

            };

            if (ModelState.IsValid)
            {
                StringBuilder productList = new StringBuilder();

                foreach (var item in createSpecificationPageForm.ListProducts.Where(x => x.Checked == true))
                {
                    productList.Append(item.Name);

                    if (item.Name != createSpecificationPageForm.ListProducts.Last().Name)
                        productList.Append(", ");
                }

                string mailBody = string.Format(Convert.ToString(currentPage.MailBody), productList, createSpecificationPageForm.ProductType,
                        createSpecificationPageForm.ProjectName, createSpecificationPageForm.StreetAddress1, createSpecificationPageForm.StreetAddress2,
                        createSpecificationPageForm.City, createSpecificationPageForm.State, createSpecificationPageForm.ZipCode,
                        createSpecificationPageForm.ProjectSize, createSpecificationPageForm.FirmName, createSpecificationPageForm.FirmContact,
                        createSpecificationPageForm.FirmEmail, createSpecificationPageForm.SpecificationType, createSpecificationPageForm.DocumentFormat,
                        createSpecificationPageForm.DocumentType);

                dataLocator.sendMail(currentPage.Subject, mailBody, currentPage.ToEmailID, null, "", true, null,createSpecificationPageForm.FirmEmail);
                createSpecificationPageForm.IsFormSubmitted = true;
                return View("~/Views/HighConcreteAccessories/Pages/CreateSpecificationPage/Index.cshtml", model);
            }
            createSpecificationPageForm.IsFormSubmitted = false;
            return View("~/Views/HighConcreteAccessories/Pages/CreateSpecificationPage/Index.cshtml", model);
        }
    }
}