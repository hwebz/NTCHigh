jQuery(document).ready(function ($) {
    var _SlideshowTransitions = [{ $Duration: 1200 }];

    var options = {
        $AutoPlay: false,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
        $DragOrientation: 3,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $DisplayPieces is greater than 1, or parking position is not 0)
        $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
        $SlideDuration: 600,                                //Specifies default duration (swipe) for slide in milliseconds

        $SlideshowOptions: {                                //[Optional] Options to specify and enable slideshow or not
            $Class: $JssorSlideshowRunner$,                 //[Required] Class to create instance of slideshow
            $Transitions: _SlideshowTransitions,            //[Required] An array of slideshow transitions to play slideshow
            $TransitionsOrder: 1,                           //[Optional] The way to choose transition to play slide, 1 Sequence, 0 Random
            $ShowLink: true                                    //[Optional] Whether to bring slide link on top of the slider when slideshow is running, default value is false
        },

        $ArrowNavigatorOptions: {                       //[Optional] Options to specify and enable arrow navigator or not
            $Class: $JssorArrowNavigator$,              //[Requried] Class to create arrow navigator instance
            $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
            $AutoCenter: 2,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
            $Steps: 4                                       //[Optional] Steps to go for each navigation request, default value is 1
        },

        $ThumbnailNavigatorOptions: {                       //[Optional] Options to specify and enable thumbnail navigator or not
            $Class: $JssorThumbnailNavigator$,              //[Required] Class to create thumbnail navigator instance
            $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always

            $ActionMode: 1,                                 //[Optional] 0 None, 1 act by click, 2 act by mouse hover, 3 both, default value is 1
            $Lanes: 2,                                      //[Optional] Specify lanes to arrange thumbnails, default value is 1
            $SpacingX: 16,                                   //[Optional] Horizontal space between each thumbnail in pixel, default value is 0
            $SpacingY: 16,                                   //[Optional] Vertical space between each thumbnail in pixel, default value is 0
            $DisplayPieces: 2,                             //[Optional] Number of pieces to display, default value is 1
            $ParkingPosition: 1,                          //[Optional] The offset position to park thumbnail
            $Orientation: 2,                                //[Optional] Orientation to arrange thumbnails, 1 horizental, 2 vertical, default value is 1
            $ArrowNavigatorOptions: {
                $Class: $JssorArrowNavigator$,              //[Requried] Class to create arrow navigator instance
                $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                $AutoCenter: 0,                                 //[Optional] Auto center arrows in parent container, 0 No, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                $Steps: 2,                                       //[Optional] Steps to go for each navigation request, default value is 1
                $Scale: true
            }
        }
    };

    var jssor_slider1 = new $JssorSlider$("slider1_container", options);
    //responsive code begin
    //you can remove responsive code if you don't want the slider scales while window resizes
    function ScaleSlider() {
        var parentWidth = jssor_slider1.$Elmt.parentNode.clientWidth;
        if (parentWidth)
            jssor_slider1.$ScaleWidth(Math.max(Math.min(parentWidth, 1170), 200));
        else
            window.setTimeout(ScaleSlider, 30);
    }
    ScaleSlider();

    $(window).bind("load", ScaleSlider);
    $(window).bind("resize", ScaleSlider);
    $(window).bind("orientationchange", ScaleSlider);

    //responsive code end


    $('#btn-next').on('click', function () {
        var element = document.getElementById('arrowright');
        if (element.click)
            element.click();
        else if (document.createEvent) {
            var eventObj = document.createEvent('MouseEvents');
            eventObj.initEvent('click', true, true);
            element.dispatchEvent(eventObj);
        }
    });

    $('#btn-prev').click(function () {
        var element = document.getElementById('arrowleft');
        if (element.click)
            element.click();
        else if (document.createEvent) {
            var eventObj = document.createEvent('MouseEvents');
            eventObj.initEvent('click', true, true);
            element.dispatchEvent(eventObj);
        }
    });
});