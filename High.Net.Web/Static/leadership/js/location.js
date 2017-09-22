(function () {
	var locationEle = document.getElementById("leadership-location__map");
    var loc = window.location;
    var baseUrl = loc.protocol + "//" + loc.hostname + (loc.port ? ":" + loc.port : "") + "/";
    var Location = function (locationEle, pos) {
        //var locationEle = document.getElementById("residential-location__map");

        var map;

		var rePositionMarker = function () {
			if (!pos.isCentered) {
				if ($(window).width() < 768) {
				    map.setCenter(new google.maps.LatLng(pos.lat - 0.0007, pos.long));
				} else if ($(window).width() >= 768 && $(window).width() < 1400) {
				    map.setCenter(new google.maps.LatLng(pos.lat + 0.0002, pos.long - 0.0015));
				} else {
					map.setCenter(new google.maps.LatLng(pos.lat + 0.0002, pos.long - 0.0024));
				}
			} else {
				map.setCenter(new google.maps.LatLng(pos.lat, pos.long));
			}
        }

        var googleInitialize = function () {
            if (typeof locationEle !== 'undefined') {
                var mapOptions = {
                    zoom: 18,
                    center: new google.maps.LatLng(pos.lat + 0.0002, pos.long - 0.0024),
                    disableDefaultUI: true,
                    draggable: !("ontouchend" in document)
				};
				
                map = new google.maps.Map(locationEle,
					mapOptions);
				console.log
                var marker = new google.maps.Marker({
                    map: map,
                    position: new google.maps.LatLng(pos.lat, pos.long),
					disableDefaultUI: true,
					icon: baseUrl + 'dist/leadership/images/marker.png'
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

	$("#leadership-location__map").each(function (idx, item) {
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