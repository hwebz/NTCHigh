(function () {

    function iOS() {
        var iDevices = [
            'iPad Simulator',
            'iPhone Simulator',
            'iPod Simulator',
            'iPad',
            'iPhone',
            'iPod'
        ];
        if (!!navigator.platform) {
            while (iDevices.length) {
                if (navigator.platform === iDevices.pop()) { return true; }
            }
        }
        return false;
    }

    function detectIE() {
        var ua = window.navigator.userAgent;

        var msie = ua.indexOf('MSIE ');
        if (msie > 0) {
            // IE 10 or older => return version number
            return parseInt(ua.substring(msie + 5, ua.indexOf('.', msie)), 10);
        }

        var trident = ua.indexOf('Trident/');
        if (trident > 0) {
            // IE 11 => return version number
            var rv = ua.indexOf('rv:');
            return parseInt(ua.substring(rv + 3, ua.indexOf('.', rv)), 10);
        }

        var edge = ua.indexOf('Edge/');
        if (edge > 0) {
            // Edge (IE 12+) => return version number
            return parseInt(ua.substring(edge + 5, ua.indexOf('.', edge)), 10);
        }

        // other browser
        return false;
    }


	var fixedBackground = $(".hero, .residential-call-to-action");

	if (iOS()) {
		fixedBackground.css({
			'background-attachment': 'initial'
	    });
	}

    if (detectIE()) {
        $('html').css({
            overflow: 'hidden',
            height: '100%'
        });
        $('body').css({
            overflow: 'auto',
            height: '100%'
        });
    }
})();