$(document).ready(function () {



    $('#camionImg').change(function () {
        //alert('Imagen Camion');
        //showLoading();
        var indice = 0;
        var nameFile = '';
        var files = !!this.files ? this.files : [];

        if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

        for (var i = 0; i < files.length; i++) {
            if (/^image/.test(files[i].type)) { // only image file
                var reader = new FileReader(); // instance of the FileReader
                reader.readAsDataURL(files[i]); // read the local file
                nameFile = files[i].name;

                reader.onloadend = function () { // set image data as background of div
                    imagenPerfil = this.result;

                    //$("#imagenesCamion").prepend("<div class='col-md-3' id='container_" + indice + "'><div class='box box-info'><div class='box-header'><h3 class='box-title'><span id='name_" + indice + "'></span></h3><div class='box-body'><img id='img_" + indice + "' src='" + this.result + "' alt='" + nameFile + "' style='width:100%;max-height: 160px;' class='imgCamion' /></div><div class='box-footer'><button type='button' class='btn btn-danger btn-block' onclick='EliminaImagen(" + indice + ");'>Eliminar</button></div></div></div>");
                    $("#imagenesCamion").prepend("<div class='col-md-4' id='container_" + indice + "'><div class='box box-info'><div class='box-header'><h3 class='box-title'><span id='name_" + indice + "'></span></h3><div class='box-body'><img id='img_" + indice + "' src='" + this.result + "' alt='" + nameFile + "' style='height: 160px; width:160px;' class='imgCamion' /></div><div class='box-footer'><button type='button' style='width:160px;' class='btn btn-danger btn-block' onclick='EliminaImagen(" + indice + ");'>Eliminar</button></div></div></div>");
                    indice += 1;
                    //hideLoading();
                }
            }
        }


    });
});
function GuardarImagen1() {
    $.ajax({
        success: function () {
            $.each($('.imgCamion'), function () {
                var id = $(this).attr('id');
                var indice = id.replace('img_', '');

                var check = $('#chk_' + indice).is(':checked');
                var src = $(this).attr('src');
                var name = $(this).attr('alt');

                var strImagen = {
                    ID: 0,
                    RUTA_IMAGEN: src,
                    NOMBRE_IMAGEN: name
                };

                GuardarImagen(strImagen, $('.imgCamion').length - 1, parseInt(indice));

            });
            location.reload();
        },
        error: function () {
            alert('Error al cargar los Tipos');
        }
    });


}

GuardarImagen = function (strImagen, totalImagenes, nroImagen) {
    //alert('intento guardar');
    $.ajax({
        url: window.urlSaveImagen,
        type: 'POST',
        data: { entity: strImagen },
        async: false,
        success: function (data) {
            //alert('GUARDOOOOO');
            if (totalImagenes === nroImagen) {
                showMessage('#divMensajeResultadoNuevoCamion', 'success', 'La información del camión fue guardada con éxito.');

            }

            return true;
        },
        error: function (msg) {
            alert('error' + msg);
            showMessage('#divMensajeResultadoNuevoCamion', 'danger', 'Ocurrió un error al guardar la(s) imagen(es). Por favor intente nuevamente.');
            hideLoading();
            return false;
        }
    });
};