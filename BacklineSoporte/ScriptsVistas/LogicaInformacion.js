$(function () {
    $('.ui.selection.dropdown').dropdown();
    $('.ui.menu .ui.dropdown').dropdown({
        on: 'hover'
    });


    ObtenerFecha();

});
function GuardarInformacion() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaInformacion').addClass('disabled');
    $('#btnGuardaInformacion').addClass('loading');

    var strParams = {
        Id: $('#hidInformacion').val(),
        Titulo: $('#txtTitulo').val(),
        Fecha: $('#txtFecha').val(),
        Detalle_informacion: $('#txtDetalle').val(),
        Visible: $('#idRepetición').val()
    }
    $.ajax({
        url: window.urlGuardarInformacion,
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

function ObtenerFecha() {
    $.ajax({
        url: window.urlObtenerFecha,
        type: 'POST',
        dataType: "json",
        success: function (resultado) {
            $('#txtFecha').val(resultado);
        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });
}

function ValidaGuardar() {
    errores = [];

    $('#divTxtTitulo').removeClass('error');
    $('#divTxtDetalle').removeClass('error');
    $('#divcmbRepetición').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass("hidden");

    if ($('#txtTitulo').val() === '') {
        $('#divTxtTitulo').addClass('error');
        errores.push('Debe ingresar el titulo de la información')
    }


    if ($('#txtDetalle').val() === '') {
        $('#divTxtDetalle').addClass('error');
        errores.push('Debe ingresar el detalle de la información');
    }

    if ($('#idRepetición').val() === '') {
        $('#divcmbRepetición').addClass('error');
        errores.push('Debe seleccionar si la información sera visible');
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

function PreparaEliminaInformacion(id) {
    $('#hidInformacion').val(id);
}

function EliminarInformacion() {
    var idInformacion = $('#hidInformacion').val();

    $.ajax({
        url: window.urlEliminarInformacion,
        type: 'POST',
        data: { idInformacion: idInformacion },
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

function PrepararEditarInformacion(id) {
    $('#hidInformacion').val(id);
}

function EditarInformacion() {

    var idInformacion = $('#hidInformacion').val();

    $.ajax({
        url: window.urlEditarInformacion,
        type: 'POST',
        data: { idInformacion: idInformacion },
        success: function (informacion) {
            $('#txtTitulo').val(informacion.Titulo);
            $('#txtFecha').val(informacion.FechaStr);
            $('#txtDetalle').val(informacion.Detalle_Informacion);
            $("#cmbRepetición").dropdown('set selected', informacion.Visible);
        },
        error: function () {
            alert('Error al cargar los datos de la información');
        }
    });
}

