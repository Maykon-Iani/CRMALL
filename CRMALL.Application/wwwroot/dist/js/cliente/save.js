
$(document).ready(function () {

    bootstrapTabControl();

    $('#frm-cliente').submit(function (event) {
        event.preventDefault();
       
        var form = $("#frm-cliente")

        if ($('#Nome').val() === "") {

            if (form[0].checkValidity() === false) {
                event.preventDefault()
                event.stopPropagation()
                form.addClass('was-validated');
            }
        } else {    
            $('#carregando').show();
            $.ajax({
                url: "/Cliente/AddOrEdit",
                type: "POST",
                data: form.serialize(),
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: response => {
                    toastr.options.timeOut = 500;
                    toastr.options.onHidden = function () { window.location.href = response.url; }                   
                    toastr.success('Registro salvo com sucesso!');                    
                },
                error: err => {
                    toastr.error('Não foi possível salvar o registro.');
                    $('#carregando').hide();
                }
            });
        }
    });
});


function bootstrapTabControl() {
    var i, items = $('.cliente-tab'), pane = $('.tab-pane');
    // next
    $('.nexttab').on('click', function () {
        for (i = 0; i < items.length; i++) {
            if ($(items[i]).hasClass('active') == true) {
                break;
            }
        }
        if (i < items.length - 1) {
            // for tab
            $(items[i]).removeClass('active');
            $(items[i + 1]).addClass('active');
            // for pane
            $(pane[i]).removeClass('show active');
            $(pane[i + 1]).addClass('show active');
        }

    });
    // Prev
    $('.prevtab').on('click', function () {
        for (i = 0; i < items.length; i++) {
            if ($(items[i]).hasClass('active') == true) {
                break;
            }
        }
        if (i != 0) {
            // for tab
            $(items[i]).removeClass('active');
            $(items[i - 1]).addClass('active');
            // for pane
            $(pane[i]).removeClass('show active');
            $(pane[i - 1]).addClass('show active');
        }
    });
}