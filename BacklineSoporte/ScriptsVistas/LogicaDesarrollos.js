
$(document).ready(function () {

    ObtenerEstados();
    ObtenerUsuarios();

});



function ObtenerEstados() {

    $.ajax({
        url: window.urlObtenerEstados,
        type: 'POST',
        success: function (data) {
            $('#cmbEstado').dropdown('clear');
            $('#cmbEstado').empty();
            $('#cmbEstado').append('<option value="-1">[Seleccione estado del desarrollo]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.EstadoStr + '</option>';
                    $('#cmbEstado').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los estados existentes');
        }
    });

}


function GuardarDesarrollo() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaDesarrollo').addClass('disabled');
    $('#btnGuardaDesarrollo').addClass('loading');

    var strParams = {
        Id: $('#hidDesarrollo').val(),
        Fecha_Inicio: $('#txtFechaInicio').val(),
        Fecha_Termino: $('#txtFechaTermino').val(),
        Modulo: $('#txtModulo').val(),
        Requerimiento: $('#txtRequerimiento').val(),
        Detalle_Requerimiento: $('#txtDetalle').val(),
        Estado_Id: $('#cmbEstado').val(),
        Usuario_Responsable_Id: $('#cmbResponsable').val()
    }
    $.ajax({
        url: window.urlGuardarDesarrollo,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                $('#divExito').removeClass("hidden");
                setTimeout(() => { window.location.href = '/Agenda?actualizar=1' }, 1000);
                /*setTimeout(() => { location.reload(); }, 2000);*/
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

    $('#divTxtFechaInicio').removeClass('error');
    $('#divTxtFechaTermino').removeClass('error');
    $('#divTxtModulo').removeClass('error');
    $('#divTxtRequerimiento').removeClass('error');
    $('#divcmbEstado').removeClass('error');
    $('#divTxtDetalle').removeClass('error');  
    $('#DivMessajeErrorGeneral').addClass('hidden');
    



    if ($('#cmbEstado').val() === '-1') {
        $('#divcmbEstado').addClass('error');
        errores.push('Debe ingresar el estado del desarrollo')
    }
    if ($('#txtFechaInicio').val() === '') {
        $('#divTxtFechaInicio').addClass('error');
        errores.push('Debe indicar la fecha de inicio');
    }
    if ($('#txtFechaTermino').val() === '') {
        $('#divTxtFechaTermino').addClass('error');
        errores.push('Debe indicar la fecha de termino');
    }
    if ($('#txtModulo').val() === '') {
        $('#divTxtModulo').addClass('error');
        errores.push('Debe indicar el módulo');
    }
    if ($('#txtRequerimiento').val() === '') {
        $('#divTxtRequerimiento').addClass('error');
        errores.push('Debe indicar el requerimiento');
    }
    if ($('#txtDetalle').val() === '') {
        $('#divTxtDetalle').addClass('error');
        errores.push('Debe indicar el detalle del requerimiento');
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


function PreparaEliminarDesarrollo(id) {
    $('#hidDesarrollo').val(id);

}

function EliminarDesarrollo() {

    $('#btnEliminarDesarrollo').addClass('loading');
    $('#btnEliminarDesarrollo').addClass('disabled');
    var idDesarrollo = $('#hidDesarrollo').val();

    $.ajax({
        url: window.urlEliminarDesarrollo,
        type: 'POST',
        data: { idDesarrollo: idDesarrollo },
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
function PrepararEditarDesarrollo(id) {
    $('#hidDesarrollo').val(id);
}

function EditarDesarrollo() {

    var idDesarrollo = $('#hidDesarrollo').val();

    $.ajax({
        url: window.urlEditarDesarrollo,
        type: 'POST',
        data: { idDesarrollo: idDesarrollo },
        success: function (desarrollo) {
            $('#txtModulo').val(desarrollo.Modulo);
            $('#txtFechaInicio').val(desarrollo.FechaInicioMostrar);
            $('#txtFechaTermino').val(desarrollo.FechaTerminoMostrar);
            $('#txtRequerimiento').val(desarrollo.Requerimiento);
            $('#txtDetalle').val(desarrollo.Detalle_Requerimiento);

            $("#cmbEstado").dropdown('set selected', desarrollo.Estado_Id);
            $("#cmbResponsable").dropdown('set selected', desarrollo.Usuario_Responsable_Id);
            
        },
        error: function () {
            alert('Error al cargar los datos de la información');
        }
    });
}
function ObtenerUsuarios() {

    $.ajax({
        url: window.urlObtenerUsuarios,
        type: 'POST',
        success: function (data) {
            $('#cmbResponsable').dropdown('clear');
            $('#cmbResponsable').empty();
            $('#cmbResponsable').append('<option value="-1">[Seleccione el usuario responsable]</option>');
            
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.NombreCompleto + '</option>';
                    $('#cmbResponsable').append(texto);

                    
                }
            );

        },
        error: function () {
            alert('Error al cargar los usuarios existentes');
        }
    });

}

function BusquedaFiltro() {
    $('#btnBuscar').addClass("loading");
    $('#btnBuscar').addClass("disabled");

    var entity = {
        FechaDesde: $('#txtFiltroFechaDesde').val(),
        FechaHasta: $('#txtFiltroFechaHasta').val(),
        
    }
    $.ajax({
        url: window.urlBusquedaFiltro,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {

            window.location.href = '/Desarrollos?buscar=1';

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}






