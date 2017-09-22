using System.Web.Mvc;
using EPiServer.ServiceLocation;
using High.Net.Web.Business.Services;

namespace High.Net.Web.Business.Attributes
{
    public class ValidateRecaptchaAttribute : ActionFilterAttribute
    {
        private const string RECAPTCHA_RESPONSE_KEY = "g-recaptcha-response";

        private ICaptchaValidationService _captchaService;
        public ICaptchaValidationService CaptchaService => _captchaService ??
                                                           (_captchaService = ServiceLocator.Current.GetInstance<ICaptchaValidationService>());

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (!CaptchaService.Validate(filterContext.HttpContext.Request[RECAPTCHA_RESPONSE_KEY]))
                filterContext.Controller.ViewData.ModelState.AddModelError("Recaptcha", "Please verify that you are not a robot.");
        }
    }
}