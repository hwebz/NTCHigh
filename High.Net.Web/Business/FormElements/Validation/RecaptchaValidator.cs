using System;
using System.Net;
using EPiServer.Forms.Core.Models;
using EPiServer.Forms.Core.Validation;
using EPiServer.Forms.Helpers.Internal;
using EPiServer.Forms.Implementation.Validation;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;

namespace High.Net.Web.Business.FormElements.Validation
{
    /// <summary>
    /// Validator for validate Recaptcha element.
    /// </summary>
    public class RecaptchaValidator : InternalElementValidatorBase
    {
        private const string RecaptchaVerifyBaseUrl = "https://www.google.com/recaptcha/api/siteverify";
        private Injected<LocalizationService> _localizationService;
        protected LocalizationService LocalizationService { get { return _localizationService.Service; } }
        /// <inheritdoc />
        public override bool? Validate(IElementValidatable targetElement)
        {
            // NOTE: when run in none-js mode, the recaptcha element value will be null and validation failed.
            var submittedValue = targetElement.GetSubmittedValue() as string;
            if (string.IsNullOrEmpty(submittedValue))
            {
                return false;
            }

            var recaptchaElment = targetElement as RecaptchaElementBlock;
            if (recaptchaElment == null)
            {
                return false;
            }

            var client = new WebClient();
            var verifyUrl = RecaptchaVerifyBaseUrl
                            .AddQueryString("secret", recaptchaElment.SecretKey)
                            .AddQueryString("response", submittedValue);
            var responseString = client.DownloadString(verifyUrl);
            var result = responseString.ToObject<RecaptchaResponse>();

            return result.success;
        }

        /// <inheritdoc />
        public override IValidationModel BuildValidationModel(IElementValidatable targetElement)
        {
            var model = base.BuildValidationModel(targetElement);
            if (model != null)
            {
                model.Message = this.LocalizationService.GetString("/episerver/forms/validators/episerver.forms.implementation.validation.recaptchavalidator/message");
            }

            return model;
        }

    }

    /// <summary>
    /// Object to hold Google reCAPTCHA verify result.
    /// </summary>
    public class RecaptchaResponse
    {
        public bool success { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
    }
}