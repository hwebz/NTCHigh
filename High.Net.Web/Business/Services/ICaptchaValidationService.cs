
namespace High.Net.Web.Business.Services
{
    public interface ICaptchaValidationService
    {
        bool Validate(string response);
    }
}