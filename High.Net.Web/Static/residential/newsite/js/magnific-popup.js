(function () {

	var MagnificPopup = function (selector, options) {
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

	var magnificPopup = new MagnificPopup('.image-lightbox', {
		type: 'image',
		closeOnContentClick: true,
		closeBtnInside: false,
		fixedContentPos: true,
		mainClass: 'mfp-no-margins mfp-with-zoom',
		image: {
			verticalFit: true
		},
		zoom: {
			enabled: true,
			duration: 300
		},
		callbacks: {
			elementParse: function (qw) {
				qw.src = qw.el[0].getAttribute('src');
			}
		}
	});
	magnificPopup.init();

})();