
$(document).ready(function () {
    $('a.btn-delete').click(function () {
        var href = $(this).attr('href');
        var cliente = $(this).data('message');

        bootbox.dialog({
            message: `<div class="text-center margin-top-20px"><span class="text-danger far fa-trash-alt" style="font-size: 60px"></span><div style="font-size: 18px">Deseja remover o cliente <b>${cliente}</b>?</div></div>`,
            buttons: {
                cancel: {
                    label: "Cancelar",
                    className: 'btn btn-danger btn-responsive',
                    callback: function () {
                    }
                },
                confirm: {
                    label: "Sim",
                    className: 'btn btn-primary btn-responsive',
                    callback: function () {
                        $('#carregando').show();

                        $.ajax({
                            url: href,
                            typr: "GET",
                            contentType: "application/json;charset=UTF-8",
                            success: function (response) {
                                toastr.options.timeOut = 500;
                                toastr.options.onHidden = function () { window.location.href = response.url; }
                                toastr.success('Registro excluido com sucesso!');
                            },
                            error: err => {
                                toastr.error('Não foi possível excluir o registro.');
                                $('#carregando').hide();
                            }
                        });
                    }
                }
            }
        });
        return false;
    });
});
