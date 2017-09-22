function initRecaptchaElements() {
    (function ($) {

        //This is the callback function executed after Google authenticates recaptcha values.
        function onVerify($element) {
            return function () {
                return function (response) {
                    if (!response || response.length == 0) {
                        return;
                    };

                    $element.find(".Form__Element__ValidationError").hide();
                }
            }($element);
        };

        $(".Form__Element.FormRecaptcha").each(function (index, element) {
            var $element = $(element),
                $widgetContainer = $(".g-recaptcha", $element),
                siteKey = $element.data("epiforms-sitekey");

            if ($widgetContainer.length == 1 && siteKey) {
                var widgetId = grecaptcha.render($widgetContainer[0], { sitekey: siteKey, callback: onVerify($element) });
                $element.data("epiforms-recaptcha-widgetid", widgetId);
            }
        });

    })($$epiforms || $);
}