function PreparaInsertarApruebo(id) {
    $('#hidRequerimiento').val(id);

}
function InsertaApruebo() {
    $('#btnApruebo').addClass('loading');
    $('#btnApruebo').addClass('disabled');

    id = $('#hidRequerimiento').val();
    $.ajax({
        url: window.urlInsertarApruebo,
        type: 'POST',
        data: { id: id },
        success: function (data) {
            if (data === 'exito') {
                $('#divConsultaApruebo').addClass("hidden");
                $('#divExitoAprueba').removeClass("hidden");
                setTimeout(() => { location.reload(); }, 1000);
            }
        },
        error: function (data) {
            console.log(data);
            showMessage('body', 'danger', 'Ocurrió un error al aprobar el requerimiento seleccionado.' + data);
        }
    });
}
function PreparaInsertarDesapruebo(id) {
    $('#hidRequerimiento').val(id);

}
function InsertaDesapruebo() {
    $('#btnDesaprueba').addClass('loading');
    $('#btnDesaprueba').addClass('disabled');

    id = $('#hidRequerimiento').val();
    $.ajax({
        url: window.urlInsertarDesapruebo,
        type: 'POST',
        data: { id: id },
        success: function (data) {
            if (data === 'exito') {
                $('#divConsultaDesaprueba').addClass("hidden");
                $('#divExitoDesaprueba').removeClass("hidden");
                setTimeout(() => { location.reload(); }, 1000);
            }
        },
        error: function (data) {
            console.log(data);
            showMessage('body', 'danger', 'Ocurrió un error al desaprobar el requerimiento seleccionado.' + data);
        }
    });
}
