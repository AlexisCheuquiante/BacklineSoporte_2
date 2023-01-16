function GuardaTipoArchivo() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaTipoArchivo').addClass('disabled');
    $('#btnGuardaTipoArchivo').addClass('loading');

    var strParams = {
        Id: $('#hidTipoArchivo').val(),
        Descripcion: $('#txtTipoArchivo').val(),
    }
    $.ajax({
        url: window.urlGuardaTipoArchivo,
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
function ValidaGuardar() {

    errores = [];

    $('#divTxtTipoArchivo').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass("hidden");

    if ($('#txtTipoArchivo').val() === '') {
        $('#divTxtTipoArchivo').addClass('error');
        errores.push('Debe ingresar la descripción del tipo del tipo de archivo')
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
function PrepararEditarTipoArchivo(id) {
    $('#hidTipoArchivo').val(id);
}
function EditarTipoArchivo() {

    var idTipoArchivo = $('#hidTipoArchivo').val();

    $.ajax({
        url: window.urlEditarTipoArchivo,
        type: 'POST',
        data: { idTipoArchivo: idTipoArchivo },
        success: function (tipoarchivo) {

            $('#txtTipoArchivo').val(tipoarchivo.Descripcion);

        },

        error: function () {
            alert('Error al cargar la descrìpción del archivo');
        }
    });


}
function PreparaEliminaTipoArchivo(id) {
    $('#hidTipoArchivo').val(id);
}

function EliminarTipoArchivo() {
    var idTipoArchivo = $('#hidTipoArchivo').val();

    $.ajax({
        url: window.urlEliminarTipoArchivo,
        type: 'POST',
        data: { idTipoArchivo: idTipoArchivo },
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    location.reload();
                }


            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al eliminar el modulo. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}