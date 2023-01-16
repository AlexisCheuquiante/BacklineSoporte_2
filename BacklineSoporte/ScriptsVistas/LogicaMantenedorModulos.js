function GuardaModulo() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaModulo').addClass('disabled');
    $('#btnGuardaModulo').addClass('loading');

    var strParams = {
        Id: $('#hidModulo').val(),
        ModuloStr: $('#txtModulo').val(),
    }
    $.ajax({
        url: window.urlGuardaModulo,
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

    $('#divTxtModulo').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass("hidden");

    if ($('#txtModulo').val() === '') {
        $('#divTxtModulo').addClass('error');
        errores.push('Debe ingresar la descripción del modulo')
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
function PrepararEditarModulo(id) {
    $('#hidModulo').val(id);
}
function EditarModulo() {

    var idModulo = $('#hidModulo').val();

    $.ajax({
        url: window.urlEditarModulo,
        type: 'POST',
        data: { idModulo: idModulo },
        success: function (modulo) {

            $('#txtModulo').val(modulo.ModuloStr);

        },

        error: function () {
            alert('Error al cargar la descrìpción del modulo');
        }
    });


}
function PreparaEliminaModulo(id) {
    $('#hidModulo').val(id);
}

function EliminarModulo() {
    var idModulo = $('#hidModulo').val();

    $.ajax({
        url: window.urlEliminarModulo,
        type: 'POST',
        data: { idModulo: idModulo },
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