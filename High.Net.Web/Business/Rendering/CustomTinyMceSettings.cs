using EPiServer.Core.PropertySettings;
using EPiServer.Editor.TinyMCE;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using System.Linq;
using System;

namespace High.Net.Web.Business.Rendering
{
    [ServiceConfiguration(ServiceType = typeof(PropertySettings))]
    public class CustomTinyMceSettings : PropertySettings<TinyMCESettings>
    {
        private TinyMCESettings _tinyMceSettings;
        private readonly object _lock = new object();
        private IPropertySettingsRepository __propertySettingsRepo;

        private IPropertySettingsRepository _propertySettingsRepo =>
            __propertySettingsRepo ?? (__propertySettingsRepo = ServiceLocator.Current.GetInstance<IPropertySettingsRepository>());

        public CustomTinyMceSettings()
        {
            IsDefault = true;
            DisplayName = "Default settings from code";
            Description = "This is the default settings as defined in code(including settings from ImageVault).";
        }

        public override Guid ID { get; } = new Guid("a6fe936f-190d-45e2-b83c-ccc0501a7311");

        public override TinyMCESettings GetPropertySettings()
        {
            var contentCss = SiteDefinition.Current.Name.Equals("High Net") ? "high-editor.css" : "editor.css";
            var settings = GetExistingTinyMceSettings();
            settings.ContentCss = $"/Static/global/css/{contentCss}";

            return settings;
        }

        private TinyMCESettings GetExistingTinyMceSettings()
        {
            _tinyMceSettings = (_propertySettingsRepo
                                   .GetGlobals(typeof(TinyMCESettings))
                                   .FirstOrDefault(settingsWrapper => settingsWrapper.DisplayName.Contains("(ImageVault)"))
                                   ?.PropertySettings) as TinyMCESettings ?? new TinyMCESettings();

            return _tinyMceSettings.Copy() as TinyMCESettings;
        }
    }
}
