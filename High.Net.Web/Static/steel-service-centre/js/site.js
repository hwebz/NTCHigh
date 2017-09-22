// Define our root namespace if necessary
var COMMERCIAL = window.COMMERCIAL || {};

$(function () {
    if ($(window).load) {
        $("ul.bxslider-img li").css("display", "block");
    };
});



COMMERCIAL.setup = {
	init: function () {
        
        var $imgCarousel = $(".img-slider");
        var $videoCarousel = $(".video-slider");
        var $textCarousel = $(".text-slider");
        
        if($imgCarousel.length) {
            //this.carouselfixheight();
            this.imgCarouselSetup(); 
        }
        if($videoCarousel.length) {
            this.videoCarouselSetup();
        }
        
        if($textCarousel.length) {
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
    
    imgCarouselSetup: function() {
         console.log("in img init");
        $('.bxslider-img').bxSlider({
            auto: isAuto,
            pager:isAuto
          });
    },
    
    videoCarouselSetup: function() {
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
            pager:false,
            minSlides: 4,
            maxSlides: 4,
            slideMargin: 10
        });
        
    },
    
    textCarouselSetup: function() {
        console.log("in img init");
        $('.bxslider-text').bxSlider({
            mode: 'horizontal',
            pager:false
          });
    }
}

var isAuto = false;

$(document).ready(function() {

    if ($('.bxslider-img li').length > 1) {
        isAuto = true;
    }

    COMMERCIAL.setup.init();

	function initMap() {
  		var myLatLng = {lat: -25.363, lng: 131.044};
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
