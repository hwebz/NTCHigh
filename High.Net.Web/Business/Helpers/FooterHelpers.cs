using EPiServer;
using EPiServer.ServiceLocation;
using High.Net.Core;
using High.Net.Web.ViewModels.NewResidential;
using NewResidential = High.Net.Models.NewResidential.Pages;

namespace High.Net.Web.Business.Helpers
{
    public static class FooterHelpers
    {
        private static readonly IContentRepository contentRepository;

        static FooterHelpers()
        {
            contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
        }

        public static FooterViewModel GetResidentialFooterModel(BasePageData currentPage)
        {
            var homePage = currentPage.GetHomePage<NewResidential.HomePage>();
            if (homePage == null)
            {
                return new FooterViewModel();
            }

            var model = new FooterViewModel()
            {
                BottomBarText = homePage.BottomBarTitle,
                LeftIconLinksList = homePage.BottomBarLeft,
                RightIconLinksList = homePage.BottomBarRight,
                FooterInforList = homePage.Footer
            };
            return model;
        }
    }
}