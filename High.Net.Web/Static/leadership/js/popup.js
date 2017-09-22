(function () {

	var rePositioningArrow = function() {
		var mfpContent = typeof $(".mfp-content").offset() != 'undefined' ? $(".mfp-content") : null;
	    var mfpContentProps = {
	        offset: mfpContent.offset(),
	        width: mfpContent.width(),
	        height: mfpContent.height()
	    };
        var windowHeight = window.innerHeight;
	    var arrowLeft = $(".mfp-arrow-left");
	    var arrowRight = $(".mfp-arrow-right");
        console.log(mfpContentProps.height);

	    arrowLeft.css({
	        left: mfpContentProps.offset.left,
	        top: ((windowHeight - mfpContentProps.height) / 2) + mfpContentProps.height
	    });
	    arrowRight.css({
	        right: mfpContentProps.offset.left,
	        top: ((windowHeight - mfpContentProps.height) / 2) + mfpContentProps.height
	    });
	}

    var gelleryOptions = {
        enabled: true,
        navigateByImgClick: true,
        preload: [0, 1], // Will preload 0 - before current, and 1 after the current image
        arrowMarkup: '<button title="%title%" type="button" class="mfp-arrow mfp-arrow-%dir%">%title%</button>',
        tPrev: 'Previous', // title for left button
        tNext: 'Next', // title for right button
        tCounter: '%curr%/%total%'
    };

    var imageOptions = {
        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
        verticalFit: true,
        titleSrc: function(item) {
            var detailsTxt = '';
            $(item.el[0]).parent().next().find('p').each(function () {
                var $this = $(this);
                detailsTxt += $this.html();
            });
            return detailsTxt;
        }
	};

	var photoGalleryImageOptions = {
		tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
		verticalFit: true,
		titleSrc: function (item) {
		    var detailsTxt = $(item.el[0]).attr('data-text') || '';
		    return detailsTxt;
		}
	}

    var photoSliderImageOptions = {
        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
        verticalFit: true,
        titleSrc: function (item) {
			var detailsTxt = '';
            $(item.el[0]).parent().next().find('p').each(function() {
				var $this = $(this);
				detailsTxt += $this.html();
            });
            return detailsTxt;
        }
    }

    var zoomOptions = {
        enabled: true,
        duration: 300
    };

    var Popup = function (selector, options) {
        var element = $(selector);

        var init = function () {
            if (typeof element !== 'undefined' && typeof $.fn.magnificPopup !== 'undefined') {
                element.magnificPopup(options);
            }
        }

        return {
            init: init
        }
	};

	var callbacksOptions = {
		elementParse: function (qw) {
		    qw.src = qw.el[0].getAttribute('data-image');
		},
		open: function () {
		    // disable scroll
			$('html, body').addClass('overflow-hidden');
			// hide arrows before re-calculate position
		    $(".mfp-arrow").hide();
		},
		close: function () {
		    // enable scroll
			$('html, body').removeClass('overflow-hidden');
		},
		imageLoadComplete: function () {
			rePositioningArrow();
		    $(".mfp-arrow").fadeIn('fast');
		},
		resize: function () {
			rePositioningArrow();
		    $(".mfp-arrow").fadeIn('fast');
		}
	}

	// Video popup
	var videoPopup = new Popup('.video-lightbox', {
	    //disableOn: 700,
	    type: 'iframe',
		mainClass: 'mfp-fade',
	    preloader: false,
	    callbacks: {
	        open: function () {
	            // disable scroll
	            $('html, body').css('overflow', 'hidden !important');
	        },
	        close: function () {
	            // enable scroll
	            $('html, body').removeAttr('style');
	        }
	    }
	});
	videoPopup.init();

	// Carousel slider images
    var carouselSliderPopup = new Popup('.image-lightbox', {
		type: 'image',
		tLoading: 'Loading image #%curr%...',
		mainClass: 'mfp-no-margins mfp-with-zoom',
		gallery: gelleryOptions,
		image: imageOptions,
		zoom: zoomOptions,
		callbacks: callbacksOptions
    });
	carouselSliderPopup.init();

	var messageUp = new Popup('#message-us', {
	    type: 'inline',
	    preloader: false,
	    focus: '#fullname',

	    // When elemened is focused, some mobile browsers in some cases zoom in
	    // It looks not nice, so we disable it:
	    callbacks: {
	        beforeOpen: function () {
	            if ($(window).width() <= 768) {
	                this.st.focus = false;
	            } else {
	                this.st.focus = '#fullname';
                }
	            if ($("#recaptchar_tag").length === 0) {
	                var script = document.createElement('script');
	                script.id = "recaptchar_tag";
	                script.type = 'text/javascript';
	                script.async = true;
	                script.src =
	                    "https://www.google.com/recaptcha/api.js?onload=initRecaptchaElements&render=explicit&hl={0}";
	                document.body.appendChild(script);
	            }
			},
			open: function () {
	            // disable scroll
				$('html, body').addClass('overflow-hidden');
	        },
	        close: function () {
	            // enable scroll
				$('html, body').removeClass('overflow-hidden');
	        }
	    }
	});
	messageUp.init();

    // Photo gallery images
	var photoGallery = '.leadership-photo-gallery.popup';
    var photoGalleryItems = $(photoGallery).find('.leadership-photo-gallery__slider-item');
	var photoGalleryPopup = null;

	for (var i = 0; i < photoGalleryItems.length; i++) {
	    $(photoGalleryItems[i]).find(".leadership-photo-gallery__slider-item__item").each(function (j, ele) {
	        $(ele).find('>img').addClass('photo-gallery-image-lightbox-' + (i + 1));
	    }).promise().done(function() {
			photoGalleryPopup = new Popup('.photo-gallery-image-lightbox-' + (i + 1), {
	            type: 'image',
	            tLoading: 'Loading image #%curr%...',
	            mainClass: 'mfp-no-margins mfp-with-zoom',
	            gallery: gelleryOptions,
	            image: photoGalleryImageOptions,
	            zoom: zoomOptions,
	            callbacks: callbacksOptions
	        });
	        photoGalleryPopup.init();
	    });
	}

    // Photo slider images
	// Remove popup for slick-cloned item
    $(".leadership-photo-slider .leadership-photo-slider__slider-item.slick-cloned .leadership-photo-slider__thumbnail img")
		.removeClass('photo-lightbox');
    var photoSlider = new Popup('.photo-lightbox', {
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        mainClass: 'mfp-no-margins mfp-with-zoom',
        gallery: gelleryOptions,
		image: photoSliderImageOptions,
        zoom: zoomOptions,
        callbacks: callbacksOptions
    });
    photoSlider.init();

})();