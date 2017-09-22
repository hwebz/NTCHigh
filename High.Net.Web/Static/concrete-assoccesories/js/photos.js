$(function () {
    var jcarousel = $('.jcarousel');

    $('.jcarousel li').each(function (index) {
        $(this).children('.img-no').text("IMAGE 0" + ++index);
    });

    jcarousel
        .on('jcarousel:reload jcarousel:create wi', function () {
            var carousel = $(this),
                width = carousel.innerWidth();

            if (width > 800) {
                width = width / 4;
            } else if (width > 630) {
                width = width / 3;
            } else if (width > 320) {
                width = width / 2;
            } else {
                width = width / 1;
            }

            $('.c').width((width - 10) + 'px');
            carousel.jcarousel('items').css('width', Math.ceil(width) + 'px');
        })
        .jcarousel({
            wrap: 'circular'
        });

    $('.jcarousel-control-prev')
        .jcarouselControl({
            target: '-=1'
        });

    $('.jcarousel-control-next')
        .jcarouselControl({
            target: '+=1'
        });

    var w = $('.container').width() + 'px';
    $('.jcarousel-wrapper').width(w);

});


