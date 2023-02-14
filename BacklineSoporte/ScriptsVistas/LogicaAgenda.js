$(document).ready(function () {
        ObtenerTipoTarea(),
        ObtenerModalidadTarea(),
        ObtenerUsuarios()
});




function ObtenerTipoTarea() {

    $.ajax({
        url: window.urlObtenerTipoTarea,
        type: 'POST',
        success: function (data) {
            $('#cmbTipoTarea').dropdown('clear');
            $('#cmbTipoTarea').empty();
            $('#cmbTipoTarea').append('<option value="-1">[Seleccione el tipo de tarea]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Tipo + '</option>';
                    $('#cmbTipoTarea').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los tipo de tareas existentes');
        }
    });

}

function ObtenerModalidadTarea() {

    $.ajax({
        url: window.urlObtenerModalidadTarea,
        type: 'POST',
        success: function (data) {
            $('#cmbModalidad').dropdown('clear');
            $('#cmbModalidad').empty();
            $('#cmbModalidad').append('<option value="-1">[Seleccione la modalidad de la tarea]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Modalidad + '</option>';
                    $('#cmbModalidad').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las modalidades existentes');
        }
    });

}

function ObtenerUsuarios() {

    $.ajax({
        url: window.urlObtenerUsuarios,
        type: 'POST',
        success: function (data) {
            $('#cmbAsignacion').dropdown('clear');
            $('#cmbAsignacion').empty();
            $('#cmbAsignacion').append('<option value="-1">[Seleccione usuarios asignados]</option>');
            $('#cmbFiltroUsuario').dropdown('clear');
            $('#cmbFiltroUsuario').empty();
            $('#cmbFiltroUsuario').append('<option value="-1">[Seleccione usuario asginado]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.NombreCompleto + '</option>';
                    $('#cmbAsignacion').append(texto);

                    var texto = '<option value="' + item.Id + '">' + item.NombreCompleto + '</option>';
                    $('#cmbFiltroUsuario').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los usuarios existentes');
        }
    });

}

function GuardarTarea() {


    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaTarea').addClass('loading');
    $('#btnGuardaTarea').addClass('disabled');

    var arreglo = $("#cmbAsignacion").dropdown("get value");
    var largoArreglo = arreglo.length;

    var textoArreglo = '';
    for (i = 0; i < largoArreglo; i++) {
        textoArreglo = textoArreglo + ',' + arreglo[i];
    }

    var strParams = {
        Id: $('#hidTarea').val(),
        Fecha_Ingreso_Tarea: $('#txtFechaIngreso').val(),
        Fecha_Inicio_Tarea: $('#txtFechaInicio').val(),
        Fecha_Termino_Tarea: $('#txtFechaTermino').val(),
        Tipo_Tarea_Id: $('#cmbTipoTarea').val(),
        Modalidad_Id: $('#cmbModalidad').val(),
        Detalle: $('#txtDetalle').val()
    };
    $.ajax({
        url: window.urlInsertarTarea,
        type: 'POST',
        data: { entity: strParams, idsUsuarios: textoArreglo },
        dataType: "json",
        success: function (data) {
            if (data === 'exito') {
                $('#DivMessajeErrorGeneral').addClass("hidden");
                $('#divExito').removeClass("hidden");
                setTimeout(() => { window.location.href = '/Agenda?actualizar=1' }, 1000);
            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar el comentario. Por favor intente nuevamente.');
            //hideLoading();
        }
    });
}

function ValidaGuardar() {
    errores = [];

    $('#divcmbTipoTarea').removeClass('error');
    $('#divtxtFechaInicio').removeClass('error');
    $('#divtxtFechaTermino').removeClass('error');
    $('#divcmbPrioridad').removeClass('error');
    $('#divcmbAsignacionUsuario').removeClass('error');
    $('#divTxtDetalle').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass('hidden');



    if ($('#cmbTipoTarea').val() === '-1') {
        $('#divcmbTipoTarea').addClass('error');
        errores.push('Debe ingresar el tipo de tarea')
    }
    if ($('#txtFechaInicio').val() === '') {
        $('#divtxtFechaInicio').addClass('error');
        errores.push('Debe ingresar una fecha de inicio');
    }

    if ($('#txtFechaTermino').val() === '') {
        $('#divtxtFechaTermino').addClass('error');
        errores.push('Debe ingresar una fecha de termino');
    }

    if ($('#cmbPrioridad').val() === '-1') {
        $('#divcmbPrioridad').addClass('error');
        errores.push('Debe ingresar el tipo de tarea')
    }
    if ($('#cmbAsignacion').val() === '-1') {
        $('#divcmbAsignacionUsuario').addClass('error');
        errores.push('Debe ingresar el tipo de tarea')
    }

    if ($('#txtDetalle').val() === '') {
        $('#divTxtDetalle').addClass('error');
        errores.push('Debe ingresar el detalle');
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

function PrepararEditarTarea(id) {
    $('#hidTarea').val(id);
}
function EditarTarea() {

    var idTarea = $('#hidTarea').val();

    $.ajax({
        url: window.urlEditarTarea,
        type: 'POST',
        data: { idTarea: idTarea },
        success: function (tarea) {

            $('#txtFechaInicio').val(tarea.FechaInicioHora),
                $('#txtFechaTermino').val(tarea.FechaTerminoHora),

                $("#cmbTipoTarea").dropdown('set selected', tarea.Tipo_Tarea_Id),
                $("#cmbModalidad").dropdown('set selected', tarea.Modalidad_Id),
                           
                $('#txtDetalle').val(tarea.Detalle)

            
            tarea.ListaUsuariosAsignados.forEach(function (element) {
                $("#cmbAsignacion").dropdown('set selected', element.Usr_Id);
            });
        },

        error: function () {
            alert('Error al cargar los datos de la tarea');
        }
    });


}

function PrepararRealizarTarea(id) {
    $('#hidTarea').val(id);
}
function RealizarTarea() {

   

    $('#btnRealizarTarea').addClass('loading');
    $('#btnRealizarTarea').addClass('disabled');
    id = $('#hidTarea').val();
    var tarea = {
        
        Realizada: $('#idRealizada').val()
    };
    $.ajax({
        url: window.urlRealizarTarea,
        type: 'POST',
        data: { tarea, id: id},
        dataType: "json",
        success: function (data) {
            if (data === 'exito') {
                $('#DivMessajeErrorGeneral').addClass("hidden");
                $('#divExito').removeClass("hidden");
                 window.location.href  = '/Agenda?actualizar=1'
            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar el comentario. Por favor intente nuevamente.');
            //hideLoading();
        }
    });
}

function PreparaEliminaTarea(id) {
    $('#hidTarea').val(id);

}
function EliminarTarea() {
    $('#btnEliminarTarea').addClass('loading');
    $('#btnEliminarTarea').addClass('disabled');

    id = $('#hidTarea').val();
    $.ajax({
        url: window.urlEliminarTarea,
        type: 'POST',
        data: { id: id },
        success: function (data) {
            if (data === 'exito') {
                $('#divConsultaElimina').addClass("hidden");
                $('#divExitoElimina').removeClass("hidden");
                setTimeout(() => { location.reload(); }, 1000);
            }
        },
        error: function (data) {
            console.log(data);
            showMessage('body', 'danger', 'Ocurrió un error al eliminar la tarea seleccionada.' + data);
        }
    });
}
function BusquedaFiltro() {
    $('#btnBuscarFiltro').addClass("loading");
    $('#btnBuscarFiltro').addClass("disabled");

    $('#dimmer').dimmer('show');

    var filtro = {
        FechaDesde: $('#txtFiltroDesde').val(),
        FechaHasta: $('#txtFiltroHasta').val(),
        
    }
    $.ajax({
        url: window.urlBusquedaFiltro,
        type: 'POST',
        data: { filtro: filtro },
        success: function (data) {

            window.location.href = '/Agenda?buscar=1';

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}