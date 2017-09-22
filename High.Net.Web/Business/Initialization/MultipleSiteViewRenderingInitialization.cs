using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using System.Collections.Generic;
using EPiServer.Core;
using High.Net.Models.Shared.Pages;
using HAPP = High.Net.Models.HighAppraisal.Pages;
using Rollover = High.Net.Models.Rollover.Pages;
namespace High.Net.Web.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class MultipleSiteViewRenderingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            //Add initialization logic, this method is called once after CMS has been initialized
            context.Locate.TemplateResolver()
            .TemplateResolved += OnTemplateResolved;
        }

        protected virtual void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            var contentLoader = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();

            if (args.SupportedTemplates == null || args.ItemToRender == null || args.ItemToRender is High.Net.Core.IContainerPage)
            {
                args.SelectedTemplate = null;
                return;
            }

            if (SiteDefinition.Current == null || string.IsNullOrEmpty(SiteDefinition.Current.Name))
            {
                return;
            }

            var siteGroups = ServiceLocator.Current.GetInstance<DataLocator>().GetSiteName();
            KeyValuePair<String, List<ContentReference>> siteGroup = new KeyValuePair<String, List<ContentReference>>();
            foreach (KeyValuePair<String, List<ContentReference>> site in siteGroups)
            {
                foreach (var item in site.Value)
                {
                    if (item == SiteDefinition.Current.StartPage)
                    {
                        siteGroup = site;
                    }
                }
            }

            var renderer =
                args.SupportedTemplates.SingleOrDefault(
                    r =>
                    r.Name != null &&
                    r.Name.Equals(siteGroup.Key, StringComparison.OrdinalIgnoreCase) &&
                    r.TemplateTypeCategory == args.SelectedTemplate.TemplateTypeCategory);

            if (args.RenderType == typeof(NewsListingPage) || args.RenderType == typeof(NewsItemPage) || args.RenderType == typeof(PropertyListingPage) || args.RenderType == typeof(PropertyPage) || args.RenderType == typeof(PropertyTypePage) || args.RenderType == typeof(SearchPage) || args.RenderType == typeof(ContactUsPage))
            {
                var IsApprisal = contentLoader.GetAncestors(new ContentReference((((EPiServer.Core.PageData)(args.ItemToRender)).ContentLink).ID)).Where(x => contentLoader.Get<IContent>(x.ContentLink) is HAPP.HomePage).Count();
                if (IsApprisal > 0)
                {
                    renderer = args.SupportedTemplates.Where(x => x.Name == High.Net.Models.Constants.SiteGroups.HAPP).FirstOrDefault();
                }

                var IsRollover = contentLoader.GetAncestors(new ContentReference((((EPiServer.Core.PageData)(args.ItemToRender)).ContentLink).ID)).Where(x => contentLoader.Get<IContent>(x.ContentLink) is Rollover.HomePage).Count();
                if (IsRollover > 0)
                {
                    renderer = args.SupportedTemplates.Where(x => x.Name == High.Net.Models.Constants.SiteGroups.RO).FirstOrDefault();
                }
            }

            if (renderer == null)
                return;

            args.SelectedTemplate = renderer;
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
            ServiceLocator.Current.GetInstance<TemplateResolver>()
            .TemplateResolved -= OnTemplateResolved;
        }
    }
}