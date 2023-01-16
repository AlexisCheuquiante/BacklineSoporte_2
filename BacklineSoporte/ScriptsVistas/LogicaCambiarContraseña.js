function UpdateContraseña() {

    if (ValidaGuardar() === false) {
        //alert('no valido');
        return;
    }

    $('#btnCambiarContrasena').addClass('loading');
    $('#btnCambiarContrasena').addClass('disabled');

    var strParams = {
        Password: $('#txtContraseñaNueva').val(),
    };

    $.ajax({
        url: window.urlCambiarClave,
        type: 'POST',
        async: false,
        data: { entity: strParams },
        success: function (data) {
            if (data === 'exito') {
                $('#DivMessajeErrorGeneral').addClass("hidden");
                $('#divExito').removeClass("hidden");
                setTimeout(() => { Salir(); }, 5000);
            }
            //if (data === 'error') {
            //    $('#divErroLogin').removeClass("hidden");
            //}

        },
        error: function (ex) {
            alert('Error al guardar el producto');
        }
    });

}

function Salir() {
    location.href = '/CambiarContraseña/AccionSalir';
}
function ValidaGuardar() {
    var esValido = true;
    var errores = [];

    LimpiaEstilos();

    if ($('#txtContraseñaNueva').val() === '') {
        $('#divtxtContraseña').addClass("error");
        errores.push('Debe indicar una nueva contraseña');
    }

    if ($('#txtContraseñaConfirmacion').val() === '') {
        $('#divtxtContraseñaConfirmacion').addClass("error");
        errores.push('Debe indicar una nueva contraseña');
    }

    if ($('#txtContraseñaNueva').val() != $('#txtContraseñaConfirmacion').val()) {

        $('#divtxtContraseña').addClass("error");
        errores.push('Las contraseñas no coinciden');
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
function LimpiaEstilos() {
    //Limpio el estilo Error antes de validar
    $('#divtxtContraseña').removeClass("error");
}