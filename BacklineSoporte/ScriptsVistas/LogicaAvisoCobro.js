var _arrayTiempo = [];
var _intervalotiempo = [];

$(document).ready(function () {

    ObtenerIntervaloTiempo();
    ObtenerEmpresas();

    $('#cmbTiempo').change(function () {
        var idTiempo = $('#cmbTiempo').val();

        $.each(_arrayTiempo, function (value, item) {

            if (item.Id == idTiempo) {

                _intervalotiempo = item.IntervaloTiempo

            }
        });

    });
});
function ObtenerIntervaloTiempo() {

    $.ajax({
        url: window.urlObtenerIntervaloTiempo,
        type: 'POST',
        success: function (data) {
            $('#cmbTiempo').dropdown('clear');
            $('#cmbTiempo').empty();
            $('#cmbTiempo').append('<option value="-1">[Seleccione tiempo]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.IntervaloTiempo + '</option>';
                    $('#cmbTiempo').append(texto);
                    _arrayTiempo.push(item);
                }
            );
            
        },
        error: function () {
            alert('Error al cargar los intervalos de tiempo existentes');
        }
    });

}
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
function ObtenerAviso() {

    var entity = {
        Id: $('#cmbEmpresa').val(),
    };

    $.ajax({
        url: window.urlObtenerAviso,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            if (data == "Nada") {
                document.getElementById("txtDetalle").value = "";
            }
            $('#txtDetalle').val(data.TextoAviso);

        },
        error: function () {
            alert('Error al cargar el texto de aviso');
        }
    });
}
function UpdateMensajeCorte() {

    //if (ValidaGuardar() == false)
    //    return;

    $('#btnSubirAviso').addClass('disabled');
    $('#btnSubirAviso').addClass('loading');

    var strParams = {

        Id: $('#cmbEmpresa').val(),
        IntervaloTiempo: _intervalotiempo,
        TextoAviso: $('#txtDetalle').val(),
        MostrarAviso: $('#idVisible').val(),
    }
    $.ajax({
        url: window.urlUpdateMensajeCorte,
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
