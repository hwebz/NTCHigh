// Define our root namespace if necessary
var RESIDENTIAL = window.RESIDENTIAL || {};


var slides = 4;
var slideMode = 'vertical';

RESIDENTIAL.setup = {

    init: function () {
        var $carouselWrapper = $(".carousel-wrapper");
        var $imgGalleryCarousel = $(".img-gallery-slider");

        this.carouselfixheight();
        if ($carouselWrapper.length) {
            this.owlCarousel();
        }

        if ($imgGalleryCarousel.length) {
            console.log("inside img gallery");
            this.imgGallerySetup();
        }

        RESIDENTIAL.setup.accordionIconChange();
        RESIDENTIAL.setup.smoothScroll();
        RESIDENTIAL.setup.buttonToggle();
    },

    carouselfixheight: function () {
        var $carouselItem = $(".img-slider .bxslider-img img");
        var upperHeight = $(".logo-container").innerHeight() + $(".navbar").innerHeight();
        var pageHeight = $(window).height() - upperHeight;

        $carouselItem.height(pageHeight);
    },

    imgGallerySetup: function () {
        console.log("in img gallery init");

        $('.img-gallery-slider').each(function (i) {
            console.log("inside first loop: " + i);
            $(this).find(".bxslider-img-gallery").bxSlider({
                mode: 'horizontal',
                useCSS: false,
                responsive: true,
                pagerCustom: "." + $(this).data("pager")
            });
            $(this).find(".gallery-pager." + $(this).data("pager")).bxSlider({
                mode: slideMode,
                pager: false,
                minSlides: slides,
                maxSlides: slides,
                slideWidth: 200,
                slideMargin: 10
            });
        })
    },

    owlCarousel: function () {
        var owl = $(".owl-carousel");

        owl.owlCarousel({
            merge: true,
            autoPlay: isAuto,
            pager: isAuto,
            navigation: false,
            singleItem: true,
            transitionStyle: "fade"
        });
    },

    accordionIconChange: function () {
        $('.collapse').on('shown.bs.collapse', function () {
            $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
        }).on('hidden.bs.collapse', function () {
            $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
        });
    },

    smoothScroll: function () {
        $('.btn.btn-top ').on('click', scrollToTop);
    },

    buttonToggle: function () {
        $('.btn-toggle').click(function () {
            $(this).find('.btn').toggleClass('active');

            if ($(this).find('.btn-primary').size() > 0) {
                $(this).find('.btn').toggleClass('btn-primary');
            }

            $(this).find('.btn').toggleClass('btn-default');

        });

        $('.btn.btn-lg.A').click(function () {
            $('.Coming-cources').css('display', 'block');
            $('.past-courses').css('display', 'none');
        });

        $('.btn.btn-lg.B').click(function () {
            $('.past-courses').css('display', 'block');
            $('.Coming-cources').css('display', 'none');
        });
    }

}

var isAuto = false;

$(function () {

    if ($('.owl-carousel div').length > 1) {
        isAuto = true;
    }

    var wd = window.innerWidth || $(window).width();
    if (wd < 768) {
        slideMode = 'horizontal';
        wd > 550 ? slides = 4 : wd > 400 ? slides = 3 : slides = 2;
    }

    RESIDENTIAL.setup.init();

    $('.bx-next').html('');
    $('.bx-prev').html('');
});

function scrollToTop() {
    verticalOffset = typeof (verticalOffset) != 'undefined' ? verticalOffset : 0;
    element = $('body');
    offset = element.offset();
    offsetTop = offset.top;
    $('html, body').animate({ scrollTop: offsetTop }, 500, 'linear');
}
