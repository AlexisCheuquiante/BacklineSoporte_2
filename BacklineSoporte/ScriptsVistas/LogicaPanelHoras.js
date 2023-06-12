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

            window.location.href = '/PanelHoras?buscar=1';

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}