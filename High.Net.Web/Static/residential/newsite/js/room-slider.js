(function () {

	var RoomSlider = function (options) {
		var slider = $(".residential-room-slider__slider");

		var init = function () {
			if (typeof slider !== 'undefined') slider.slick(options);
		}

		return {
			init: init
		}
	}

	var roomSlider = new RoomSlider({
        autoplay: window.AparmentSliderAutoPlay,
        autoplaySpeed:10000,
		dots: false
	});
	roomSlider.init();

})();