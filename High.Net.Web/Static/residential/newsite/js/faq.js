(function () {

	var FAQ = function () {
		var faqWrapper = $('.residential-faq');
		var faqItems = faqWrapper.find('.residential-faq__item');
		var faqTitle = faqItems.find('>h3');

        var init = function () {
			// check ele if exist
			if (typeof faqWrapper != 'undefined' && typeof faqItems !== 'undefined') {
                // init event for all items
			    faqTitle.on('click',
			        function() {
						var $this = $(this);
						var answer = $this.next();
			            var questions = faqTitle.parent();
						if (!$this.parent().hasClass('shown')) {
						    questions.removeClass('shown').find('>div').slideUp();
						    answer.slideDown(function() {
						        var $_this = $(this);
						        var parent = $_this.parent();
						        parent.addClass('shown');
						    });
						} else {
							answer.slideUp(function () {
							    var $_this = $(this);
							    var parent = $_this.parent();
							    parent.removeClass('shown');
							});
						}
			        });
			}

        }

        return {
            init: init
        }
    }

	var faq = new FAQ();
    faq.init();

})();