//main slider
if ($(".re-slide .carousel-inner .item").length < 2) {
    $(".al").hide();
    $(".ar").hide();
}

$(".carousel-inner .item:first-child").addClass("active");

$('.re-slide').carousel({
    interval: 3000
});

var maxHeight = 0;
$(".com-spec").each(function() {
    if ($(this).height() > maxHeight) { maxHeight = $(this).height(); }
});

$(".com-spec").height(maxHeight);

$(function() {

    if ($(".row.logo-items > div").length > 0) {
        $(".row.logo-items > div").slice(0, 12).show();
        $("#loadMore").on('click', function(e) {
            e.preventDefault();
            var _that = $(this);
            var hiddenItems = $(".row.logo-items > div:hidden");
            hiddenItems.slice(0, 12).slideDown('fast', function() {
                if (hiddenItems.length < 12) {
                    _that.fadeOut('fast');
                }
            });
        });
    }

    $(".re-share").click(function() {
        $(this).next(".si-img ").toggle();
    });
});

$(document).ready(function() {
    var slickEles = $(".regular, .center, .variable");
    if (typeof(slickEles) != 'undefined' && slickEles != null) {
        if ($.fn.slick) {
            $(".regular, .center, .variable").slick({
                dots: true,
                infinite: true,
                speed: 300,
                slidesToShow: 3,
                slidesToScroll: 3,
                centerMode: true,
                responsive: [{
                        breakpoint: 1200,
                        settings: {
                            slidesToShow: 2
                        }
                    },
                    {
                        breakpoint: 768,
                        settings: {
                            slidesToShow: 1
                        }
                    }
                ]
            });
        }
    }
});

//var maxHeight = 0;
//$(".caro-cont").each(function () {
//    if ($(this).height() > maxHeight) { maxHeight = $(this).height(); }
//});

//$(".caro-cont").height(maxHeight);

equalheight = function(container) {

    var currentTallest = 0,
        currentRowStart = 0,
        rowDivs = new Array(),
        $el,
        topPosition = 0;
    $(container).each(function() {

        $el = $(this);
        $($el).height('auto')
        topPostion = $el.position().top;

        if (currentRowStart != topPostion) {
            for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
                rowDivs[currentDiv].height(currentTallest);
            }
            rowDivs.length = 0; // empty the array
            currentRowStart = topPostion;
            currentTallest = $el.height();
            rowDivs.push($el);
        } else {
            rowDivs.push($el);
            currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
        }
        for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
            rowDivs[currentDiv].height(currentTallest);
        }
    });
};

carouselheight = function(container) {
    var tallest = 0;

    if ($(container)) {
        $(container)
            .each(function() {
                $el = $(this);
                tallest = tallest < $el.height() ? $el.height() : tallest;
            });
        $(container).height(tallest);
    }
}

var breakpoints = ['full', 'three-fourth', 'wide', 'half', 'narrow', 'one-quater', 'small', 'extra-small'];
$(window).load(function() {
    equalheight('.logo-items .logowallitemblock, .carouseler .slick-slide, .feaured-pos .featurepositionitemblock, .tms-testimonial-carousel .carousel-inner .item');
    for (var i = 0; i < breakpoints.length; i++) {
        carouselheight('.photogalleryblock.' + breakpoints[i] + ' .carousel-inner .item .row .col-xs-12 > div');
    }
});


$(window).resize(function() {
    equalheight('.logo-items .logowallitemblock, .carouseler .slick-slide, .feaured-pos .featurepositionitemblock, .tms-testimonial-carousel .carousel-inner .item');
    for (var i = 0; i < breakpoints.length; i++) {
        carouselheight('.photogalleryblock.' + breakpoints[i] + ' .carousel-inner .item .row .col-xs-12 > div');
    }
});

// POPUPS
//$(".high__popup .mask .high__popup__wrapper > a").bind('click', function(event) {
//    event.preventDefault();

//    // close popup
//    $(this).parents('.high__popup').addClass('hidden');

//    return false;
//});

// Home blocks on home page - text ellipse
function throttle(callback, limit) {
    var wait = false;
    return function() {
        if (!wait) {

            callback.apply(null, arguments);
            wait = true;
            setTimeout(function() {
                wait = false;
            }, limit);
        }
    }
}

function lineclamp(selector, child) {
    var lineheight = parseFloat($(child).css('line-height'));
    var articleheight = $(selector).height();
    var calc = parseInt(articleheight / lineheight);
    $(child).css({
        "-webkit-line-clamp": "" + calc + ""
    });
}


$(document).ready(function() {
    lineclamp('.block-main-content', 'p');
    lineclamp('.block-main-content', 'p span');
    lineclamp('.block-main-content', 'ul li');

    $('.image-popup-no-margins').magnificPopup({
        type: 'image',
        closeOnContentClick: true,
        closeBtnInside: false,
        fixedContentPos: true,
        mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
        
    });
});

$(window).resize(throttle(function() {
    lineclamp('.block-main-content', 'p');
    lineclamp('.block-main-content', 'p span');
    lineclamp('.block-main-content', 'ul li');
}, 200));

// =============================================== //
// ================ MEDIA ROOM =================== //
// =============================================== //
// Datetimepicker
$(document).ready(function () {
    // Init datetime picker for Media Room page
    var $selectBox = $("#dateRange");
    var $from = $("#from");
    var $to = $("#to");
    var nextMonth = (new Date(

    )).setMonth((new Date()).getMonth() + 1);
    var popup = $(".date-range");
    $from.datetimepicker({
        format: 'MM-DD-YYYY',
        keepOpen: true,
        inline: true,
        viewMode: 'days'
    });

    $to.datetimepicker({
        format: 'MM-DD-YYYY',
        keepOpen: true,
        inline: true,
        defaultDate: nextMonth,
        viewMode: 'days'
    });

    function setDateFormat(from, to) {
        $selectBox.val(("0" + (from.getMonth() + 1)).slice(-2) + '/' + ("0" + from.getDate()).slice(-2) + '/' + from.getFullYear() + ' - ' + ("0" + (from.getMonth() + 1)).slice(-2) + '/' + ("0" + to.getDate()).slice(-2) + '/' + to.getFullYear());
    }

    // Trigger to open both From and To datetimepicker when selectBox was focus.
    setDateFormat(new Date($from.val()), new Date($to.val()));
    $selectBox.on('focus', function () {
        popup.show();
    }).on('blur', function () {
        popup.hide();
    });

    $("#from, #to").on('dp.change', function () {
        // Validate range
        var from = new Date($from.val());
        var to = new Date($to.val());

        // Set datetime to #dateRange
        setDateFormat(from, to);

        if (from < to) {
            // VALID DATE RANGE


        } else {
            $selectBox.addClass('error');
        }
    });

});