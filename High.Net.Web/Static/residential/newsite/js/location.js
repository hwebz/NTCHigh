(function () {
    var locationEle = document.getElementById("residential-location__map");
    var Location = function (locationEle, pos) {
        //var locationEle = document.getElementById("residential-location__map");

        var map;

		var rePositionMarker = function () {
			if (!pos.isCentered) {
				if ($(window).width() < 768) {
					map.setCenter(new google.maps.LatLng(pos.lat + 0.00024, pos.long));
				} else if ($(window).width() >= 768 && $(window).width() < 1200) {
					map.setCenter(new google.maps.LatLng(pos.lat + 0.00024, pos.long - 0.003));
				} else {
					map.setCenter(new google.maps.LatLng(pos.lat + 0.00024, pos.long - 0.005));
				}
			} else {
				map.setCenter(new google.maps.LatLng(pos.lat, pos.long));
			}
        }

        var googleInitialize = function () {
            if (typeof locationEle !== 'undefined') {
                var mapOptions = {
                    zoom: 17,
                    center: new google.maps.LatLng(pos.lat + 0.00024, pos.long - 0.005),
                    disableDefaultUI: true,
                    draggable: !("ontouchend" in document)
                };
                map = new google.maps.Map(locationEle,
                    mapOptions);
                var marker = new google.maps.Marker({
                    map: map,
                    position: new google.maps.LatLng(pos.lat, pos.long),
                    disableDefaultUI: true
                });

                // Resize to re-center marker
                //Use event listener for resize on window
                rePositionMarker();
                google.maps.event.addDomListener(window, 'resize', $.debounce(50, rePositionMarker));
            }
        }

        var init = function () {
            google.maps.event.addDomListener(window, 'load', googleInitialize);
        }

        return {
			init: init,
			rePositionMarker: rePositionMarker
        }
    }

    $("#residential-location__map").each(function (idx, item) {
        var latStr = $(item).attr("data-lat");
		var longStr = $(item).attr("data-long");
		var isCentered = $(item).attr("data-center");

        if (latStr && longStr) {
            try {
                var menu = new Location(locationEle, {
                    lat: parseFloat(latStr),
					long: parseFloat(longStr),
					isCentered: typeof isCentered !== 'undefined' ? (isCentered.toLowerCase() == 'true' ? true : false) : false
                });
                menu.init();
            } catch (e) {
                console.log(e);
            }
           
        }
    });    

})();