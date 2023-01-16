function ValidarUsuario() {

    if ($('#txtUsuario').val() == '' || $('#txtPassword').val() == '') {
        $('#divErroLogin').removeClass("hidden");
        return;
    }


    $('#btnLogin').addClass("loading");
    $('#btnLogin').addClass("disabled");

    var strParams = {
        UsuarioStr: $('#txtUsuario').val(),
        Password: $('#txtPassword').val()
    };

    $.ajax({
        url: window.urlValidaUsuario,
        type: 'POST',
        data: { entity: strParams },
        success: function (data) {
            if (data === 'exito') {
                $('#divErroLogin').addClass("hidden");
                window.location.href = "/homeCliente/index";
            }
            if (data === 'error') {
                $('#divErroLogin').removeClass("hidden");
                $('#btnLogin').removeClass("loading");
                $('#btnLogin').removeClass("disabled");
            }

        },
        error: function () {
            alert('Error al cargar los Tipos');
        }
    });

}