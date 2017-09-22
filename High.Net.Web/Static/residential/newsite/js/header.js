(function(){
    
    var ToggleMenu = function (speed) {
        var menuWrapper = $(".residential-header__right-nav");
		var toggleButton = menuWrapper.find(".residential-header__toggle-button");
        var menuItemHasSubMenu = menuWrapper.find(".residential-header__nav >li").has(".residential-header__subnav");
        
        var hide = function (selector, type) {
            switch (type) {
                case 'slide':
                    selector.next().slideUp(speed, function () {
                        $(this).removeAttr("style");
                    });
                    break;
                case 'hide':
                    selector.next().removeAttr("style");
                    break;
            }
        }
        
        var toggle = function (selector) {
            selector.next().slideToggle(speed, function () {
                var $this = $(this);
                if ($this.css("display") == "none") $this.removeAttr("style");
            });
		}

		var fixedHeightSubMenu = function (selector, isFull) {
			var subMenu = selector.next();
			var fixedHeader = $(".residential-header");
			var fixedHeaderHeight = fixedHeader.outerHeight();
			var windowHeight = $(window).height();

		    if (isFull) {
		        if (subMenu.hasClass('fixedheight')) {
		            subMenu.removeAttr('style').removeClass('fixedheight');
		        }
            }
		    if (windowHeight < (subMenu.height() + fixedHeaderHeight)) {
		        subMenu.addClass('fixedheight');

		        // responsive height
		        subMenu.css('height', (windowHeight - fixedHeaderHeight + 5));
		    }
		}
        
		var init = function () {
			if (typeof menuWrapper !== 'undefined') {
				// closing menu when clicking outside or not focus on the window
				fixedHeightSubMenu(toggleButton, true);
			    $(window).bind('blur', function () {
			        if (toggleButton.css("display") != "none") hide(toggleButton, 'hide');
			    }).on('resize orientationchange', $.debounce(50, function() {
			        fixedHeightSubMenu(toggleButton, true);
			    }));
				$(document).bind('click touchstart MSPointerDown', function () {
					if ($(event.target).parents(".residential-header__right-nav").length == 0 && toggleButton.css("display") != "none") hide(toggleButton, 'slide');
			    });

				toggleButton.bind('click touchstart MSPointerDown', function (event) {
                    event.preventDefault(); 
				    fixedHeightSubMenu(toggleButton, false);
					toggle(toggleButton);
			        return false;
				});

				// for submenu
			    menuItemHasSubMenu.each(function() {
					var $this = $(this);
					$this.addClass('has-submenu').append('<div class="toggle-btn"><span></span></div>');

					$this.find('.toggle-btn').on('click',
						function (event) {
							event.preventDefault();
							var $_this = $(this);
						    $_this.prev().slideToggle(function() {
								if ($_this.hasClass('shown')) {
								    $_this.removeClass('shown');
								} else {
								    $_this.addClass('shown');
								}
						    });
			                return false;
			            });
			    });

			}
            
        }
        
        return {
            init: init
        }
    }
    
    var menu = new ToggleMenu('low');
    menu.init();

})();