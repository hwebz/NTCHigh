// Define our root namespace if necessary
var B2B = window.B2B || {};

B2B.setup = {
    init: function() {
        // this.upgradeBrowser();
        this.setimageResponsiveClass();
    },


    upgradeBrowser: function() {
        browserBlast({
            //devMode:true // Remove this for live, dev mode is for testing all browsers
		
        });
    },

    setimageResponsiveClass: function() {
        $(".textblock img").each(function () {
            if ($(this).attr("src").indexOf("/imagevault") > -1) {
                $(this).addClass("img-responsive");
            }
        });
    }
}

$(document).ready(function() {

    B2B.setup.init();
    
});
/*
	By Osvaldas Valutis, www.osvaldas.info
	Available for use under the MIT License
*/

'use strict';
; (function (document, window, index) {
    var inputs = document.querySelectorAll('.inputfile');
    Array.prototype.forEach.call(inputs, function (input) {
        var label = input.nextElementSibling,
			labelVal = label.innerHTML;

        input.addEventListener('change', function (e) {
            var fileName = '';
            if (this.files && this.files.length > 1)
                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
            else
                fileName = e.target.value.split('\\').pop();

            if (fileName) {
                label.querySelector('span').innerHTML = fileName;
                label.querySelector('span').classList.add('has-file');
            }
            else {
                label.innerHTML = labelVal;
                label.querySelector('span').classList.remove('has-file');
            }
        });

        // Firefox bug fix
        input.addEventListener('focus', function () { input.classList.add('has-focus'); });
        input.addEventListener('blur', function () { input.classList.remove('has-focus'); });
    });
}(document, window, 0));

$(document).ready(function () {

    // The select element to be replaced:
    var select = $('select.makeMeFancy');

    select.each(function () {
        var $el = $(this);
        var selectBoxContainer = $('<div>', {
            class: 'tzSelect',
            html: '<div class="selectBox form-control contact"></div>'
        });

        var dropDown = $('<ul>', { class: 'dropDown' });
        var selectBox = selectBoxContainer.find('.selectBox');

        // Looping though the options of the original select element

        $el.find('option').each(function (i) {
            var option = $(this);
            if (option.is(':selected')) {
                selectBox.html(option.text());
            }

            // As of jQuery 1.4.3 we can access HTML5 
            // data attributes with the data() method.

            if (option.data('skip')) {
                return true;
            }

            // Creating a dropdown item according to the
            // data-icon and data-html-text HTML5 attributes:

            var li = $('<li>', { html: option.text() });

            li.click(function () {
                selectBox.addClass('selected-text');
                selectBox.text(option.text());
                dropDown.trigger('hide');

                // When a click occurs, we are also reflecting
                // the change on the original select element:
                $el.val(option.val());

                return false;
            });

            dropDown.append(li);
        });

        selectBoxContainer.append(dropDown.hide());
        $el.hide().after(selectBoxContainer);

        // Binding custom show and hide events on the dropDown:

        dropDown.bind('show', function () {
            $("ul.dropDown").not(dropDown).slideUp().prev().removeClass('expanded');
            if (dropDown.is(':animated')) {
                return false;
            }

            selectBox.addClass('expanded');
            dropDown.slideDown();

        }).bind('hide', function () {
            $("ul.dropDown").not(dropDown).slideUp().prev().removeClass('expanded');
            if (dropDown.is(':animated')) {
                return false;
            }

            selectBox.removeClass('expanded');
            dropDown.slideUp();

        }).bind('toggle', function () {
            $("ul.dropDown").not(dropDown).slideUp().prev().removeClass('expanded');
            if (selectBox.hasClass('expanded')) {
                dropDown.trigger('hide');
            }
            else dropDown.trigger('show');
        });

        selectBox.click(function () {
            dropDown.trigger('toggle');
            return false;
        }); 
    });

    // If we click anywhere on the page, while the
    // dropdown is shown, it is going to be hidden:

    $(document).click(function () {
        $("ul.dropDown").trigger('hide');
    });

    $(function () {

        var $win = $(window); // or $box parent container
        var $box = $(".Form__Element__ValidationError");

        $win.on("click.Bst", function (event) {
            $box.each(function() {
                var _this = $(this);
                if (
                    _this.has(event.target).length == 0 //checks if descendants of $box was clicked
                    &&
                    !_this.is(event.target) //checks if the $box itself was clicked
                    ) {
                        //$log.text("you clicked outside the box");
                        if (!_this.parent().find('.form-control').val()) {
                            _this.removeClass('remove_error');
                        } else {
                            var _textval = _this.parent().find('.form-control').val();
                            if (_this.parent().find('.form-control').attr('type') == 'url') {
                                if (!validateUrl(_textval)) {
                                    _this.removeClass('remove_error');
                                }
                            }
                            if (_this.parent().find('.form-control').hasClass('IsEmail')) {
                                if (!IsEmail(_textval)) {
                                    _this.removeClass('remove_error');
                                }
                            }
                        }
                        if (_this.parent().find('.form-control').is(':focus')) {
                            _this.addClass('remove_error');
                        }
                    } else {
                        //$log.text("you clicked inside the box");
                        _this.addClass('remove_error');
                    }
                });
            });
        });

    $('.Form__Element__ValidationError').click(function () {
        var _this = $(this);
        _this.addClass('remove_error');
        _this.parent().find('.form-control').focus();
    });
});

function validateUrl(url) {
    var urlregex = new RegExp(
          "^(http:\/\/|https:\/\/|ftp:\/\/|www.){1}([0-9A-Za-z]+\.)");
    return urlregex.test(url);
}
function IsEmail(email) {
    var regex = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
    return regex.test(email);
}
