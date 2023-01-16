function GuardarComentario() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaComentario').addClass('disabled');
    $('#btnGuardaComentario').addClass('loading');

    var strParams = {

        ComentarioObs: $('#txtComentario').val()
    }
    $.ajax({
        url: window.urlGuardarComentario,
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

function Limpiar() {

    $('#txtComentario').val('');
}

function ValidaGuardar() {
    errores = [];

    $('#DivMessajeErrorGeneral').addClass("hidden");
    $('#divTxtComentario').removeClass('error');


    if ($('#txtComentario').val() === '') {
        $('#divTxtComentario').addClass('error');
        errores.push('Debe ingresar el comentario');
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
function ObtenerImagenesComentario(id) {
    $('#idComentario').val(id);

    id = $('#idComentario').val();
    $.ajax({
        url: window.urlObtenerImagenesComentario,
        type: 'POST',
        data: { id: id },
        success: function (data) {
            $('#txtNombre').val(data.Nombre)
        },

        error: function () {
            alert('No se encontraron imagenes');
        }
    });
    _id = id;
}