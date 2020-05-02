(function ($) {
    "use strict";

    $('#ExitSubmit').on('click', function (e) {
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
                $('#modelExitPopup').replaceWith(response);
                var isValid = $('#modelExitPopup').find('[name="IsValid"]').val();

                if (isValid === "False") {
                    $('#modelExitPopup').find('.modal').modal('show')
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