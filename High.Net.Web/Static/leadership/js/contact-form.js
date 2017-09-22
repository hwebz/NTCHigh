//Javascript for application form
function initRecaptchaElements() {
    if (typeof $$epiforms !== 'undefined') {
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

                if ($widgetContainer.length == 1 && siteKey && typeof grecaptcha !== 'undefined') {
                    var widgetId = grecaptcha.render($widgetContainer[0], { sitekey: siteKey, callback: onVerify($element) });
                    $element.data("epiforms-recaptcha-widgetid", widgetId);
                }
            });

        })($$epiforms);
    }

    if (typeof jQuery !== 'undefined') {
        (function ($) {
            if (grecaptcha) {
                if ($('#contact-recaptcha').length > 0) {
                    grecaptcha.render('contact-recaptcha', {
                        'sitekey': $('#google-recaptcha-sitekey').val()
                    });
                }
            }
        })(jQuery);
    }
}

if (typeof $$epiforms !== 'undefined') {
    var formData;

    $$epiforms(".EPiServerForms").on("formsSetupCompleted", function (event) {
        //if (!event || !event.workingFormInfo || !event.workingFormInfo.ValidationInfo) return;
        //var validateInfo = event.workingFormInfo.ValidationInfo;
        //for (var i = 0; i < validateInfo.length; i++) {
        //    var fieldData = validateInfo[i];
        //    if (fieldData.validators) {
        //        for (var j = 0; j < fieldData.validators.length; j++) {
        //            if (fieldData.validators[j].type === "EPiServer.Forms.Implementation.Validation.EmailValidator") {
        //                $('[name="' + fieldData.targetElementName + '"]').addClass('IsEmail');
        //                break;
        //            }
        //        }
        //    }
        //}
    });

    $$epiforms(".EPiServerForms").on("formsStartSubmitting", function (event) {
        $('.FormSubmitButton').css('background-color', '#878d96').text('Submitting...');
        formData = $('form').serializeArray();
        $('.FormRecaptcha').removeClass('form-captcha-validate-failed');
    });

    $$epiforms(".EPiServerForms").on("formsSubmittedError", function (event) {
        $('.FormSubmitButton').text('Please Try Again.');
        $('.leadership-form-message').text('There was an problem submitting your message.');
    });


    $$epiforms(".EPiServerForms").on("formsStepValidating", function (event) {
        $('.ValidationFail').each(function(index) {
            if (!$(this).is("form")) {
                if ($(this).hasClass('FormRecaptcha')) {
                    $(this).addClass('form-captcha-validate-failed');
                } else {
                    $(this).find('.Form__Element__Caption').addClass('caption-validate-failed');
                }
                $('.leadership-form-message').text($(this).find('.Form__Element__ValidationError').text());
                return false;
            }
        });
        //if (!event.isValid) {
        //     $(".Form__Element__ValidationError").each(function(index) {
        //        if ($(this).text() !== '') {
        //            $('.leadership-form-message').text($(this).text());
        //            return false;
        //        } 
        //     });
            
        //}
    });


    $$epiforms(".EPiServerForms").on("formsReset", function (event) {
    });


    $$epiforms(".EPiServerForms").on("formsSubmitted", function (event) {
        $('.FormSubmitButton').css('background-color', '#11dd5c').text('Thank You!');
        $('.leadership-form-message').addClass('success').text($('.success-message').text());

        if (formData) {
            for (var i = 0; i < formData.length; i++) {
                var fieldData = formData[i];
                if (fieldData.name.indexOf('__field_') > -1) {
                    $('[name="' + fieldData.name + '"]').val(fieldData.value);
                }
            }
        }
        $('.Form__MainBody').addClass('importantRule');
        $('.Form__Status').hide();
        disableForm();
    });
}

(function () {
    $('.FormTextbox__Input').focus(function () {
        $(".Form__Element__ValidationError").attr("style", "display:none");
        resetMessage();
    });

})();


function resetMessage() {
    $('.FormSubmitButton').css('background-color', '#ed1c24').text('Submit');
    $('.Form__Element__Caption').removeClass('caption-validate-failed');
    $('.leadership-form-message').text('');
}

function disableForm() {
    if (formData) {
        for (var i = 0; i < formData.length; i++) {
            var fieldData = formData[i];
            if (fieldData.name.indexOf('__field_') > -1) {
                $('[name="' + fieldData.name + '"]').prop("disabled", true);
            }
        }
    }
    $('.send-applicatin-btn button[name="submit"]').css("pointer-events", "none");
}


function enableForm() {
    if (formData) {
        for (var i = 0; i < formData.length; i++) {
            var fieldData = formData[i];
            if (fieldData.name.indexOf('__field_') > -1) {
                $('[name="' + fieldData.name + '"]').removeAttr("disabled");
            }
        }
    }
    $('.send-applicatin-btn button[name="submit"]').css("pointer-events", "auto");
}

function resetForm() {
    if (formData) {
        for (var i = 0; i < formData.length; i++) {
            var fieldData = formData[i];
            if (fieldData.name.indexOf('__field_') > -1) {
                $('[name="' + fieldData.name + '"]').val('');
            }
        }
    }
    enableForm();
    formData = null;
    if (grecaptcha) grecaptcha.reset();
}

function scaleCaptcha(elementWidth) {
    // Width of the reCAPTCHA element, in pixels
    var reCaptchaWidth = 304;
    // Get the containing element's width
    var containerWidth = $('#application-form').width();

    // Only scale the reCAPTCHA if it won't fit
    // inside the container
    if (reCaptchaWidth > containerWidth) {
        // Calculate the scale
        var captchaScale = containerWidth / reCaptchaWidth;
        // Apply the transformation
        $('.g-recaptcha').css({
            'transform': 'scale(' + captchaScale + ')'
        });
    } else {
        $('.g-recaptcha').css({
            'transform': 'scale(1)'
        });
    }
}

