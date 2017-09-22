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
    videoSlider: {},
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
 
        $carouselItem.height(imgHeight);

    },

    imgCarouselSetup: function () {
        $('.bxslider-img').bxSlider({
            auto: true,
            pager: true
        });
    },

	videoCarouselSetup: function () {
	    var _that = this;
        $('.bxslider-video').bxSlider({
            video: true,
            useCSS: false,
            pagerCustom: '.gallery-pager',
            onSlideBefore: function ($slideElement, oldIndex, newIndex) {
                players[oldIndex].B.playerState == 1 ? players[oldIndex].pauseVideo() : '';
            }
		});
        this.videoSlider = $(".gallery-pager").bxSlider({
            mode: slideMode,
            pager: false,
            minSlides: slides,
            maxSlides: slides,
            slideWidth: 200,
            infiniteLoop: false,
            slideMargin: 10,
            onSlideBefore: function ($slideElement, oldIndex, newIndex) {
                window.youtubeItems.forEach(function (item, index) {
                    var imgTag = '<img class="thumb" src="{0}" />';
                    $('.slide-lazy-thumb-' + index).append(imgTag.replace("{0}", item.ImageThumbnailUrl)).removeClass('slide-lazy-thumb-' + index);
                });
			},
            onSlideAfter: function() {
                _that.videoSlider.redrawSlider();
            }
        });

    },

	videoSliderReload: function () {
	    var _that = this;
        this.videoSlider.reloadSlider({
            mode: slideMode,
            pager: false,
            minSlides: slides,
            maxSlides: slides,
            slideWidth: 200,
            infiniteLoop: false,
			slideMargin: 10,
			onSlideBefore: function ($slideElement, oldIndex, newIndex) {
			    window.youtubeItems.forEach(function (item, index) {
			        var imgTag = '<img class="thumb" src="{0}" />';
			        $('.slide-lazy-thumb-' + index).append(imgTag.replace("{0}", item.ImageThumbnailUrl)).removeClass('slide-lazy-thumb-' + index);
			    });
			},
            onSlideAfter: function() {
                _that.videoSlider.redrawSlider();
            }
        });
        $('.bx-next').html('');
        $('.bx-prev').html('');
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

function reCalculateSliderParams() {
    //if ($('.bxslider-img li').length > 1) {
    //    isAuto = true;
    //}

    var wd = window.innerWidth || $(window).width();
    if (wd < 1200) {
        if (wd > 767) {
            slides = 2;
            slideMode = 'vertical';
        }
        else if (wd <= 767 && wd > 600) {
            slideMode = 'horizontal';
        }
        else if (wd <= 600 && wd > 500) {
            slideMode = 'horizontal';
            slides = 2;
        }
        else {
            slideMode = 'horizontal';
            slides = 2;
        }
    }
}

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

$(function () {

    reCalculateSliderParams();
    COMMERCIAL.setup.init();

    $(window).resize(throttle(function() {
        reCalculateSliderParams();
        COMMERCIAL.setup.videoSliderReload();
    }, 100));

    $('.bx-next').html('');
    $('.bx-prev').html('');

    $('.youtube-wrapper').click(function() {
        var iframe = document.createElement("iframe");
        iframe.setAttribute("id", "vid_frame");
        iframe.setAttribute("frameborder", "0");
        iframe.setAttribute("allowfullscreen", "");
        iframe.setAttribute("src", $('#youtube-player').attr('data-video-url'));

        this.innerHTML = "";
        this.appendChild(iframe);
    });

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




