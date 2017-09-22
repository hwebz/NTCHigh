(function () {

    var CarouselSlider = function (selector, options) {
        var slider = $(selector);

        var init = function () {
            if (typeof slider !== 'undefined') slider.slick(options);
        }

        return {
            init: init
        }
    }

    var testimonialSlider = new CarouselSlider(".leadership-testimonial-slider__slider", {
        autoplay: window.AparmentSliderAutoPlay,
        autoplaySpeed: 10000,
        lazyLoad: 'ondemand',
        dots: true,
        adaptiveHeight: false,
        responsive: [
            {
                breakpoint: 768,
                settings: {
					adaptiveHeight: true,
					arrows: false
				}
		    }
		]
    });
	testimonialSlider.init();

    var articleSlider = new CarouselSlider(".leadership-article-slider__slider", {
        autoplay: window.AparmentSliderAutoPlay,
        autoplaySpeed: 10000,
		lazyLoad: 'ondemand',
		dots: true,
		arrows: true,
		adaptiveHeight: false,
        responsive: [
            {
                breakpoint: 768,
				settings: {
				    adaptiveHeight: true,
                    arrows: false
                }
            }
        ]
    });
	articleSlider.init();

	function rePositiongText() {
		var articleSliderText = $(".leadership-article-slider__slider-item .wrapper-center-div")
	    articleSliderText.each(function () {
	        var $this = $(this);
	        var textHeight = $this.height();
			var wrapperHeight = $this.parents('.leadership-article-slider__slider-item__description-wrapper').height();

	        if (textHeight > wrapperHeight) {
	            $this.css({
					top: 0,
	                transform: 'none',
	                '-webkit-transform': 'none',
	                '-moz-transform': 'none',
	                '-ms-transform': 'none',
					'-o-transform': 'none',
					position: 'initial'
				});
	        } else {
				$this.removeAttr('style');
	        }
		});
	}

    rePositiongText();
    $(window).on('resize orientationchange', $.debounce(5, rePositiongText));
})();