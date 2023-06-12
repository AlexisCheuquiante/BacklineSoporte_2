$(document).ready(function () {

    ObtenerTipoBusqueda();

});

function fnTipoConvenio(id) {
    var id = $('#cmbFiltroTipoBusqueda').val();

    if (id <= 0) {
        $('#divcmbFiltroEmpresa').hide();
    }
    if (id == 1) {
        $('#divcmbFiltroEmpresa').show();
        ObtenerEmpresas();
    }
    if (id == 2) {
        $('#divcmbFiltroEmpresa').show();
        ObtenerEmpresas();
    }
}

function ObtenerTipoBusqueda() {

    $.ajax({
        url: window.urlObtenerTipoBusqueda,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroTipoBusqueda').dropdown('clear');
            $('#cmbFiltroTipoBusqueda').empty();
            $('#cmbFiltroTipoBusqueda').append('<option value="-1">[Seleccione]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbFiltroTipoBusqueda').append(texto);
                }
            );
        },
        error: function () {
            alert('Error al cargar los tipos de busqueda existentes');
        }
    });

}
function ObtenerEmpresas() {

    $.ajax({
        url: window.urlObtenerEmpresas,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroEmpresa').dropdown('clear');
            $('#cmbFiltroEmpresa').empty();
            $('#cmbFiltroEmpresa').append('<option value="-1">[Seleccione empresa]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.NombreEmpresa + '</option>';
                    $('#cmbFiltroEmpresa').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las empresas existentes');
        }
    });

}
function BusquedaFiltro() {
    $('#btnbuscar').addClass("loading");
    $('#btnbuscar').addClass("disabled");

    var entity = {
        TipoBusqueda_Id: $('#cmbFiltroTipoBusqueda').val(),
        EmpId: $('#cmbFiltroEmpresa').val(),
    }
    $.ajax({
        url: window.urlBusquedaFiltro,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            
            window.location.href = '/Informes?buscar=1';
            
        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}