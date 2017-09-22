(function(){
    
	var ToggleMenu = function () {
		var leadershipHeader = $(".leadership-header");
		var menuWrapper = leadershipHeader.find(".leadership-header__right-nav-wrapper");
	    var toggleBtn = leadershipHeader.find(".leadership-header__toggle-button");
		var menuItemHasSubMenu = menuWrapper.find(".leadership-header__nav >li").has(".leadership-header__subnav");

		var scrollDown = function() {
			var hero = $(".leadership-header-banner");
			hero = hero.length > 0 ? hero : false;

			if (hero) {
			    heroAttr = {
			        top: hero.offset().top,
			        height: hero.outerHeight()
				};

				$(".leadership-header-banner__cursor").click(function (event) {
				    event.preventDefault();
					$('html, body').animate({ scrollTop: heroAttr.top + heroAttr.height - leadershipHeader.height() }, 280, 'linear');
					return false;
			    });
			}
		}

		var animatedMenu = function () {
			$(window).scroll($.debounce(5, function () {
			    if ($(window).scrollTop() > 350) {
			        leadershipHeader.addClass('animated');
			    } else {
			        leadershipHeader.removeClass('animated');
			    }
			}));
		}

		

		var resetAllStyles = function() {
		    $(window).on('resize orientationchange',
		        $.debounce(5,
		            function() {
						if ($(window).width() >= 1200) {
							menuItemHasSubMenu.find(".leadership-header__subnav").removeAttr('style');
						}
		            }));
		}

		var showHideMenu = function (selector, isShown) {
		    var nav = selector.next().next().next();
	        if (isShown) {
	            selector.addClass('open');
	            nav.css('right', 0);
	            nav.prev().css('right', 0);
	            $('.nav-mask').fadeIn('fast');
	            $('html, body').css('overflow', 'hidden');
	        } else {
	            selector.removeClass('open');
	            nav.removeAttr('style');
	            nav.prev().removeAttr('style');
	            $('.nav-mask').fadeOut('fast');
	            $('html, body').removeAttr('style');
	        }
	    }

		var toggle = function (selector) {
		    var nav = selector.next().next().next();
			if (parseInt(nav.css('right'), 10) < 0) {
				showHideMenu(selector, true);
			} else {
				showHideMenu(selector, false);
			}
		}
        
		var init = function () {
			if (typeof leadershipHeader !== 'undefined' && leadershipHeader.length > 0) {
				// Scroll to animate menu
				animatedMenu();
			    resetAllStyles();

			    $(window).bind('blur', function () {
					if (toggleBtn.hasClass('open')) toggle(toggleBtn);
			    });
				$(document).bind('click', function () {
					if ($(event.target).parents(".leadership-header__nav").length == 0 && toggleBtn.hasClass('open')) toggle(toggleBtn);
				});

				toggleBtn.bind('click', function (e) {
				    e.stopPropagation();
				    toggle(toggleBtn);
				});

			    // for submenu
			    menuItemHasSubMenu.each(function () {
			        var $this = $(this);
			        $this.addClass('has-submenu').append('<div class="toggle-btn"><span></span><span></span></div>');

			        $this.find('.toggle-btn').on('click',
			            function (event) {
			                event.preventDefault();
			                var $_this = $(this);
			                $_this.prev().slideToggle(function () {
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

			// Init scroll down for btn
			scrollDown();
		}
        
        return {
            init: init
        }
    }
    
    var menu = new ToggleMenu();
    menu.init();

})();