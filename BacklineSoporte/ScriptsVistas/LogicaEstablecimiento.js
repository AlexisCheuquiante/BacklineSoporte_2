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
        NombreEstablecimiento: $('#txtEstablecimiento').val(),
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
            $('#txtEstablecimiento').val(establecimiento.NombreEstablecimiento);
            $("#cmbRepetición").dropdown('set selected', establecimiento.BE_Afecta_IVA);
        },
        error: function () {
            alert('Error al cargar los datos del establecimiento');
        }
    });
}
