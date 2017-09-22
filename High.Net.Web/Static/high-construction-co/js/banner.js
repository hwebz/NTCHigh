(function ($) {
    $(function () {
        var jcarousel = $('.jcarousel');
        var images = 5;

        jcarousel
            .on('jcarousel:reload jcarousel:create', function () {
                var carousel = $(this),
                    width = carousel.innerWidth();

                if (width >= 920) {
                    width = (width / 7) - 10;
                } else if (width >= 580) {
                    width = (width / 5) - 9;
                    images = 3;
                } else if (width >= 320) {
                    width = (width / 3) - 8;
                    images = 2;
                } else {
                    width = width / 2 - 7;
                    images = 1;
                }

                carousel.jcarousel('items').css('width', Math.ceil(width) + 'px');
            })
            .jcarousel({
                wrap: null
            });

        $('.jcarousel-control-prev')
            .jcarouselControl({
                target: '-=1'
            });

        $('.jcarousel-control-next')
            .jcarouselControl({
                target: '+=1'
            });

        if ($('.jcarousel ul').children('li').length < images) {
            $('.jcarousel-control-prev, .jcarousel-control-next').css('display', 'none', 'important');
        }
    });

    var w = $('.container').width() + 'px';
    $('.jcarousel-wrapper').width(w);

    $('.jcarousel img').click(function () {    
        $('.banner img').attr('src', '');
        $('.banner img').attr('src', $(this).parent().data("url"));       
    });
})(jQuery);
