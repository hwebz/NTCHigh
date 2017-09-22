(function () {

    $.fn.imgLoad = function (callback) {
        return this.each(function () {
            if (callback) {
                if (this.complete || /*for IE 10-*/ $(this).height() > 0) {
                    callback.apply(this);
                }
                else {
                    $(this).on('load', function () {
                        callback.apply(this);
                    });
                }
            }
        });
    };

    var PhotoGallery = function (selector, child) {
		var photoGallery = $(selector);
        var photos = photoGallery.find(child + " img");

		var resizeImages = function() {
			photos.imgLoad(function () {
			    var $this = $(this);
			    var parentInfor = {
			        width: $this.parent().width(),
			        height: $this.parent().height()
			    };
			    var imgInfor = {
			        width: $this.width(),
			        height: $this.height()
			    };

			    var fillClass = '';

			    if (parentInfor.width / parentInfor.height > imgInfor.width / imgInfor.height) {
			        fillClass = (parentInfor.height > parentInfor.width)
			            ? 'fillheight'
			            : 'fillwidth';
			    } else {
			        fillClass = (imgInfor.height > imgInfor.width)
			            ? 'fillwidth'
			            : 'fillheight';
			    }
			    $(this).removeClass('fillheight').removeClass('fillwidth').addClass(fillClass);
			});
		}

        var init = function () {
            // Check ele defined or not
			if (typeof photoGallery !== 'undefined' && typeof photos !== 'undefined') {

				// resize at first loaded
				resizeImages();

				// resize on user resize window
				$(window).on('resize orientationchange', $.debounce(5, resizeImages));
			}
        }

        return {
            init: init
        }
    }

	var carouselSlider = new PhotoGallery('.leadership-carousel-slider', '.leadership-carousel-slider__slider-item__thumbnail');
    carouselSlider.init();

    var photoGallery = new PhotoGallery('.leadership-photo-gallery', '.leadership-photo-gallery__slider-item__item');
    photoGallery.init();

    var photoSlider = new PhotoGallery('.leadership-photo-slider', '.leadership-photo-slider__thumbnail');
    photoSlider.init();
})();