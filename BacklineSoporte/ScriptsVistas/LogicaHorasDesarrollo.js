var _idHora = 0;

function GuardaHoras() {

    if (ValidaGuardar() == false)

        return;

    $('#btnGuardaHora').addClass('loading');
    $('#btnGuardaHora').addClass('disabled');

    var strParams = {
        
        Id: $('#idHoraSeleccionada').val(),
        Fecha_Inicio: $('#txtFechaInicio').val(),
        Observacion: $('#txtObservacion').val(),
    };
    $.ajax({
        url: window.urlInsertarHoras,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (data) {
            if (data === 'exito') {
                $('#DivMessajeErrorGeneral').addClass("hidden");
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
function LimpiaEstilosGuardar() {
    //Limpio el estilo Error antes de validar
    
    $('#divtxtFechaInicio').removeClass("error");
    
}
function ValidaGuardar() {
    var esValido = true;
    var errores = [];

    LimpiaEstilosGuardar();

    if ($('#txtFechaInicio').val() === '') {
        $('#divtxtFechaInicio').addClass("error");
        errores.push('Debe indicar la fecha y hora de inicio');
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
function PreparaCerrarHora(id) {
    $('#idHoraSeleccionada').val(id);
}
function CerrarHora() {

    var strParams = {
        Id: $('#idHoraSeleccionada').val(),
    };

    $.ajax({
        url: window.urlCerrarHora,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    $('#divConsultaCierra').addClass("hidden");
                    $('#divExitoCierra').removeClass("hidden");
                    setTimeout(() => { location.reload(); }, 1000);
                }
            }
        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function PreparaElimina(id) {
    $('#idHoraSeleccionada').val(id);
}
function Eliminar() {
    var id = $('#idHoraSeleccionada').val();

    $.ajax({
        url: window.urlEliminar,
        type: 'POST',
        data: { id: id },
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    $('#divConsultaElimina').addClass("hidden");
                    $('#divExitoElimina').removeClass("hidden");
                    setTimeout(() => { location.reload(); }, 1000);
                }
            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function ObtenerObservacion(id) {
    $('#idHoraSeleccionada').val(id);
    var idHora = $('#idHoraSeleccionada').val();

    $.ajax({
        url: window.urlObtenerObservacion,
        type: 'POST',
        data: { idHora: idHora },
        success: function (data) {
            $('#txtObservacionCompleta').val(data.Observacion)
        },
        error: function () {
            alert('Error al cargar los datos de la ficha');
        }
    });
    _idHora = id;
}

function EditarObservacion() {

    $('#btnGuardaObservacion').addClass('loading');
    $('#btnGuardaObservacion').addClass('disabled');

    var strParams = {
        Id: _idHora,
        Observacion: $('#txtObservacionCompleta').val(),
    };

    $.ajax({
        url: window.urlEditarObservacion,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    $('#divExitoCompleta').removeClass("hidden");
                    setTimeout(() => { location.reload(); }, 1000);
                }
            }
        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
