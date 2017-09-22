// Define our root namespace if necessary
var COMMERCIAL = window.COMMERCIAL || {};

COMMERCIAL.setup = {
    init: function () {

        var $imgCarousel = $(".img-slider");
        var $videoCarousel = $(".video-slider");

        if ($imgCarousel.length) {
            this.carouselfixheight();
            this.imgCarouselSetup();
            //this.owlCarousel();
        }
        if ($videoCarousel.length) {
            console.log("in video");
            this.videoCarouselSetup();
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
        $('.bxslider-video').bxSlider({
            video: true,
            useCSS: false,
            pagerCustom: '.gallery-pager',

            /*onSlideAfter: function($slideElement, oldIndex, newIndex) {
    
              iframeSrcPrev = $slideElement.prev().find(".video-iframe").attr("src");
              iframeSrcNext = $slideElement.next().find(".video-iframe").attr("src");
              
              console.log("iframeSrcPrev", iframeSrcPrev);
              console.log("iframeSrcNext", iframeSrcNext);
    
              $slideElement.prev().find(".video-iframe").attr("src", "");
              $slideElement.next().find(".video-iframe").attr("src", "");
              $slideElement.prev().find(".video-iframe").attr("src", iframeSrcPrev);
              $slideElement.next().find(".video-iframe").attr("src", iframeSrcNext);
            }*/
        });

        $(".gallery-pager").bxSlider({
            mode: 'vertical',
            pager: false,
            minSlides: 4,
            maxSlides: 4,
            slideMargin: 10
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
    }
}

var isAuto = false;
$(document).ready(function () {

    $('.bxslider-img li').length > 1 ? isAuto = true : '';

    COMMERCIAL.setup.init();

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

