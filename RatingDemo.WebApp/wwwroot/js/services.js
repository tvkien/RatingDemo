(function ($) {
    "use strict";

    var $service_rating = $('.services .service-select');

    var SetServiceRaise = function () {
        return $service_rating.each(function () {
            if (parseInt($('#Service').val()) === parseInt($(this).data('selector'))) {
                $(this).find("span").addClass('text-danger');
                return $(this).addClass('bg-white');
            } else {
                $(this).find("span").removeClass('text-danger');
                return $(this).removeClass('bg-white');
            }
        });
    };

    $service_rating.on('click', function () {
        $("#Service").val($(this).data('selector'));
        return SetServiceRaise();
    });
})(jQuery);