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

	var carouselSlider = new CarouselSlider(".leadership-carousel-slider__slider", {
        autoplay: window.AparmentSliderAutoPlay,
		autoplaySpeed: 10000,
        lazyLoad: 'ondemand',
        fade: true,
		dots: true,
		arrows: false
    });
	carouselSlider.init();

	var testimonialSlider = new CarouselSlider(".leadership-testimonial-slider__slider", {
        autoplay: window.AparmentSliderAutoPlay,
        autoplaySpeed: 10000,
        lazyLoad: 'ondemand',
        dots: true,
		adaptiveHeight: true
    });
	testimonialSlider.init();

    var photoGallerySlider = new CarouselSlider(".leadership-photo-gallery__slider", {
        autoplay: window.AparmentSliderAutoPlay,
        autoplaySpeed: 10000,
		lazyLoad: 'ondemand',
        fade: true,
		dots: true,
		arrows: false,
        adaptiveHeight: true
    });
	photoGallerySlider.init();

    var photoSlider = new CarouselSlider(".leadership-photo-slider__slider", {
        autoplay: window.AparmentSliderAutoPlay,
        autoplaySpeed: 10000,
        lazyLoad: 'ondemand',
        dots: true,
        arrows: true,
        adaptiveHeight: true
    });
    photoSlider.init();

})();