function GuardarFarmacia() {
    if (ValidaGuardar() == false)
        return;
    

    $('#btnGuardaEmpresa').addClass('disabled');
    $('#btnGuardaEmpresa').addClass('loading');

    var strParams = {
        Id: $('#hidEmpresa').val(),
        Rut: $('#txtRutEmpresa').val(),
        NombreEmpresa: $('#txtNombreEmpresa').val(),
        Alias: $('#txtAlias').val(),
        RazonSocial: $('#txtRazonSocial').val(),
        Direccion: $('#txtDireccion').val(),
        Telefono: $('#txtTelefono').val(),
        Correo: $('#txtCorreo').val(),
        CajaExterno: $('#idCaja').val(),
        EsEtiquetaDispensacion: $('#idFraccionamiento').val(),
        OmitirMedico: $('#idOmitirMedico').val()
    }
    $.ajax({
        url: window.urlGuardarFarmacia,
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

function ValidaGuardar() {
    errores = [];

    $('#divTxtRut').removeClass('error');
    $('#divTxtNombreEmpresa').removeClass('error');
    $('#divTxtAlias').removeClass('error');
    $('#divTxtRazonSocial').removeClass('error');
    $('#divTxtDireccion').removeClass('error');
    $('#divTxtTelefono').removeClass('error');
    $('#divTxtCorreo').removeClass('error');
    $('#divcmbCaja').removeClass('error');
    $('#divcmbFraccionamiento').removeClass('error');
    $('#divcmbOmitirMedico').removeClass('error');   
    $('#DivMessajeErrorGeneral').addClass('hidden');
   

    if ($('#idCaja').val() === '') {
        $('#divcmbCaja').addClass('error');
        errores.push('Debe indicar caja externo');
    }
    if ($('#idFraccionamiento').val() === '') {
        $('#divcmbFraccionamiento').addClass('error');
        errores.push('Debe indicar si tiene fraccionamiento');
    }
    if ($('#idOmitirMedico').val() === '') {
        $('#divcmbOmitirMedico').addClass('error');
        errores.push('Debe indicar si omite medico');
    }
    if ($('#txtRutEmpresa').val() === '') {
        $('#divTxtRut').addClass('error');
        errores.push('Debe ingresar el rut');
    }
    if ($('#txtNombreEmpresa').val() === '') {
        $('#divTxtNombreEmpresa').addClass('error');
        errores.push('Debe ingresar un nombre');
    }

    if ($('#txtAlias').val() === '') {
        $('#divTxtAlias').addClass('error');
        errores.push('Debe ingresar un alias');
    }
    if ($('#txtRazonSocial').val() === '') {
        $('#divTxtRazonSocial').addClass('error');
        errores.push('Debe ingresar la razón social');
    }
    
    if ($('#txtDireccion').val() === '') {
        $('#divTxtDireccion').addClass('error');
        errores.push('Debe ingresar una dirección');
    }
    if ($('#txtTelefono').val() === '') {
        $('#divTxtTelefono').addClass('error');
        errores.push('Debe indicar un telefono');
    }

    if ($('#txtCorreo').val() === '') {
        $('#divTxtCorreo').addClass('error');
        errores.push('Debe ingresar el correo');
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





function PrepararEditarFarmacia(id) {
    $('#hidEmpresa').val(id);
}
function EditarFarmacia() {

    var idEmpresa = $('#hidEmpresa').val();

    $.ajax({
        url: window.urlEditarFarmacia,
        type: 'POST',
        data: { idEmpresa: idEmpresa },
        success: function (empresa) {

            $('#txtRutEmpresa').val(empresa.Rut),                            
                $('#txtNombreEmpresa').val(empresa.NombreEmpresa),
                $('#txtAlias').val(empresa.Alias),
                $('#txtRazonSocial').val(empresa.RazonSocial),
                $('#txtDireccion').val(empresa.Direccion),
                $('#txtTelefono').val(empresa.Telefono),
                $('#txtCorreo').val(empresa.Correo),
                $("#cmbCaja").dropdown('set selected', empresa.CajaExterno),
                $("#cmbFraccionamiento").dropdown('set selected', empresa.EsEtiquetaDispensacion),
                $("#cmbOmitirMedico").dropdown('set selected', empresa.OmitirMedico)
                
       

        },

        error: function () {
            alert('Error al cargar los datos de la empresa');
        }
    });


}

function PreparaEliminaFarmacia(id) {
    $('#hidEmpresa').val(id);

}
function EliminaFarmacia() {
    $('#btnEliminarEmpresa').addClass('loading');
    $('#btnEliminarEmpresa').addClass('disabled');

    id = $('#hidEmpresa').val();
    $.ajax({
        url: window.urlEliminaFarmacia,
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