(function ($) {
    "use strict";

    var $change_service = $('.change-service');

    var SetAgainServiceRaise = function () {
        return $change_service.each(function () {
            if (parseInt($('#Service').val()) === parseInt($(this).data('selector'))) {
                return $(this).addClass('bg-secondary text-danger');
            } else {
                return $(this).removeClass('bg-secondary text-danger');
            }
        });
    };

    $change_service.on('click', function () {
        $("#Service").val($(this).data('selector'));
        return SetAgainServiceRaise();
    });

    $('#ChangeServiceSubmit').on('click', function (e) {
        e.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.ajax({
            type: "POST",
            url: actionUrl,
            data: dataToSend,
            success: function (response) {
                $("div.modal-backdrop").remove();
                $('#modal-placeholder').replaceWith(response);
                var isValid = $('#modal-placeholder').find('[name="IsValid"]').val();

                if (isValid === "False") {
                    $('#modal-placeholder').find('.modal').modal('show')
                }
                else {
                    window.location.href = response.redirectToUrl;
                }
            },
            error: function (error) {
                alert('Error');
                $(this).parents('.modal').html(error);
            }
        });
        return false;
    });
})(jQuery);