
function GuardarDesarrollo() {


    $('#btnGuardaDesarrollo').addClass('disabled');
    $('#btnGuardaDesarrollo').addClass('loading');

    var strParams = {
        Id: $('#hidDesarrollo').val(),
        Fecha_Inicio: $('#txtFechaInicio').val(),
        Fecha_Termino: $('#txtFechaTermino').val(),
        Modulo: $('#txtModulo').val(),
        Requerimiento: $('#txtRequerimiento').val(),
        Detalle_Requerimiento: $('#txtDetalle').val()
    }
    $.ajax({
        url: window.urlGuardarDesarrollo,
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









