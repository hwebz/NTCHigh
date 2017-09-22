using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using High.Net.Core.Helpers;
using High.Net.Web.Business.FormElements;

namespace High.Net.Web.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class SettingRecaptchaKeysInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ServiceLocator.Current.GetInstance<IContentEvents>().CreatingContent += SetRecaptchaKeys;
        }

        private void SetRecaptchaKeys(object sender, ContentEventArgs e)
        {
            var recaptchaBlock = e.Content as RecaptchaElementBlock;
            if (recaptchaBlock != null)
            {
                recaptchaBlock.SiteKey = SettingsHelper.GetSetting("Google.ReCaptcha.PublicKey");
                recaptchaBlock.SecretKey = SettingsHelper.GetSetting("Google.ReCaptcha.SecretKey");
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}