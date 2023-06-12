$(document).ready(function () {

    ObtenerProductoFacturado();
    ObtenerEstadoFactura();
});

function ObtenerProductoFacturado() {

    $.ajax({
        url: window.urlObtenerProductoFacturado,
        type: 'POST',
        success: function (data) {
            $('#cmbProducto').dropdown('clear');
            $('#cmbProducto').empty();
            $('#cmbProducto').append('<option value="-1">[Seleccione producto facturado]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.ID + '">' + item.Producto_Facturado + '</option>';
                    $('#cmbProducto').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las productos existentes');
        }
    });

}
function ObtenerEstadoFactura() {

    $.ajax({
        url: window.urlObtenerEstadoFactura,
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
            alert('Error al cargar las productos existentes');
        }
    });

}
