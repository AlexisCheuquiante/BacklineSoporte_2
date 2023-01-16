var _arraySolicitante = [];
var _nombreSolicitante = [];
var _arrayDocumentos = [];

$(document).ready(function () {

    ObtenerEmpresas();
    ObtenerTipoDocumetoConsulta();

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
function ObtenerTipoDocumetoConsulta() {

    $.ajax({
        url: window.urlObtenerTipoDocumetoConsulta,
        type: 'POST',
        success: function (data) {
            $('#cmbTipoDocumento').dropdown('clear');
            $('#cmbTipoDocumento').empty();
            $('#cmbTipoDocumento').append('<option value="-1">[Seleccione tipo de documento]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbTipoDocumento').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los tipos de documento existentes');
        }
    });

}
function ObtenerSolicitante() {

    _arraySolicitante = [];
    _arrayDocumentos = [];
    PintaGridMovimientos();

    var entity = {
        EmpId: $('#cmbEmpresa').val(),
    };

    $.ajax({
        url: window.urlObtenerSolicitante,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            $.each(data,
                function (value, item) {
                    _arraySolicitante.push(item);
                    PintaGrid();
                    LimpiaEstilosGuardar();
                    $('#DivMessajeErrorGeneral').addClass("hidden");
                }
            );
            
        },
        error: function () {
            alert('Error al cargar los productos existentes');
        }
    });
}
function PintaGrid() {
    var tabla = "<table class='ui celled table table-striped'>";
    tabla = tabla + "<thead><tr><th> </th><th>Nombre usuario</th><th>Activo</th><th>Eliminado</th></tr></thead>";
    tabla = tabla + "<tbody>";
    $.each(_arraySolicitante, function (value, item) {
        tabla = tabla + "<tr>";
        tabla = tabla + "<td>" + "" + "</td><td>" + item.NombreSolicitante + "</td><td>" + item.ActivoMostrar + "</td><td>" + item.EliminadoMostrar + "</td>";
        tabla = tabla + "</tr>";
    });

    $('#grdDatos').html(tabla);

    
}
function ObtenerDocumentosConsulta() {

    if (ValidaBuscar() == false)

        return;

    _arrayDocumentos = [];

    

    var entity = {
        EmpId: $('#cmbEmpresa').val(),
        TipoDocumentoConsulta: $('#cmbTipoDocumento').val(),
    };

    $.ajax({
        url: window.urlObtenerDocumentosConsulta,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            $.each(data,
                function (value, item) {
                    _arrayDocumentos.push(item);
                    PintaGridMovimientos();
                }
            );

        },
        error: function () {
            alert('Error al cargar los documentos existentes');
        }
    });
}
function PintaGridMovimientos() {
    var tabla = "<table class='ui celled table table-striped'>";
    tabla = tabla + "<thead><tr><th> </th><th>Fecha</th><th>Numero</th><th>Numero SII</th><th>Tipo documento</th></tr></thead>";
    tabla = tabla + "<tbody>";
    $.each(_arrayDocumentos, function (value, item) {
        tabla = tabla + "<tr>";
        tabla = tabla + "<td>" + "" + "</td><td>" + item.FechaMostrar + "</td><td>" + item.Numero + "</td><td>" + item.NumeroSii + "</td><td>" + item.TipoDocumentoStr + "</td>";
        tabla = tabla + "</tr>";
    });

    $('#grdDatosMovimiento').html(tabla);


}
function Limpiar() {

    location.reload();

}
function LimpiaEstilosGuardar() {
    //Limpio el estilo Error antes de validar
    $('#divcmbEmpresa').removeClass("error");
    
}
function ValidaBuscar() {
    var esValido = true;
    var errores = [];

    LimpiaEstilosGuardar();

    if ($('#cmbEmpresa').val() === '-') {
        $('#divcmbEmpresa').addClass('error');
        errores.push('Debe indicar una empresa')
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