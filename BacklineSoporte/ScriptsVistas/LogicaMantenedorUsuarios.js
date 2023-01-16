function GuardarUsuario() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaUsuario').addClass('disabled');
    $('#btnGuardaUsuario').addClass('loading');

    var strParams = {
        Id: $('#hidUsuario').val(),
        Nombre: $('#txtNombre').val(),
        UserName: $('#txtUserName').val(),
        password: $('#txtPassword').val()
    }
    $.ajax({
        url: window.urlGuardarUsuario,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                $('#divExito').removeClass("hidden");

                setTimeout(() => { location.reload(); }, 1000);
            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar el comentario. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}

function ValidaGuardar() {
    errores = [];

    $('#divTxtNombre').removeClass('error');
    $('#divTxtUserName').removeClass('error');
    $('#divTxtPassword').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass('hidden');


    
    if ($('#txtNombre').val() === '') {
        $('#divTxtNombre').addClass('error');
        errores.push('Debe ingresar el nombre');
    }
    if ($('#txtUserName').val() === '') {
        $('#divTxtUserName').addClass('error');
        errores.push('Debe ingresar el nombre de usuario');
    }

    if ($('#txtPassword').val() === '') {
        $('#divTxtPassword').addClass('error');
        errores.push('Debe ingresar una contraseña');
    }
    

    if (errores.length > 0) {
        var mensaje = '';
        $('#DivMessajeErrorGeneral').removeClass("hidden");

        for (i = 0; i < errores.length; i++) {
            mensaje += '<li>' + errores[i] + '</li>';
        }

        mensaje += '</ul>';
        $('#listMessajeError').empty();

        $('#listMessajeError').prepend(mensaje);

        // showMessage('#divMensajeNuevoCamion', 'danger', mensaje);
        return false;
    }
    else {
        return true;
    }
}






function PreparaEliminaUsuario(id) {
    $('#hidUsuario').val(id);
}

function EliminarUsuario() {
    var idUsuario = $('#hidUsuario').val();

    $.ajax({
        url: window.urlEliminarUsuario,
        type: 'POST',
        data: { idUsuario: idUsuario },
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    setTimeout(() => { location.reload(); }, 1000)
                }


            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}

function PrepararEditarUsuario(id) {
    $('#hidUsuario').val(id);
}

function EditarUsuario() {

    var idUsuario = $('#hidUsuario').val();

    $.ajax({
        url: window.urlEditarUsuario,
        type: 'POST',
        data: { idUsuario: idUsuario },
        success: function (usuario) {

            $('#txtNombre').val(usuario.Nombre);
            $('#txtUserName').val(usuario.UserName);
            $('#txtPassword').val(usuario.password);




        },

        error: function () {
            alert('Error al cargar los datos del usuario');
        }
    });


}