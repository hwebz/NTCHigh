function throttle(fn, threshhold, scope) {
    threshhold || (threshhold = 250);
    var last,
        deferTimer;
    return function () {
        var context = scope || this;

        var now = +new Date,
            args = arguments;
        if (last && now < last + threshhold) {
            // hold on to it
            clearTimeout(deferTimer);
            deferTimer = setTimeout(function () {
                last = now;
                fn.apply(context, args);
            }, threshhold);
        } else {
            last = now;
            fn.apply(context, args);
        }
    };
}

$(function() {
    $(window).scroll(throttle(function() {
            console.log('dlkm');
            if ($("#recaptchar_tag").length === 0) {
                var script = document.createElement('script');
                script.id = "recaptchar_tag";
                script.type = 'text/javascript';
                script.async = true;
                script.src =
                    "https://www.google.com/recaptcha/api.js?onload=initRecaptchaElements&render=explicit&hl={0}";
                document.body.appendChild(script);
            }
        },
        200));
});

if (typeof $$epiforms !== 'undefined') {
    var formData;
    $$epiforms(".EPiServerForms").on("formsStartSubmitting", function (event) {
        formData = $('form').serializeArray();
        $('.FormRecaptcha').removeClass('form-captcha-validate-failed');
    });


    $$epiforms(".EPiServerForms").on("formsSubmitted", function (event) {        
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
        //disableForm();
        $('.leadership-form-message').addClass('success').text($('.success-message').text());
    });


    $$epiforms(".EPiServerForms").on("formsSubmittedError", function (event) {
        $('.FormSubmitButton').text('Please Try Again.');
        $('.leadership-form-message').text('There was an problem submitting your message.');
    });
}

(function () {
    $('.FormTextbox__Input').focus(function () {
        $(".Form__Element__ValidationError").attr("style", "display:none");
            //resetMessage();
    });

})();

