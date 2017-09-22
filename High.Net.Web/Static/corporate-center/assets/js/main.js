// Define our root namespace if necessary
var LLC = window.LLC || {};


LLC.setup = {

	init:function(){
		//this.initMap();
		this.upgradeBrowser();
	},

	initMap: function() {
  		var myLatLng = {lat: -25.363, lng: 131.044};
  		var map = new google.maps.Map(document.getElementById('map'), {
	    zoom: 4,
	    center: myLatLng
	  });

	  var marker = new google.maps.Marker({
	    position: myLatLng,
	    map: map,
	    title: 'Hello World!'
	  });
	},

	upgradeBrowser: function(){
		browserBlast({
			//devMode:true // Remove this for live, dev mode is for testing all browsers
		});
	}
}

$(document).ready(function() {
	LLC.setup.init();
	function initMap() {
  		var myLatLng = {lat: -25.363, lng: 131.044};
  		var map = new google.maps.Map(document.getElementById('map'), {
	    zoom: 4,
	    center: myLatLng
	  });

	  var marker = new google.maps.Marker({
	    position: myLatLng,
	    map: map,
	    title: 'Hello World!'
	  });
	}
});
