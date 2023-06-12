var _idUltimoContacto = 0;

$(document).ready(function () {

    ObtenerEstadoUltimoContacto();
    ObtenerMotivoContacto();

});

function ObtenerEstadoUltimoContacto() {

    $.ajax({
        url: window.urlObtenerEstadoUltimoContacto,
        type: 'POST',
        success: function (data) {
            $('#cmbEstado').dropdown('clear');
            $('#cmbEstado').empty();
            $('#cmbEstado').append('<option value="-1">[Seleccione estado]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbEstado').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las entidades existentes');
        }
    });

}
function ObtenerMotivoContacto() {

    $.ajax({
        url: window.urlObtenerMotivoContacto,
        type: 'POST',
        success: function (data) {
            $('#cmbMotivo').dropdown('clear');
            $('#cmbMotivo').empty();
            $('#cmbMotivo').append('<option value="-1">[Seleccione motivo]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Motivo_Contacto + '</option>';
                    $('#cmbMotivo').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las entidades existentes');
        }
    });

}
function GuardaUltimoContacto() {

    if (ValidaGuardar() == false)

        return;

    $('#btnGuardaContacto').addClass('loading');
    $('#btnGuardaContacto').addClass('disabled');

    var strParams = {
        Id_Ultimo_Contacto: _idUltimoContacto,
        FechaContacto: $('#txtFechaContacto').val(),
        Motivo_Contacto_Id: $('#cmbMotivo').val(),
        Estado_Contacto: $('#cmbEstado').val(),
        Detalle_Contacto: $('#txtDetalleContacto').val(),
        Persona_Contactada: $('#txtPersona').val(),
        Correo_Contacto: $('#txtCorreo').val(),
    };

    $.ajax({
        url: window.urlGuardarUltimoContacto,
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
    $('#divTxtPersona').removeClass("error");
    $('#divcmbMotivo').removeClass("error");
    $('#divcmbEstado').removeClass("error");
    
}
function ValidaGuardar() {
    var esValido = true;
    var errores = [];

    LimpiaEstilosGuardar();

    if ($('#txtPersona').val() === '') {
        $('#divTxtPersona').addClass("error");
        errores.push('Debe indicar la persona a quien contacto');
    }

    if ($('#cmbMotivo').val() === '-1') {
        $('#divcmbMotivo').addClass('error');
        errores.push('Debe indicar el motivo del contacto')
    }
    if ($('#cmbEstado').val() === '-1') {
        $('#divcmbEstado').addClass('error');
        errores.push('Debe indicar el estado del contacto')
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
function PrepararObtenerUltimoContacto(id) {
    $('#idContacto').val(id);
}
function ObtenerUltimoContacto() {

    var id = $('#idContacto').val();

    $.ajax({
        url: window.urlObtenerUltimoContacto,
        type: 'POST',
        data: { id: id },
        success: function (data) {
                $('#txtFechaContacto').val(data.Fecha_Contacto_Mostrar),
                $("#cmbMotivo").dropdown('set selected', data.Motivo_Contacto_Id),
                $("#cmbEstado").dropdown('set selected', data.Estado_Contacto),
                $('#txtDetalleContacto').val(data.Detalle_Contacto),
                $('#txtPersona').val(data.Persona_Contactada),
                $('#txtCorreo').val(data.Correo_Contacto)
        },

        error: function () {
            alert('Error al cargar los datos de la ficha');
        }
    });
    _idUltimoContacto = id;
}