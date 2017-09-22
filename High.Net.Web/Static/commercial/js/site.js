// Define our root namespace if necessary
var COMMERCIAL = window.COMMERCIAL || {};

var slides = 4;
var slideMode = 'vertical';

COMMERCIAL.setup = {
    init: function () {

        var $imgCarousel = $(".img-slider");
        var $videoCarousel = $(".video-slider");
        var $imgGalleryCarousel = $(".img-gallery-slider");

        if ($imgCarousel.length) {
            this.carouselfixheight();
            this.imgCarouselSetup();
            //this.owlCarousel();
        }
        if ($videoCarousel.length) {
            console.log("in video");
            this.videoCarouselSetup();
        }

        if ($imgGalleryCarousel.length) {
            console.log("inside img gallery");
            this.imgGallerySetup();
        }
    },

    carouselfixheight: function () {
        var $carouselItem = $(".img-slider .bxslider-img img");
        var upperHeight = $(".logo-container").innerHeight() + $(".navbar").innerHeight();
        var pageHeight = $(window).height() - upperHeight;
        console.log(".cd-hero-slider height", pageHeight);
        $carouselItem.height(pageHeight);
    },

    imgCarouselSetup: function () {
        console.log("in img init");
        $('.bxslider-img').bxSlider({
            mode: 'fade',
            auto: isAuto,
            pause: 5000,
            pager: isAuto
        });
    },

    videoCarouselSetup: function () {
        console.log("in video init");
        var slider = $('.bxslider-video').bxSlider({
            video: true,
            useCSS: false,
            pagerCustom: '.gallery-pager',
            onSlideBefore: function ($slideElement, oldIndex, newIndex) {
                players[oldIndex].pauseVideo();
            }
        });

        $(".gallery-pager").bxSlider({
            mode: slideMode,
            pager: false,
            minSlides: slides,
            maxSlides: slides,
            slideWidth: 200,
            slideMargin: 10,
            infiniteLoop: false
        });
    },

    owlCarousel: function () {
        console.log("inside owl carousel");
        var owl = $(".owl-carousel");

        owl.owlCarousel({
            merge: true,
            autoPlay: true,
            navigation: false,
            singleItem: true,
            transitionStyle: "fade"
        });
    },

    imgGallerySetup: function () {
        console.log("in img gallery init");

        $('.img-gallery-slider').each(function (i) {
            console.log("inside first loop: " + i);
            $(this).find(".bxslider-img-gallery").bxSlider({
                mode: 'horizontal',
                useCSS: false,
                responsive: true,
                pagerCustom: "." + $(this).data("pager"),
                slideWidth: 490,
                adaptiveHeight: true,
            });
            $(this).find(".gallery-pager." + $(this).data("pager")).bxSlider({
                mode: 'vertical',
                pager: false,
                minSlides: 4,
                maxSlides: 4,
                slideMargin: 10,
            });
        })
    }
}



var players = [];
function onYouTubePlayerAPIReady() {
    $('.bxslider-video iframe').each(function () {
        players.push(new YT.Player(this));
    });
}


var isAuto = false;
$(function () {
    //$('.bxslider-img li').length > 1 ? isAuto = true : '';

    if ($('.bxslider-img li').length > 1) {
        isAuto = true;
    }

    var wd = window.innerWidth || $(window).width();
    if (wd < 1200) {
        if (wd > 767) {
            slides = 3;
        }
        else if (wd <= 767 && wd > 600) {
            slideMode = 'horizontal';
        }
        else if (wd <= 600 && wd > 500) {
            slideMode = 'horizontal';
            slides = 3;
        }
        else {
            slideMode = 'horizontal';
            slides = 2;
        }
    }

    COMMERCIAL.setup.init();

    $('.bx-next').html('');
    $('.bx-prev').html('');

    function initMap() {
        var myLatLng = { lat: -25.363, lng: 131.044 };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 4,
            center: myLatLng
        });

        var marker = new google.maps.Marker({
            position: myLatLng,
            map: map,
            title: 'Hello World!'
        });
    }
});
