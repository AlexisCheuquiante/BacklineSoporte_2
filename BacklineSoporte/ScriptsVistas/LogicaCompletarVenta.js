var _arrayRlEmpBode = [];
var _arrayProductosAgregados = [];

$(document).ready(function () {

    ObtenerEmpresas();

    $('#cmbLote').change(function () {
        var id = $('#cmbLote').val();

        $.each(_arrayRlEmpBode, function (value, item) {

            if (item.Id == id) {

                $('#txtStock').val(item.Stock);
                $('#txtValorVenta').val(item.Valor);
                $('#txtFechaVencimientoLote').val(item.FechaMostrar);
            }
        });

    });
});

function ObtenerEmpresas() {

    $.ajax({
        url: window.urlObtenerEmpresas,
        type: 'POST',
        success: function (data) {
            $('#cmbEmpresa').dropdown('clear');
            $('#cmbEmpresa').empty();
            $('#cmbEmpresa').append('<option value="-1">[Seleccione empresa]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.NombreEmpresa + '</option>';
                    $('#cmbEmpresa').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las empresas existentes');
        }
    });

}
function ObtenerBodegas() {

    var entity = {
        EmpId: $('#cmbEmpresa').val(),
    };

    $.ajax({
        url: window.urlObtenerBodegas,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            $('#cmbBodega').dropdown('clear');
            $('#cmbBodega').empty();
            $('#cmbBodega').append('<option value="-1">[Seleccione bodega]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.NombreBodega + '</option>';
                    $('#cmbBodega').append(texto);
                }
            );
        },
        error: function () {
            alert('Error al cargar el texto de aviso');
        }
    });
}
function ObtenerProductos() {

    var entity = {
        EmpId: $('#cmbEmpresa').val(),
    };

    $.ajax({
        url: window.urlObtenerProductos,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            $('#cmbProducto').dropdown('clear');
            $('#cmbProducto').empty();
            $('#cmbProducto').append('<option value="-1">[Seleccione Producto]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbProducto').append(texto);
                }
            );
        },
        error: function () {
            /*alert('Error al cargar el texto de aviso');*/
        }
    });
}
function ObtenerRlEmpBode() {

    var entity = {
        EmpId: $('#cmbEmpresa').val(),
        Bode_Id: $('#cmbBodega').val(),
        Prod_Id: $('#cmbProducto').val()
    };

    $.ajax({
        url: window.urlObtenerRlEmpBode,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            $('#cmbLote').dropdown('clear');
            $('#cmbLote').empty();
            $('#cmbLote').append('<option value="-1">[Seleccione Lote]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.Lote + '</option>';
                    $('#cmbLote').append(texto);
                    _arrayRlEmpBode.push(item);
                }
            );
        },
        error: function () {
            /*alert('Error al cargar los lotes');*/
        }
    });
}
function AgregarProducto() {

    //if (ValidaAgregar() == false)

    //    return;

    var cantidad = 0;
    var valor = 0;

    cantidad = $('#txtCantidad').val();
    valor = $('#txtValorVenta').val();
    var subtotal = cantidad * valor;

    var DetalleProducto = {
        Bode_Id: $('#cmbBodega').val(),
        Fact_Id: $('#txtIdBoleta').val(),
        Prod_Id: $('#cmbProducto').val(),
        Descripcion_Prod: $('#cmbProducto').dropdown('get text'),
        Lote: $('#cmbLote').dropdown('get text'),
        Fecha_Vencimiento: $('#txtFechaVencimientoLote').val(),
        Valor: $('#txtValorVenta').val(),
        Cantidad_Descontar: $('#txtCantidad').val(),
        Lote_Id: $('#cmbLote').val(),
        Stock: $('#txtStock').val(),
        Subtotal: subtotal,
        Total: subtotal,
    };

    $.ajax({
        url: window.urlAgregarProducto,
        type: 'POST',
        data: { entity: DetalleProducto },
        success: function (data) {
            /*$('#DivMessajeErrorGeneral').addClass("hidden");*/
            _arrayProductosAgregados.push(DetalleProducto);
            ObtenerProductos();
            ObtenerRlEmpBode();
            document.getElementById("txtFechaVencimientoLote").value = "";
            document.getElementById("txtStock").value = "";
            document.getElementById("txtValorVenta").value = "";
            document.getElementById("txtCantidad").value = "";
            PintaGrid();
            //if (data === 'exito') {
            //    location.reload();
            //}
            //if (data === 'error') {
            //    $('#divErroLogin').removeClass("hidden");
            //}

        },
        error: function (ex) {
            alert('Error al guardar el producto');
        }
    });

}
function PintaGrid() {
    var tabla = "<table class='ui celled table'>";
    tabla = tabla + "<thead><tr><th>Id Producto</th><th>Descripción producto</th><th>Lote</th><th>Fecha Vencimiento</th><th>Valor venta</th><th>Stock a descontar</th></tr></thead>";
    tabla = tabla + "<tbody>";
    $.each(_arrayProductosAgregados, function (value, item) {
        tabla = tabla + "<tr>";
        tabla = tabla + "<td>" + item.Prod_Id + "</td><td>" + item.Descripcion_Prod + "</td><td>" + item.Lote + "</td><td>" + item.Fecha_Vencimiento + "</td><td>" + item.Valor + "</td><td>" + item.Cantidad_Descontar + "</td>";
        tabla = tabla + "</tr>";
    });

    $('#grdDatos').html(tabla);
}
function GuardarDescuentoStock() {

    var strParams = {
        Emp_Id: $('#cmbEmpresa').val(),
        Fact_Id: $('#txtIdBoleta').val(),
        Bode_Id: $('#cmbBodega').val(),
    };

    $.ajax({
        url: window.urlInsertarDescuentoStock,
        type: 'POST',
        data: { entity: strParams },
        success: function (data) {
            if (data != 'error') {
                $('#divExito').removeClass("hidden");
                setTimeout(() => { window.location.href = '/CompletarVenta' }, 2000);
            }
            //if (data === 'insuficiente') {
            //    $('#divStockInsuficiente').removeClass("hidden");
            //    $('#btnAgregarProducto').addClass('disabled');
            //    $('#btnGeneraVenta').addClass('disabled');
            //    $('#btnVolver').removeClass('disabled');
            //    $('#btnVolver').removeClass('loading');
            //    $('#btnLimpiar').removeClass('disabled');
            //    $('#btnLimpiar').removeClass('loading');
            //}

        },
        error: function (ex) {
            alert('Error al generar la venta');
        }
    });

}