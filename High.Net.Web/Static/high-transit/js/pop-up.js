$(document).ready(function () {
    $(".image-popup").click(function () {
        var modalPopupHtml = "<div class='large-image-bg'></div>"
                + "<div class='large-image-wrapper'><img src='' />"
                + "<a href='javascript:;' class='large-image-close' title='Close'>Close</a></div>",
            largeImage = $(this).attr("data-large-image"),
            largeImageWidthOffset = parseInt($(this).attr("data-width")) / 2,
            largeImageHeightOffset = parseInt($(this).attr("data-height")) / 2;

        $("body").prepend(modalPopupHtml);
        $(".large-image-wrapper img").attr("src", largeImage);

        $(".large-image-close").bind('click', function () {
            $(this).siblings("img").attr("src", "")
                .closest(".large-image-wrapper").remove();
            $(".large-image-bg").remove();
        });
    });
});