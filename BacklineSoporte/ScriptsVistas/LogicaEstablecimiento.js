$(document).ready(function () {

    ObtenerTipoEstablecimiento();
    
});

function ObtenerTipoEstablecimiento() {

    $.ajax({
        url: window.urlObtenerTipoEstablecimiento,
        type: 'POST',
        success: function (data) {
            $('#cmbSucursal').dropdown('clear');
            $('#cmbSucursal').empty();
            $('#cmbSucursal').append('<option value="-1">[Seleccione tipo de sucursal]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbSucursal').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los tipos de sucursales existentes');
        }
    });

}
function PreparaEliminaEstablecimiento(id) {
    $('#hidEstablecimiento').val(id);
}
function EliminarEstablecimiento() {

    $('#btnEliminarEstablecimiento').addClass('loading');
    $('#btnEliminarEstablecimiento').addClass('disabled');

    var id = $('#hidEstablecimiento').val();

    $.ajax({
        url: window.urlEliminarEstablecimiento,
        type: 'POST',
        data: { id: id },
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    $('#divConsultaElimina').addClass("hidden");
                    $('#divExitoElimina').removeClass("hidden");
                    setTimeout(() => { location.reload(); }, 3000);
                }


            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al eliminar el modulo. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function GuardarEstablecimiento() {


    $('#btnGuardaEstablecimiento').addClass('disabled');
    $('#btnGuardaEstablecimiento').addClass('loading');

    var strParams = {
        Id: $('#hidEstablecimiento').val(),
        Ties_Id: $('#cmbSucursal').val(),
        NombreEstablecimiento: $('#txtEstablecimiento').val(),
        Direccion: $('#txtDireccion').val(),
        Telefono: $('#txtTelefono').val(),
        Correo: $('#txtCorreo').val(),
        BE_Afecta_IVA: $('#idRepetición').val()
    }
    $.ajax({
        url: window.urlGuardarEstablecimiento,
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
function PrepararEditaEstablecimiento(id) {
    $('#hidEstablecimiento').val(id);
}
function EditarEstablecimiento() {

    var idEstablecimiento = $('#hidEstablecimiento').val();

    $.ajax({
        url: window.urlEditarEstablecimiento,
        type: 'POST',
        data: { idEstablecimiento: idEstablecimiento },
        success: function (establecimiento) {
            $("#cmbSucursal").dropdown('set selected', establecimiento.Ties_Id);
            $('#txtEstablecimiento').val(establecimiento.NombreEstablecimiento);
            $('#txtDireccion').val(establecimiento.Direccion);
            $('#txtTelefono').val(establecimiento.Telefono);
            $('#txtCorreo').val(establecimiento.Correo);
            $("#cmbRepetición").dropdown('set selected', establecimiento.BE_Afecta_IVA);
        },
        error: function () {
            alert('Error al cargar los datos del establecimiento');
        }
    });
}