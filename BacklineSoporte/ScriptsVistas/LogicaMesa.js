function PreparaInsertarApruebo(id) {
    $('#hidRequerimiento').val(id);

}
function InsertaApruebo() {
    $('#btnApruebo').addClass('loading');
    $('#btnApruebo').addClass('disabled');

    id = $('#hidRequerimiento').val();
    $.ajax({
        url: window.urlInsertarApruebo,
        type: 'POST',
        data: { id: id },
        success: function (data) {
            if (data === 'exito') {
                $('#divConsultaApruebo').addClass("hidden");
                $('#divExitoAprueba').removeClass("hidden");
                setTimeout(() => { location.reload(); }, 1000);
            }
        },
        error: function (data) {
            console.log(data);
            showMessage('body', 'danger', 'Ocurrió un error al aprobar el requerimiento seleccionado.' + data);
        }
    });
}
function PreparaInsertarDesapruebo(id) {
    $('#hidRequerimiento').val(id);

}
function InsertaDesapruebo() {
    $('#btnDesaprueba').addClass('loading');
    $('#btnDesaprueba').addClass('disabled');

    id = $('#hidRequerimiento').val();
    $.ajax({
        url: window.urlInsertarDesapruebo,
        type: 'POST',
        data: { id: id },
        success: function (data) {
            if (data === 'exito') {
                $('#divConsultaDesaprueba').addClass("hidden");
                $('#divExitoDesaprueba').removeClass("hidden");
                setTimeout(() => { location.reload(); }, 1000);
            }
        },
        error: function (data) {
            console.log(data);
            showMessage('body', 'danger', 'Ocurrió un error al desaprobar el requerimiento seleccionado.' + data);
        }
    });
}
function BusquedaFiltro() {
    $('#btnBuscarFiltro').addClass("loading");
    $('#btnBuscarFiltro').addClass("disabled");

    var entity = {
        FechaDesde: $('#txtFiltroFechaDesde').val(),
        FechaHasta: $('#txtFiltroFechaHasta').val(),
        Estado: $('#idcmbEstado').val(),
    }
    $.ajax({
        url: window.urlBusquedaFiltro,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {

            window.location.href = '/Mesa?buscar=1';

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function ObtenerRequerimiento_Numero() {
    $('#btnBuscar').addClass("loading");
    $('#btnBuscar').addClass("disabled");
    $('#btnBuscarNumero').addClass("loading");
    $('#btnBuscarNumero').addClass("disabled");

    var entity = {
        Id: $('#txtNumero').val(),
    }
    $.ajax({
        url: window.urlObtenerRequerimiento_Numero,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            if (data != 'errorNumero') {
                window.location.href = '/Mesa?buscar=1';
            }
            if (data === 'errorNumero') {
                $('#btnBuscar').removeClass("loading");
                $('#btnBuscar').removeClass("disabled");
                $('#btnBuscarNumero').removeClass("loading");
                $('#btnBuscarNumero').removeClass("disabled");
                $('#divErrorNumero').removeClass("hidden");
            }

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}