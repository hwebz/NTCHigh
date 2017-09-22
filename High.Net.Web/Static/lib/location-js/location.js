$(document).ready(function () {
    function makeInfoWindowEvent(map, infowindow, marker) {
        return function () {
            infowindow.open(map, marker);
        };
    }
    var $locationUrl = $('#locationData').val();

    function initialize(legend) {
        if ($locationUrl) {
            $.get($locationUrl, function (data) {
                var dataClean = data.replace(/,,/g, ",&nbsp;,");
                var locations = $.csv()(dataClean);
                var coords = new Array();
                var container = new google.maps.LatLngBounds();
                var markers = new Array();
                var infowindows = new Array();
                var header = locations[0];
                locations = $.grep(locations, function (a) {
                    if (legend == "") {
                        return a;
                    }
                    else if (a[2] == legend) {
                        return a;
                    }
                });
                if (legend != "") {
                    locations.splice(0, 0, header);
                }

                for (i = 1; i < locations.length; i++) {
                    var j = i - 1; // 0-based iterator
                    if (locations[i][0]) {
                        coords[j] = new google.maps.LatLng(locations[i][10], locations[i][11]);
                        container.extend(coords[j]);

                        var image = new google.maps.MarkerImage(
                            '/Static/global/location-images/' + locations[i][0] + '.png',
                              new google.maps.Size(20, 34),
                              new google.maps.Point(0, 0),
                              new google.maps.Point(10, 33)
                        );
                        var shadow = new google.maps.MarkerImage(
                            '/Static/global/location-images/' + locations[i][0] + '.png',
                              new google.maps.Size(29, 22),
                              new google.maps.Point(29, 14),
                              new google.maps.Point(0, 20)
                        );
                        markers[j] = new google.maps.Marker({
                            position: coords[j],
                            icon: image,
                            shadow: shadow,
                            title: locations[i][1]
                        });
                        var end = escape(locations[i][3] + ', ' + locations[i][4] + ', ' + locations[i][5] + ' ' + locations[i][6]);
                        contentString = '<div class="content">' +
                            '<strong class="title">' + locations[i][1] + '</strong><br /><br />' +
                            '<span class="address">' + locations[i][3] + '</span><br />' +
                            '<span class="city-state-zip">' + locations[i][4] + ', ' + locations[i][5] + ' ' + locations[i][6] + '</span><br />' +
                            '<span class="phone">' + locations[i][8] + '</span><br />' +
                            '<a href="' + locations[i][7] + '" class="url" target="_blank">' + locations[i][7] + '</a><br /><br />' +
                            '<a href="http://maps.google.com/maps?&daddr=' + end + '" class="directions" target="_blank">Get Directions &raquo;</a><br />' +
                            '<p class="description">' + locations[i][9] + '</p>'
                        '</div>';
                        infowindows[j] = new google.maps.InfoWindow({
                            content: contentString
                        });
                    }
                }
                var options = {
                    zoom: 5,
                    center: container.getCenter(),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var map = new google.maps.Map(document.getElementById('map'), options);
                if (markers) {
                    for (i in markers) {
                        markers[i].setMap(map);
                        google.maps.event.addListener(markers[i], 'click', makeInfoWindowEvent(map, infowindows[i], markers[i]));
                    }
                }
            });
        }
    }
    
    google.maps.event.addDomListener(window, 'load', initialize(""));

    $('#filter-legend').change(function () {
        var legend = this.value;
        initialize(legend);
    });
});