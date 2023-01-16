$(document).ready(function () {

    ObtenerRoles();

});


function GuardarUsuario() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaUsuario').addClass('disabled');
    $('#btnGuardaUsuario').addClass('loading');

    var strParams = {
        Id: $('#hidUsuario').val(),
        NombreCompleto: $('#txtNombre').val(),
        UsuarioStr: $('#txtUsuario').val(),
        Password: $('#txtPassword').val(),
        Rol_Id: $('#cmbRol').val(),
    }
    $.ajax({
        url: window.urlGuardarUsuario,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                $('#divExito').removeClass("hidden");

                setTimeout(() => { location.reload(); }, 2000);
            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar el comentario. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function ObtenerRoles() {

    $.ajax({
        url: window.urlObtenerRoles,
        type: 'POST',
        success: function (data) {
            $('#cmbRol').dropdown('clear');
            $('#cmbRol').empty();
            $('#cmbRol').append('<option value="-1">[Seleccione un rol]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbRol').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los roles existentes');
        }
    });

}
function ValidaGuardar() {

    errores = [];

    $('#divTxtNombre').removeClass('error');
    $('#divTxtUsuario').removeClass('error');
    $('#divTxtPassword').removeClass('error');
    $('#divcmbRol').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass("hidden");

    if ($('#txtNombre').val() === '') {
        $('#divTxtNombre').addClass('error');
        errores.push('Debe ingresar el nombre')
    }


    if ($('#txtUsuario').val() === '') {
        $('#divTxtUsuario').addClass('error');
        errores.push('Debe ingresar el nombre de usuario');
    }

    if ($('#txtPassword').val() === '') {
        $('#divTxtPassword').addClass('error');
        errores.push('Debe ingresar la contraseña');
    }
    if ($('#cmbRol').val() === '-1') {
        $('#divcmbRol').addClass('error');
        errores.push('Debe indicar el rol del usuario')
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
                    location.reload();
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

    var idUsuario= $('#hidUsuario').val();

    $.ajax({
        url: window.urlEditarUsuario,
        type: 'POST',
        data: { idUsuario: idUsuario },
        success: function (usuario) {

            $('#txtNombre').val(usuario.NombreCompleto);
            $('#txtUsuario').val(usuario.UsuarioStr);
            $('#txtPassword').val(usuario.Password);
            



        },

        error: function () {
            alert('Error al cargar los datos de la información');
        }
    });


}