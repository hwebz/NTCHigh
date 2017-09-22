using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using High.Net.Models.Business.SelectionFactory;
using High.Net.Models.HighNet.Pages;
using High.Net.Models.NewResidential.Blocks;
using High.Net.Web.Business.Helpers;

namespace High.Net.Web.Controllers.HighNet
{
   
    public class GoogleMapSingleLocationBlockController : BlockController<GoogleMapSingleLocationBlock>
    {
        public override ActionResult Index(GoogleMapSingleLocationBlock currentBlock)
        {
            string viewPath;
            var startPage = SiteDefinition.Current.StartPage.GetContent<HomePage>();

            switch (startPage.SiteViewTemplate)
            {
                case SelectHighSiteTemplate.FamilyTemplate:
                    viewPath = "~/Views/Family/Blocks/GoogleMapSingleLocationBlock.cshtml";
                    break;
                case SelectHighSiteTemplate.LeadershipTemplate:
                    viewPath = "~/Views/Leadership/Blocks/GoogleMapSingleLocationBlock.cshtml";
                    break;
                default:
                    viewPath = "~/Views/NewResidential/Blocks/GoogleMapSingleLocationBlock.cshtml";
                    break;
            }

            return PartialView(viewPath, currentBlock);
        }
    }
}
