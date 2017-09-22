(function () {
    $('.FormTextbox__Input.form-control').focus(function() {
        $(".Form__Element__ValidationError").attr("style", "display:none");
    });
})();