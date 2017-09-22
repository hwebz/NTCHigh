(function () {

    var PhotoGallery = function (selector, child) {
		var photoGallery = $(selector);
        var photos = photoGallery.find(child + " img");

		var resizeImages = function() {
			photos.each(function () {
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
				$(window).on('resize orientationchange', $.debounce(50, resizeImages));
			}
        }

        return {
            init: init
        }
    }

	var photoGallery = new PhotoGallery('.photo-gallery', '.residential-service-gallery__thumbnail');
    photoGallery.init();
	var eventList = new PhotoGallery('.photo-gallery', '.residential-event-list__thumbnail');
    eventList.init();
})();