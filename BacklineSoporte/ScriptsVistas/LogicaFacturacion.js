$(document).ready(function () {

    ObtenerProductoFacturado();
   


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