using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.DataAbstraction;
using High.Net.Models.Shared.Pages;

namespace High.Net.Web.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule), typeof(EPiServer.Data.DataInitialization))]
    public class AvailablePageTypesRootPage : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var locator = ServiceLocator.Current;

            var contentTypeRepository = locator.GetInstance<IContentTypeRepository>();
            var sysRoot = contentTypeRepository.Load("SysRoot") as PageType;
            var sysContentFolder = contentTypeRepository.Load("SysContentFolder") as ContentType; 


            var setting = new AvailableSetting { Availability = Availability.Specific };
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.Residential.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.NewResidential.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.Humanity.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.Industries.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.Commercial.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.Associates.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.SelfStorage.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.SteelServiceCentre.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.RealEstateGroup.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.StructureCareUs.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.HighNet.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.HighHotels.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.HighConcrete.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.HighTransit.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.HighConcreteAccessories.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.HighSteelStructure.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.Rollover.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(High.Net.Models.GreenfieldArchitects.Pages.HomePage)).Name);
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load(typeof(GenericPage)).Name);
            if (sysContentFolder != null)
            {
                setting.AllowedContentTypeNames.Add("SysContentFolder");
            }

            var availabilityRepository = locator.GetInstance<IAvailableSettingsRepository>();
            availabilityRepository.RegisterSetting(sysRoot, setting);
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}