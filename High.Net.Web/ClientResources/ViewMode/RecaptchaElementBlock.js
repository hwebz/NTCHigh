(function ($) {
    var _utilsSvc = epi.EPiServer.Forms.Utils;
    $(".EPiServerForms").on("formsReset formsNavigationPrevStep", function (event) {
        resetRecaptchaElements(event.target);
    });

    $(".EPiServerForms").on("formsStepValidating", function (event) {
        if (event.isValid == true) {
            return;
        }
        // reset reCAPTCHA element if validation failed
        resetRecaptchaElements(event.target);
    });


    // reset reCAPTCH elements in target form
    function resetRecaptchaElements(target) {

        var reCaptchaElements = $(".FormRecaptcha", target);
        $.each(reCaptchaElements, function (index, element) {
            var widgetId = $(element).data("epiforms-recaptcha-widgetid");
            if (widgetId != undefined && grecaptcha) {
                grecaptcha.reset(widgetId);
            }
        });
    };

})($$epiforms || $);