var _arrayEmpresa = [];
var _nombreEmpresa = [];
var _arraySolicitante = [];
var _nombreSolicitante = [];

$(document).ready(function () {

    $('#divEspera').dimmer('show');
    ObtenerFiltroTipoSoftware();
    ObtenerFiltroEmpresas();
    ObtenerFiltroResponsable();
    ObtenerFiltroEstado();
    ObtenerModulos();
    ObtenerUsuario();
    ObtenerEmpresas();
    ObtenerTipoPrioridad();
    ObtenerTipoSoftware();
    ObtenerEstado();
    setTimeout(() => { $('#divEspera').dimmer('hide') }, 3000);

    $('#cmbEmpresa').change(function () {
        var idEmpresa = $('#cmbEmpresa').val();

        $.each(_arrayEmpresa, function (value, item) {

            if (item.Id == idEmpresa) {

                _nombreEmpresa = item.NombreEmpresa
                
            }
        });

    });
    $('#cmbSolicitante').change(function () {
        var idSolicitante = $('#cmbSolicitante').val();

        $.each(_arraySolicitante, function (value, item) {

            if (item.Id == idSolicitante) {

                _nombreSolicitante = item.NombreSolicitante

            }
        });

    });
});
function ObtenerModulos() {

    $.ajax({
        url: window.urlObtenerModulos,
        type: 'POST',
        success: function (data) {
            $('#cmbModulo').dropdown('clear');
            $('#cmbModulo').empty();
            $('#cmbModulo').append('<option value="-1">[Seleccione modulo]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.ModuloStr + '</option>';
                    $('#cmbModulo').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los modulos existentes');
        }
    });

}
function ObtenerUsuario() {

    $.ajax({
        url: window.urlObtenerUsuario,
        type: 'POST',
        success: function (data) {
            $('#cmbResponsable').dropdown('clear');
            $('#cmbResponsable').empty();
            $('#cmbResponsable').append('<option value="-1">[Seleccione responsable]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.NombreCompleto + '</option>';
                    $('#cmbResponsable').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los responsables existentes');
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

                    
                    _arrayEmpresa.push(item);
                }
            );

        },
        error: function () {
            alert('Error al cargar las empresas existentes');
        }
    });

}
function ObtenerSolicitante() {

    var entity = {
        EmpId: $('#cmbEmpresa').val(),
    };

    $.ajax({
        url: window.urlObtenerSolicitante,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            $('#cmbSolicitante').dropdown('clear');
            $('#cmbSolicitante').empty();
            $('#cmbSolicitante').append('<option value="-1">[Seleccione solicitante]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.NombreSolicitante + '</option>';
                    $('#cmbSolicitante').append(texto);
                    _arraySolicitante.push(item);
                }
            );
            
        },
        error: function () {
            alert('Error al cargar los productos existentes');
        }
    });
}
function ObtenerTipoPrioridad() {

    $.ajax({
        url: window.urlObtenerTipoPrioridad,
        type: 'POST',
        success: function (data) {
            $('#cmbPrioridad').dropdown('clear');
            $('#cmbPrioridad').empty();
            $('#cmbPrioridad').append('<option value="-1">[Seleccione prioridad]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.PrioridadStr + '</option>';
                    $('#cmbPrioridad').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las prioridades existentes');
        }
    });

}
function ObtenerTipoSoftware() {

    $.ajax({
        url: window.urlObtenerTipoSoftware,
        type: 'POST',
        success: function (data) {
            $('#cmbSoftware').dropdown('clear');
            $('#cmbSoftware').empty();
            $('#cmbSoftware').append('<option value="-1">[Seleccione software]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.TipoSoftware + '</option>';
                    $('#cmbSoftware').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los software existentes');
        }
    });

}
function ObtenerEstado() {

    $.ajax({
        url: window.urlObtenerEstado,
        type: 'POST',
        success: function (data) {
            $('#cmbEstado').dropdown('clear');
            $('#cmbEstado').empty();
            $('#cmbEstado').append('<option value="-1">[Estado del requerimiento]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.EstadoReque + '</option>';
                    $('#cmbEstado').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los software existentes');
        }
    });

}
function GuardarRequerimiento() {

    if (ValidaGuardar() == false)
        return;

    $('#btnGuardaRequerimiento').addClass('loading');
    $('#btnGuardaRequerimiento').addClass('disabled');

    var strParams = {
        Id: $('#hidRequerimiento').val(),
        FechaIngreso: $('#txtFechaIngreso').val(),
        TisoId: $('#cmbSoftware').val(),
        EmpId: $('#cmbEmpresa').val(),
        NombreEmpresa: _nombreEmpresa,
        SolicitanteId: $('#cmbSolicitante').val(),
        NombreSolicitante: _nombreSolicitante,
        Correo: $('#txtCorreo').val(),
        RepeticionRequerimiento: $('#idRepetición').val(),
        ModId: $('#cmbModulo').val(),
        Funcionalidad: $('#txtFuncionalidad').val(),
        Clasificacion: $('#idClasificación').val(),
        PriodId: $('#cmbPrioridad').val(),
        ResponsableId: $('#cmbResponsable').val(),
        FechaSolucion: $('#txtFechaSolucion').val(),
        Visible: $('#idVisible').val(),
        Estado: $('#cmbEstado').val(),
        Detalle: $('#txtDetalle').val()
    };
    $.ajax({
        url: window.urlInsertarRequerimiento,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (data) {
            if (data === 'exito') {
                $('#DivMessajeErrorGeneral').addClass("hidden");
                $('#divExito').removeClass("hidden");
                setTimeout(() => { window.location.href = '/Requerimiento?actualizar=1' }, 2000);
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

    $('#divcmbSoftware').removeClass('error');
    $('#divcmbEmpresa').removeClass('error');
    $('#divcmbSolicitante').removeClass('error');
    $('#divtxtCorreo').removeClass('error');
    $('#divcmbRepetición').removeClass('error');
    $('#divcmbModulo').removeClass('error');
    $('#divtxtFuncionalidad').removeClass('error');
    $('#divcmbClasificación').removeClass('error');
    $('#divcmbPrioridad').removeClass('error');
    $('#divcmbResponsable').removeClass('error');
    $('#divcmbVisible').removeClass('error');
    $('#DivMessajeErrorGeneral').addClass('hidden');
    $('#divtxtFechaSolucion').removeClass('error');
    


    if ($('#cmbSoftware').val() === '-1') {
        $('#divcmbSoftware').addClass('error');
        errores.push('Debe ingresar el software')
    }


    if ($('#cmbEmpresa').val() === '-1') {
        $('#divcmbEmpresa').addClass('error');
        errores.push('Debe ingresar la empresa');
    }

    if ($('#cmbSolicitante').val() === '-1') {
        $('#divcmbSolicitante').addClass('error');
        errores.push('Debe ingresar solicitante');
    }

    if ($('#idRepetición').val() === '') {
        $('#divcmbRepetición').addClass('error');
        errores.push('Debe indicar repetición');
    }
    if ($('#cmbModulo').val() === '-1') {
        $('#divcmbModulo').addClass('error');
        errores.push('Debe ingresar el modulo');
    }
    if ($('#txtCorreo').val() === '') {
        $('#divtxtCorreo').addClass('error');
        errores.push('Debe ingresar el correo');
    }
    if ($('#txtFuncionalidad').val() === '') {
        $('#divtxtFuncionalidad').addClass('error');
        errores.push('Debe ingresar una funcionalidad');
    }

    if ($('#idClasificación').val() === '') {
        $('#divcmbClasificación').addClass('error');
        errores.push('Debe ingresar clasificación');
    }
    if ($('#cmbPrioridad').val() === '-1') {
        $('#divcmbPrioridad').addClass('error');
        errores.push('Debe ingresar la prioridad');
    }
    if ($('#cmbResponsable').val() === '-1') {
        $('#divcmbResponsable').addClass('error');
        errores.push('Debe ingresar el responsable');
    }

    if ($('#txtFechaSolucion').val() === '') {
        $('#divtxtFechaSolucion').addClass('error');
        errores.push('Debe ingresar una fecha de solucion');
    }
    if ($('#idVisible').val() === '') {
        $('#divcmbVisible').addClass('error');
        errores.push('Debe indicar la visibilidad del requerimiento');
    }

    if ($('#txtDetalle').val() === '') {
        $('#divtxtDetalle').addClass('error');
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
function PrepararEditarRequerimiento(id) {
    $('#hidRequerimiento').val(id);
}
function EditarRequerimiento() {

    var idRequerimiento = $('#hidRequerimiento').val();

    $.ajax({
        url: window.urlEditarRequerimiento,
        type: 'POST',
        data: { idRequerimiento: idRequerimiento },
        success: function (requerimiento) {

            $('#txtFechaIngreso').val(requerimiento.FechaMostrarIngreso),
                $("#cmbSoftware").dropdown('set selected', requerimiento.TisoId),
                $("#cmbEmpresa").dropdown('set selected', requerimiento.EmpId),
                    $("#cmbSolicitante").dropdown('set selected', requerimiento.SolicitanteId),

                $('#txtCorreo').val(requerimiento.Correo),
                $("#cmbRepetición").dropdown('set selected', requerimiento.RepeticionRequerimiento),
                $('#cmbModulo').dropdown('set selected', requerimiento.ModId);
                $('#txtFuncionalidad').val(requerimiento.Funcionalidad),
                $("#cmbClasificación").dropdown('set selected' , requerimiento.Clasificacion),
                $('#cmbPrioridad').dropdown('set selected', requerimiento.PriodId);
                $('#cmbResponsable').dropdown('set selected', requerimiento.ResponsableId),
                $('#txtFechaSolucion').val(requerimiento.FechaMostrarSolucion),
                    $("#cmbVisibilidad").dropdown('set selected', requerimiento.Visible),
                    $("#cmbEstado").dropdown('set selected', requerimiento.Estado),

                $('#txtDetalle').val(requerimiento.Detalle)

            setTimeout(() => { $('#cmbSolicitante').dropdown('set selected', requerimiento.SolicitanteId) ; }, 1000);

        },

        error: function () {
            alert('Error al cargar los datos de la información');
        }
    });


}
function PreparaEliminaRequerimiento(id) {
    $('#hidRequerimiento').val(id);

}
function EliminaRequerimiento() {
    $('#btnEliminarRequerimiento').addClass('loading');
    $('#btnEliminarRequerimiento').addClass('disabled');

    id = $('#hidRequerimiento').val();
    $.ajax({
        url: window.urlEliminarRequerimiento,
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
            showMessage('body', 'danger', 'Ocurrió un error al eliminar el requerimiento seleccionado.' + data);
        }
    });
}
function BusquedaFiltro() {
    $('#btnBuscarFiltro').addClass("loading");
    $('#btnBuscarFiltro').addClass("disabled");

    var entity = {
        FechaDesde: $('#txtFiltroFechaDesde').val(),
        FechaHasta: $('#txtFiltroFechaHasta').val(),
        Tipo_Software: $('#cmbFiltroSoftware').val(),
        EmpId: $('#cmbFiltroEmpresa').val(),
        Responsable: $('#cmbFiltroResponsable').val(),
        Estado: $('#cmbFiltroEstado').val(),
    }
    $.ajax({
        url: window.urlBusquedaFiltro,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {

            window.location.href = '/Requerimiento?buscar=1';

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function ObtenerFiltroEmpresas() {

    $.ajax({
        url: window.urlObtenerEmpresas,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroEmpresa').dropdown('clear');
            $('#cmbFiltroEmpresa').empty();
            $('#cmbFiltroEmpresa').append('<option value="-1">[Seleccione empresa]</option>');
            $.each(data,
                function (value, item) {
                    var texto = '<option value="' + item.Id + '">' + item.NombreEmpresa + '</option>';
                    $('#cmbFiltroEmpresa').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las empresas existentes');
        }
    });
}
function ObtenerFiltroTipoSoftware() {

    $.ajax({
        url: window.urlObtenerTipoSoftware,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroSoftware').dropdown('clear');
            $('#cmbFiltroSoftware').empty();
            $('#cmbFiltroSoftware').append('<option value="-1">[Seleccione software]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.TipoSoftware + '</option>';
                    $('#cmbFiltroSoftware').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los software existentes');
        }
    });

}
function ObtenerFiltroResponsable() {

    $.ajax({
        url: window.urlObtenerUsuario,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroResponsable').dropdown('clear');
            $('#cmbFiltroResponsable').empty();
            $('#cmbFiltroResponsable').append('<option value="-1">[Responsable]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.NombreCompleto + '</option>';
                    $('#cmbFiltroResponsable').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los responsables existentes');
        }
    });

}
function ObtenerFiltroEstado() {

    $.ajax({
        url: window.urlObtenerEstado,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroEstado').dropdown('clear');
            $('#cmbFiltroEstado').empty();
            $('#cmbFiltroEstado').append('<option value="-1">[Estado]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.EstadoReque + '</option>';
                    $('#cmbFiltroEstado').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los software existentes');
        }
    });

}
function ObtenerRequerimiento_Numero() {
    $('#btnBuscar').addClass("loading");
    $('#btnBuscar').addClass("disabled");
    $('#btnBuscarNumero').addClass("loading");
    $('#btnBuscarNumero').addClass("disabled");

    var entity = {
        Id: $('#txtNumero').val(),
    }
    $.ajax({
        url: window.urlObtenerRequerimiento_Numero,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {
            if (data != 'errorNumero') {
                window.location.href = '/Requerimiento?buscar=1';
            }
            if (data === 'errorNumero') {
                $('#btnBuscar').removeClass("loading");
                $('#btnBuscar').removeClass("disabled");
                $('#btnBuscarNumero').removeClass("loading");
                $('#btnBuscarNumero').removeClass("disabled");
                $('#divErrorNumero').removeClass("hidden");
            }

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}