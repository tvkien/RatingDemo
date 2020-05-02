(function ($) {
    "use strict";

    var $service_rating = $('.services');

    var SetServiceRaise = function () {
        return $service_rating.each(function () {
            if (parseInt($('#Service').val()) === parseInt($(this).data('selector'))) {
                return $(this).addClass('bg-white text-danger');
            } else {
                return $(this).removeClass('bg-white text-danger');
            }
        });
    };

    $service_rating.on('click', function () {
        $("#Service").val($(this).data('selector'));
        return SetServiceRaise();
    });
})(jQuery);