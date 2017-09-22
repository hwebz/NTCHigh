(function ($) {
    $(function () {
        var jcarousel = $('.ms-jcarousel');

        jcarousel
            .on('jcarousel:reload jcarousel:create', function () {
                var carousel = $(this),
                    width = carousel.innerWidth();

                //if (width >= 600) {
                //    width = width / 3;
                //} else if (width >= 350) {
                //    width = width / 2;
                //}

                carousel.jcarousel('items').css('width', Math.ceil(width) + 'px');
            })
        .jcarousel({
			wrap: 'circular'
		}).jcarouselAutoscroll({
			interval: 3000,
			target: '+=1',
			autostart: true
		});
        $('.jcarousel-control-prev')
            .jcarouselControl({
                target: '-=1'
            });

        $('.jcarousel-control-next')
            .jcarouselControl({
                target: '+=1'
            });


        var jcarousel_bs = $('.bs-jcarousel');

        jcarousel_bs
            .on('jcarousel:reload jcarousel:create', function () {
                var carousel = $(this),
                    width = carousel.innerWidth();

                if (width >= 600) {
                    width = width / 3;
                } else if (width >= 350) {
                    width = width / 2;
                }

                carousel.jcarousel('items').css('width', Math.ceil(width) + 'px');
            })
        .jcarousel({
            wrap: 'circular'
        });


        $('.jcarousel-control-left')
            .jcarouselControl({
                target: '-=1'
            });

        $('.jcarousel-control-right')
            .jcarouselControl({
                target: '+=1'
            });

        var $imgGalleryCarousel = $(".img-gallery-slider");

        if ($imgGalleryCarousel.length) {
            console.log("inside img gallery");
            imgGallerySetup();
        }

        function imgGallerySetup() {
            console.log("in img gallery init");

            $('.img-gallery-slider').each(function (i) {
                console.log("inside first loop: " + i);
                $(this).find(".bxslider-img-gallery").bxSlider({
                    mode: 'horizontal',
                    useCSS: false,
                    responsive: true,
                    pagerCustom: "." + $(this).data("pager"),
                });
                $(this).find(".gallery-pager." + $(this).data("pager")).bxSlider({
                    mode: 'vertical',
                    pager: false,
                    minSlides: 4,
                    maxSlides: 4,
                    slideMargin: 10
                });
            })
        }

    });
})(jQuery);
