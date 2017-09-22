using System.Net;
using EPiServer.ServiceLocation;
using High.Net.Core.Helpers;
using Newtonsoft.Json.Linq;

namespace High.Net.Web.Business.Services
{
    [ServiceConfiguration(typeof(ICaptchaValidationService))]
    public class RecaptchaValidationService : ICaptchaValidationService
    {
        private const string API_URL = "https://www.google.com/recaptcha/api/siteverify";
        private readonly string _secretKey;

        public RecaptchaValidationService()
        {
            _secretKey = SettingsHelper.GetSetting("Google.ReCaptcha.SecretKey");
        }

        public bool Validate(string response)
        {
            if (!string.IsNullOrWhiteSpace(response))
            {
                using (var client = new WebClient())
                {
                    var result = client.DownloadString($"{API_URL}?secret={_secretKey}&response={response}");
                    return ParseValidationResult(result);
                }
            }

            return false;
        }

        private bool ParseValidationResult(string validationResult) => (bool)JObject.Parse(validationResult).SelectToken("success");
    }
}