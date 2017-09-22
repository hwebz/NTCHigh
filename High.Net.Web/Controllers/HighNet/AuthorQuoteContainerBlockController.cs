using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.HighNet.Pages;
using High.Net.Web.Business.Helpers;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Controllers.HighNet
{
    public class AuthorQuoteContainerBlockController : BlockController<AuthorQuoteContainerBlock>
    {
        public override ActionResult Index(AuthorQuoteContainerBlock currentBlock)
        {
            var viewTemplate = currentBlock.ViewTemplate ?? string.Empty;
            string viewPath = string.Empty;

            switch (viewTemplate)
            {
                case AuthorQuoteSliderViewTemplate.HighNetAuthorQuote:
                    viewPath = "~/Views/HighNet/Blocks/AuthorQuoteContainerBlock.cshtml";
                    break;
                case AuthorQuoteSliderViewTemplate.FamilyAuthorQuote:
                    viewPath = "~/Views/Family/Blocks/AuthorQuoteContainerBlock.cshtml";
                    break;
                default:
                    viewPath = "~/Views/HighNet/Blocks/AuthorQuoteContainerBlock.cshtml";
                    break;
            }
            return PartialView(viewPath, currentBlock);
        }
    }
}
