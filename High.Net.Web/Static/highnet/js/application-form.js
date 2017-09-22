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
        if (!event || !event.workingFormInfo || !event.workingFormInfo.ValidationInfo) return;
        var validateInfo = event.workingFormInfo.ValidationInfo;
        for (var i = 0; i < validateInfo.length; i++) {
            var fieldData = validateInfo[i];
            if (fieldData.validators) {
                for (var j = 0; j < fieldData.validators.length; j++) {
                    if (fieldData.validators[j].type === "EPiServer.Forms.Implementation.Validation.EmailValidator") {
                        $('[name="' + fieldData.targetElementName + '"]').addClass('IsEmail');
                        break;
                    }
                }
            }
        }
    });

    $$epiforms(".EPiServerForms").on("formsStartSubmitting", function (event) {
        formData = $('form').serializeArray();
    });

    $$epiforms(".EPiServerForms").on("formsSubmitted", function (event) {
        //push to GTM formsSetupCompleted
        window.dataLayer = window.dataLayer || [];
        dataLayer.push(
            { 'event': 'careersForm' }
        );

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
        if ($(window).width() < 1024) {
            //$('.mfp-wrap').scrollTop(0);
            //if (navigator.userAgent.match(/(iPod|iPhone|iPad|Android)/)) {
            //    $('.mfp-wrap').scrollTo(0, 0); // first value for left offset, second value for top offset
            //}else{
            //    $('.mfp-wrap').scrollTop(0);
            //}
            $('.mfp-wrap').animate( { scrollTop: 0 });
        }
        
        $(".success-message").focus().slideDown().delay(5000).slideUp(1000, function () {
            resetForm();
            $('button.mfp-close').trigger('click');
        });
    });
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

$(function () {
    $('#applicationMenu').magnificPopup({
        type: 'inline',
        preloader: false,
        callbacks: {
            open: function () {
                if ($("#recaptchar_tag").length === 0) {
                    var script = document.createElement('script');
                    script.id = "recaptchar_tag";
                    script.type = 'text/javascript';
                    script.async = true;
                    script.src =
                        "https://www.google.com/recaptcha/api.js?onload=initRecaptchaElements&render=explicit&hl={0}";
                    document.body.appendChild(script);
                }
                // Will fire when this exact popup is opened
                // this - is Magnific Popup object
                // Initialize scaling
                scaleCaptcha();
                $('body').addClass('overflow-hidden');
                
                // Up to top when submit button clicked & validation failed
                $('.mfp-wrap .FormSubmitButton').on('click', function() {
                    if ($('.Form__Element__ValidationError').css('display') != 'none' || $('.FormRecaptcha').hasClass('ValidationFail')) {
                        $('.mfp-wrap').animate({ scrollTop: $('.mfp-wrap').offset().top}, 500);
                    }
                });
            },
            close: function () {
                // Will fire when popup is closed
                $('body').removeClass('overflow-hidden');
            }
        }
    });

    // Update scaling on window resize
    $(window).resize(throttle(scaleCaptcha,100));

    // Prevent input focusing prevent scrolling popup on mobile screens
    function inputFocusingPreventing(selector) {
        $('body').on('touchstart', function (e) {
            selector.css("pointer-events", "auto");
        });
        $('body').on('touchmove', function (e) {
            selector.css("pointer-events", "none");
        });
        $('body').on('touchend', function (e) {
            setTimeout(function () {
                selector.css("pointer-events", "none");
            }, 0);
        });
    }
    //inputFocusingPreventing($(".application-form__popup input, .application-form__popup textarea"));
});