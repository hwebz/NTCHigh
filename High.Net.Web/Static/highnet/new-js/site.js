// Define our root namespace if necessary
var COMMERCIAL = window.COMMERCIAL || {};

var slides = 2;
var slideMode = 'vertical';

$(function () {
    if ($(window).load) {
        $("ul.bxslider-img li").css("display", "block");
    };
});


var players = [];
function onYouTubePlayerAPIReady() {
    $('.bxslider-video iframe').each(function () {
        players.push(new YT.Player(this));
    });
}

COMMERCIAL.setup = {
    init: function () {

        var $imgCarousel = $(".img-slider");
        var $videoCarousel = $(".video-slider");
        var $textCarousel = $(".text-slider");

        if ($imgCarousel.length) {
            //this.carouselfixheight();
            this.imgCarouselSetup();
        }
        if ($videoCarousel.length) {
            this.videoCarouselSetup();
        }

        if ($textCarousel.length) {
            this.textCarouselSetup();
        }
    },

    carouselfixheight: function () {
        var $carouselItem = $(".img-slider .bxslider-img img");
        var upperHeight = $(".contact-detail").innerHeight() + $(".navbar").innerHeight();
        var imgHeight = $(window).height() - upperHeight;
        console.log("img hieght", imgHeight);
        $carouselItem.height(imgHeight);

    },

    imgCarouselSetup: function () {
        $(".enter").click(function () {
            $('.bxslider-img').bxSlider({
                auto: true,
                pager: true
            });
        });

    },

    videoCarouselSetup: function () {
        var slider = $('.bxslider-video').bxSlider({
            video: true,
            useCSS: false,
            pagerCustom: '.gallery-pager',
            onSlideBefore: function ($slideElement, oldIndex, newIndex) {
                players[oldIndex].B.playerState == 1 ? players[oldIndex].pauseVideo() : '';
            }
        });

        $(".gallery-pager").bxSlider({
            mode: slideMode,
            pager: false,
            minSlides: slides,
            maxSlides: slides,
            slideWidth: 200,
            infiniteLoop: false,
            slideMargin: 10
        });

    },

    textCarouselSetup: function () {
        console.log("in img init");
        $('.bxslider-text').bxSlider({
            mode: 'horizontal',
            pager: false
        });
    }
}

//var isAuto = false;

$(function () {

    //if ($('.bxslider-img li').length > 1) {
    //    isAuto = true;
    //}

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
