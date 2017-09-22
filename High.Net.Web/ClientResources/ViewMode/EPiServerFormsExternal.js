(function ($) {
    var originalGetCustomElementValue = epi.EPiServer.Forms.Extension.getCustomElementValue;

    $.extend(true, epi.EPiServer.Forms, {
        /// extend the Validator to validate Visitor's value in Clientside.
        /// Serverside's Fullname of the Validator instance is used as object key (Case-sensitve) to lookup the Clientside validate function.        
        Validators: {
            "High.Net.Web.Business.FormElements.Validation.RecaptchaValidator": function(fieldName, fieldValue, validatorMetaData) {
                // validate recaptcha element
                if (fieldValue) {
                    return { isValid: true };
                }

                return { isValid: false, message: validatorMetaData.model.message };
            }
        },
        Extension: {
            getCustomElementValue: function ($element) {

                // for datetime picker we always return result in format "2015-12-25 10:30 AM",
                // and depend on picker type (date/time/datetime) we will parse its value later.
                if ($element.hasClass("FormRecaptcha")) {
                    // for recaptcha element
                    var widgetId = $element.data("epiforms-recaptcha-widgetid");
                    if (widgetId != undefined && grecaptcha) {
                        return grecaptcha.getResponse(widgetId);
                    } else {
                        return null;
                    }
                }

                // if current element is not our job, let others process
                return originalGetCustomElementValue.apply(this, [$element]);
            }
        }
    });

    
})($$epiforms || $);