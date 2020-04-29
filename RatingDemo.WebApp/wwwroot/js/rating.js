(function ($) {
    "use strict";

    var $star_rating = $('.rating-image img.img-fluid');

    var SetRatingStar = function () {
        SetEmojiFace(parseInt($('#Scored').val()));

        return $star_rating.each(function () {
            if ($('#Scored').val() >= parseInt($(this).data('rating'))) {
                return $(this).addClass('fa-star-rating');
            } else {
                return $(this).removeClass('fa-star-rating');
            }
        });
    };

    var SetEmojiFace = function (rating) {
        var message = SetEmojiMessage(rating);
        $('.emoji h5').removeClass('d-none').text(message);

        var $emoji_rating = $('.emoji img.img-fluid');

        return $emoji_rating.each(function () {
            if (rating === parseInt($(this).data('rating'))) {
                return $(this).removeClass('d-none');
            } else {
                return $(this).addClass('d-none');
            }
        });
    }

    var SetEmojiMessage = function (rating) {
        switch (rating) {
            case 1: return "Rất không sạch sẽ";
            case 2: return "Cũng tạm chấp nhận";
            case 3: return "Chấp nhận được";
            case 4: return "Khá chấp nhận được";
            case 5: return "Rất sạch sẽ";
            default: return "";
        };
    };

    $star_rating.on('click', function () {
        $star_rating.siblings('#Scored').val($(this).data('rating'));
        return SetRatingStar();
    });
})(jQuery);