var _arrayEstablecimientosAgregados = [];

$(document).ready(function () {

    $('#divEspera').dimmer('show');
    ObtenerEntidad();
    ObtenerRegion();
    ObtenerEstadoFicha();
    ObtenerTipoContratacion();
    ObtenerProveedor();
    ObtenerTipoArchivo();
    ObtenerMotivoContacto();
    ObtenerDetalleCotizacion();
    ObtenerTipoEstablecimiento();
    ObtenerAliasClientes();
    setTimeout(() => { $('#divEspera').dimmer('hide') }, 3000);
});

function ObtenerEntidad() {

    $.ajax({
        url: window.urlObtenerEntidad,
        type: 'POST',
        success: function (data) {
            $('#cmbC_D').dropdown('clear');
            $('#cmbC_D').empty();
            $('#cmbC_D').append('<option value="-1">[Seleccione entidad]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Entidades + '</option>';
                    $('#cmbC_D').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las entidades existentes');
        }
    });

}
function ObtenerDetalleCotizacion() {

    $.ajax({
        url: window.urlObtenerDetalleCotizacion,
        type: 'POST',
        success: function (data) {
            $('#cmbDetalleCotizacion').dropdown('clear');
            $('#cmbDetalleCotizacion').empty();
            $('#cmbDetalleCotizacion').append('<option value="-1">[Seleccione entidad]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Detalle_Cotizacion + '</option>';
                    $('#cmbDetalleCotizacion').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las entidades existentes');
        }
    });

}
function ObtenerMotivoContacto() {

    $.ajax({
        url: window.urlObtenerMotivoContacto,
        type: 'POST',
        success: function (data) {
            $('#cmbMotivo').dropdown('clear');
            $('#cmbMotivo').empty();
            $('#cmbMotivo').append('<option value="-1">[Seleccione motivo]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Motivo_Contacto + '</option>';
                    $('#cmbMotivo').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las entidades existentes');
        }
    });

}
function ObtenerRegion() {

    $.ajax({
        url: window.urlObtenerRegion,
        type: 'POST',
        success: function (data) {
            $('#cmbRegion').dropdown('clear');
            $('#cmbRegion').empty();
            $('#cmbRegion').append('<option value="-1">[Seleccione región]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Region + '</option>';
                    $('#cmbRegion').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las regiones existentes');
        }
    });

}
function ObtenerEstadoFicha() {

    $.ajax({
        url: window.urlObtenerEstadoFicha,
        type: 'POST',
        success: function (data) {
            $('#cmbEstado').dropdown('clear');
            $('#cmbEstado').empty();
            $('#cmbEstado').append('<option value="-1">[Seleccione estado]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Estado + '</option>';
                    $('#cmbEstado').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los estados existentes');
        }
    });

}
function ObtenerTipoContratacion() {

    $.ajax({
        url: window.urlObtenerTipoContratacion,
        type: 'POST',
        success: function (data) {
            $('#cmbLicitacion').dropdown('clear');
            $('#cmbLicitacion').empty();
            $('#cmbLicitacion').append('<option value="-1">[Seleccione tipo contratación]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Tipo + '</option>';
                    $('#cmbLicitacion').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los estados existentes');
        }
    });

}
function ObtenerProveedor() {

    $.ajax({
        url: window.urlObtenerProveedor,
        type: 'POST',
        success: function (data) {
            $('#cmbProveedor').dropdown('clear');
            $('#cmbProveedor').empty();
            $('#cmbProveedor').append('<option value="-1">[Seleccione tipo de proveedor]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Proveedor + '</option>';
                    $('#cmbProveedor').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los proveedores');
        }
    });

}
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
function ObtenerAliasClientes() {

    $.ajax({
        url: window.urlObtenerAliasClientes,
        type: 'POST',
        success: function (data) {
            $('#cmbFiltroCliente').dropdown('clear');
            $('#cmbFiltroCliente').empty();
            $('#cmbFiltroCliente').append('<option value="-1">[Seleccione cliente]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Alias + '</option>';
                    $('#cmbFiltroCliente').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar los clientes existentes');
        }
    });

}
function GuardarFicha() {

    if (ValidaGuardar() == false)

        return;

    $('#btnGuardaFicha').addClass('loading');
    $('#btnGuardaFicha').addClass('disabled');

    var strParams = {
        //Datos cliente y gestión adquisición
        Id: $('#hidFicha').val(),
        Reg_Id: $('#cmbRegion').val(),
        Comuna: $('#txtComuna').val(),
        Razon_Social: $('#txtRazonSocial').val(),
        Direccion: $('#txtDireccion').val(),
        Rut: $('#txtRut').val(),
        Entidad_Id: $('#cmbC_D').val(),
        Estado_Id: $('#cmbEstado').val(),
        //Datos Cotización
        NumeroCotizacion: $('#txtNCotización').val(),
        Fecha_Ingreso_Coti: $('#txtFechaIngresoCoti').val(),
        NombreCompletoCoti: $('#txtNombreCompletoCoti').val(),
        CorreoCoti: $('#txtCorreoCoti').val(),
        TelefonoCoti: $('#txtTeléfonoCoti').val(),
        FechaVigenciaCoti: $('#txtFechaVigenciaCoti').val(),
        Detalle_Cotizacion_Id: $('#cmbDetalleCotizacion').val(),
        Observacion_cotizacion: $('#txtObservacionCotizacion').val(),

        //Implementacion_UF_Peso: $('#idUF_PesoIM').val(),
        //Implementacion_Valor: $('#txtValorIM').val(),
        //Adaptacion_UF_Peso: $('#idUF_PesoAD').val(),
        //Adaptacion_Valor: $('#txtValorAD').val(),
        //Tarifa_Uso_UF_Peso: $('#idUF_PesoTA').val(),
        //Tarifa_Uso_Valor: $('#TxtValorTA').val(),
        //Usuario_UF_peso: $('#idUF_PesoUS').val(),
        //Usuario_Valor: $('#TxtValorUS').val(),
        //Fraccionamiento_UF_Peso: $('#idUF_PesoFRA').val(),
        //Fraccionamiento_Valor: $('#TxtValorFRA').val(),
        //Integracion_UF_Peso: $('#idUF_PesoINT').val(),
        //Integracion_Valor: $('#TxtValorINT').val(),
        //Boleta_electronica_UF_Peso: $('#idUF_PesoBE').val(),
        //Boleta_electronica_Valor: $('#TxtValorBE').val(),
        //Punto_Venta_Simple_UF_Peso: $('#idUF_PesoPVS').val(),
        //Punto_Venta_Simple_Valor: $('#TxtValorptv').val(),

        
        //Datos Contratación
        Numero_Contratacion: $('#TxtNumeroContra').val(),
        Tipo_Contratacion_Id: $('#cmbLicitacion').val(),
        Meses_Duracion: $('#txtMesesDuracion').val(),
        Fecha_Inicio: $('#TxtFechaIniCon').val(),
        Fecha_Termino: $('#TxtFechaTerCon').val(),
        Numero_Oc: $('#TxtOrdenC').val(),
        Fecha_Termino_Oc: $('#TxtFechaTermOc').val(),
        Total_Neto: $('#TxtTotalNeto').val(),
        Iva: $('#txtIVA').val(),
        Bruto: $('#txtBruto').val(),
        Boleta_Electronica: $('#idBE').val(),
        Prov_Be_Id: $('#cmbProveedor').val(),
        Fraccionamiento: $('#idFRA').val(),
        Sucursal_Farmacia: $('#idSucursalFarmacia').val(),
        Cant_Sucursal_Farmacia: $('#txtCantidadSucursalFarmacia').val(),
        Sucursal_Drogueria: $('#idSucursalDrogueria').val(),
        Cant_Sucursal_Drogueria: $('#txtCantidadSucursalDrogueria').val(),
        Venta_Simple: $('#idVS').val(),
        Cant_Puntos_Venta_Simple: $('#txtCPTV').val(),
        Nombre_Establecimiento: $('#txtNombreEstablecimiento').val(),
        Be_Iva: $('#idBAE').val(),
        Total_Contratado_UF: $('#txtTotalUf').val(),
        Total_Contratado_Peso: $('#txtTotalPeso').val(),
        Observacion: $('#txtObservación').val(),
        //Datos Contacto
        FDP_Nombre: $('#txtNombreCFDP').val(),
        FDP_Cargo: $('#TxtCargoCFDP').val(),
        FDP_Correo: $('#TxtCorreoCFDP').val(),
        FDP_Telefono: $('#TxtTeléfonoCFDP').val(),
        Informatica_Nombre: $('#txtNombreInfo').val(),
        Informatica_Cargo: $('#TxtCargoInfo').val(),
        Informatica_Correo: $('#TxtCorreoInfo').val(),
        Informatica_Telefono: $('#TxtTeléfonoInfo').val(),
        Contabilidad_Nombre: $('#TxtNombreConta').val(),
        Contabilidad_Cargo: $('#TxtCargoConta').val(),
        Contabilidad_Correo: $('#TxtCorreoConta').val(),
        Contabilidad_Telefono: $('#TxtTeléfonoConta').val(),
        Facturacion_Nombre: $('#TxtNombreFact').val(),
        Facturacion_Cargo: $('#TxtCargoFact').val(),
        Facturacion_Correo: $('#TxtCorreoFact').val(),
        Facturacion_Telefono: $('#TxtTeléfonoFact').val(),

        //Ultimo Contacto
        FechaContacto: $('#txtFechaContacto').val(),
        Motivo_Contacto_Id: $('#cmbMotivo').val(),
        Estado_Contacto: $('#idEstadoContacto').val(),
        Detalle_Contacto: $('#txtDetalleContacto').val(),
    };
    $.ajax({
        url: window.urlGuardarFicha,
        type: 'POST',
        data: strParams,
        dataType: "json",
        success: function (data) {
            if (data === 'exito') {
                $('#DivMessajeErrorGeneral').addClass("hidden");
                $('#divExito').removeClass("hidden");
                setTimeout(() => { window.location.href = '/FichaCliente?actualizar=1'; }, 1000);
            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar el comentario. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function LimpiaEstilosGuardar() {
    //Limpio el estilo Error antes de validar
    $('#divcmbRegion').removeClass("error");
    $('#divTxtComuna').removeClass("error");
    $('#divtxtRazonSocial').removeClass("error");
    $('#divtxtRut').removeClass("error");
    $('#divTxtDireccion').removeClass("error");
    $('#divcmbC_D').removeClass("error");
    $('#divcmbEstado').removeClass("error");
    $('#divtxtNombreCompletoCoti').removeClass("error");
    $('#divcmbLicitacion').removeClass("error");
    $('#divcmbProveedor').removeClass("error");
    $('#DivMessajeErrorGeneral').addClass("hidden");
}
function ValidaGuardar() {
    var esValido = true;
    var errores = [];

    LimpiaEstilosGuardar();

    if ($('#cmbRegion').val() === '-1') {
        $('#divcmbRegion').addClass('error');
        errores.push('Debe indicar la región')
    }
    if ($('#txtComuna').val() === '') {
        $('#divTxtComuna').addClass("error");
        errores.push('Debe indicar la comuna');
    }
    if ($('#txtRazonSocial').val() === '') {
        $('#divtxtRazonSocial').addClass("error");
        errores.push('Debe indicar la razón social');
    }
    if ($('#txtRut').val() === '') {
        $('#divtxtRut').addClass("error");
        errores.push('Debe indicar el rut del cliente');
    }
    if ($('#txtDireccion').val() === '') {
        $('#divTxtDireccion').addClass("error");
        errores.push('Debe indicar la dirección');
    }
    if ($('#cmbC_D').val() === '-1') {
        $('#divcmbC_D').addClass('error');
        errores.push('Debe completar el campo C/D')
    }
    if ($('#cmbEstado').val() === '-1') {
        $('#divcmbEstado').addClass('error');
        errores.push('Debe indicar el estado del cliente')
    }
    if ($('#txtNombreCompletoCoti').val() === '') {
        $('#divtxtNombreCompletoCoti').addClass("error");
        errores.push('Debe indicar el nombre completo en los datos de cotización');
    }
    if ($('#txtNombreCompletoCoti').val() === '') {
        $('#divtxtNombreCompletoCoti').addClass("error");
        errores.push('Debe indicar el nombre completo en los datos de cotización');
    }
    if ($('#cmbLicitacion').val() === '-1') {
        $('#divcmbLicitacion').addClass('error');
        errores.push('Debe indicar si es licitación o trato directo')
    }
    if ($('#cmbProveedor').val() === '-1') {
        $('#divcmbProveedor').addClass('error');
        errores.push('Debe indicar el proveedor en los datos de contratación')
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
function AgregarEstablecimiento() {

    if (ValidaAgregar() === false) {
        //alert('no valido');
        return;
    }

    var DetalleEstablecimiento = {
        NombreEstablecimiento: $('#txtNombreEstablecimiento').val(),
        BE_Afecta_IVA: $('#idBAE').val(),
    };

    $.ajax({
        url: window.urlAgregarEstablecimiento,
        type: 'POST',
        data: { entity: DetalleEstablecimiento },
        success: function (data) {
            if (data === 'exito') {
                _arrayEstablecimientosAgregados.push(DetalleEstablecimiento);
                document.getElementById("txtNombreEstablecimiento").value = "";
                $('#cmbBAE').dropdown('clear');
                PintaGrid();
            }

        },
        error: function (ex) {
            alert('Error al guardar el producto');
        }
    });

}
function LimpiaEstilosAgregar() {
    //Limpio el estilo Error antes de validar
    $('#divtxtNombreEstablecimiento').removeClass("error");
    $('#divcmbBAE').removeClass("error");
    $('#DivMessajeErrorGeneralAgregar').addClass("hidden");
}
function ValidaAgregar() {
    var esValido = true;
    var errores = [];

    LimpiaEstilosAgregar();

    if ($('#txtNombreEstablecimiento').val() === '') {
        $('#divtxtNombreEstablecimiento').addClass("error");
        errores.push('Debe indicar el nombre del establecimiento');
    }
    if ($('#idBAE').val() === '') {
        $('#divcmbBAE').addClass("error");
        errores.push('Debe seleccionar si es Afecta o exenta de IVA');
    }

    if (errores.length > 0) {
        var mensaje = '';
        $('#DivMessajeErrorGeneralAgregar').removeClass("hidden");

        for (i = 0; i < errores.length; i++) {
            mensaje += '<li>' + errores[i] + '</li>';
        }

        mensaje += '</ul>';
        $('#listMessajeErrorAgregar').empty();

        $('#listMessajeErrorAgregar').prepend(mensaje);

        // showMessage('#divMensajeNuevoCamion', 'danger', mensaje);
        return false;
    }
    else {
        return true;
    }


}
function PintaGrid() {
    var tabla = "<table class='ui celled table table-striped'>";
    tabla = tabla + "<thead><tr><th> </th><th>Nombre establecimiento</th><th>Es afecta a IVA</th></tr></thead>";
    tabla = tabla + "<tbody>";
    $.each(_arrayEstablecimientosAgregados, function (value, item) {
        tabla = tabla + "<tr>";
        tabla = tabla + "<td>" + "" + "</td><td>" + item.NombreEstablecimiento + "</td><td>" + item.BE_Afecta_IVA + "</td>";
        tabla = tabla + "</tr>";
    });

    $('#grdDatos').html(tabla);
}
function PreparaEliminaFicha(id) {
    $('#hidFicha').val(id);
}
function EliminarFicha() {
    var idFicha = $('#hidFicha').val();

    $.ajax({
        url: window.urlEliminarFicha,
        type: 'POST',
        data: { idFicha: idFicha },
        dataType: "json",
        success: function (resultado) {
            if (resultado == 'ok') {
                {
                    location.reload();
                }


            }
        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}
function PreparaAnexar(id) {
    $('#hidFicha').val(id);
    PintaArchivos(id);
}
function PintaArchivos(id) {
    var idFicha = $('#hidFicha').val();

    $.ajax({
        url: window.urlObtenerArchivos,
        type: 'POST',
        data: { id: idFicha },
        dataType: "json",
        success: function (resultado) {
            var tabla = "<table class='ui celled table table-striped'>";
            tabla = tabla + "<thead><tr><th style='width: 150px'>Tipo archivo</th><th style='width: 150px'>Nombre archivo</th><th>Observación</th></tr></thead>";
            tabla = tabla + "<tbody>";
            $.each(resultado, function (value, item) {
                tabla = tabla + "<tr>";
                tabla = tabla + "<td>" + item.TipoArchivo + "</td><td><a href=/Uploads/" + item.Ruta + " target='_blank'>" + item.Nombre + "  </a></td><td>" + item.Observacion + "</td>";
                tabla = tabla + "</tr>";
            });

            $('#grdArchivos').html(tabla);



        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });
}
function UploadFicha() {

    if (ValidaAnexar() == false)

        return;
    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {

        var fileUpload = $("#fileAnexo").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        var id = $("#hidFicha").val();
        var TiarId = $('#cmbTipoArchivo').val();
        var Observacion = $('#txtObservacion').val();

        // Adding one more key to FormData object  
        fileData.append('username', 'Manas');

        $.ajax({
            url: '/FichaCliente/UploadFiles?id=' + id + '&tiarId=' + TiarId + '&observacion=' + Observacion,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                location.reload();
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
    } else {
        alert("FormData is not supported.");
    }
}
function ObtenerTipoArchivo() {

    $.ajax({
        url: window.urlObtenerTipoArchivo,
        type: 'POST',
        success: function (data) {
            $('#cmbTipoArchivo').dropdown('clear');
            $('#cmbTipoArchivo').empty();
            $('#cmbTipoArchivo').append('<option value="-1">[Seleccione tipo de archivo]</option>');
            $.each(data,
                function (value, item) {

                    var texto = '<option value="' + item.Id + '">' + item.Descripcion + '</option>';
                    $('#cmbTipoArchivo').append(texto);
                }
            );

        },
        error: function () {
            alert('Error al cargar las entidades existentes');
        }
    });

}
function LimpiaAnexar() {
    //Limpio el estilo Error antes de validar
    $('#divcmbTipoArchivo').removeClass("error");

}
function ValidaAnexar() {
    var esValido = true;
    var errores = [];

    LimpiaAnexar();

    if ($('#cmbTipoArchivo').val() === '-1') {
        $('#divcmbTipoArchivo').addClass('error');
        errores.push('Debe indicar el tipo de archivo')
    }

    if (errores.length > 0) {
        var mensaje = '';
        $('#DivMessajeErrorAnexar').removeClass("hidden");

        for (i = 0; i < errores.length; i++) {
            mensaje += '<li>' + errores[i] + '</li>';
        }

        mensaje += '</ul>';
        $('#listMessajeErrorAnexar').empty();

        $('#listMessajeErrorAnexar').prepend(mensaje);

        // showMessage('#divMensajeNuevoCamion', 'danger', mensaje);
        return false;
    }
    else {
        return true;
    }


}
function PrepararEditarFicha(id) {
    $('#hidFicha').val(id);
}
function EditarFicha() {

    var idFicha = $('#hidFicha').val();

    $.ajax({
        url: window.urlEditarFicha,
        type: 'POST',
        data: { idFicha: idFicha },
        success: function (ficha) {

            
            //Datos de usuario 
           
                $('#txtComuna').val(ficha.Comuna),
                $('#txtRazonSocial').val(ficha.Razon_Social),
                $('#txtRut').val(ficha.Rut),
                $('#txtDireccion').val(ficha.Direccion),
                
                //Datos Cotización
                $('#txtNCotización').val(ficha.NumeroCotizacion),
                $('#txtFechaIngresoCoti').val(ficha.Fecha_Ingreso_Coti_Mostrar),
                $('#txtNombreCompletoCoti').val(ficha.NombreCompletoCoti),
                $('#txtCorreoCoti').val(ficha.NombreCompletoCoti),
                $('#txtTeléfonoCoti').val(ficha.TelefonoCoti),
                    $('#txtFechaVigenciaCoti').val(ficha.Fecha_Vigencia_Coti_Mostrar),
                    $("#cmbDetalleCotizacion").dropdown('set selected', ficha.Detalle_Cotizacion_Id),
                    $('#txtObservacionCotizacion').val(ficha.Observacion_cotizacion),



                //$("#cmbUF_PesoIM").dropdown('set selected', ficha.Implementacion_UF_Peso),
                //$('#txtValorIM').val(ficha.Implementacion_Valor),
                //$("#cmbUF_PesoAD").dropdown('set selected', ficha.Adaptacion_UF_Peso),
                //$('#txtValorAD').val(ficha.Adaptacion_Valor),
                //$("#cmbUF_PesoTA").dropdown('set selected', ficha.Tarifa_Uso_UF_Peso),
                //$('#TxtValorTA').val(ficha.Tarifa_Uso_Valor),
                //$("#cmbUF_PesoUS").dropdown('set selected', ficha.Usuario_UF_peso),
                //$('#TxtValorUS').val(ficha.Usuario_Valor),
                //$("#cmbUF_PesoFRA").dropdown('set selected', ficha.Fraccionamiento_UF_Peso),
                //$('#TxtValorFRA').val(ficha.Fraccionamiento_Valor),
                //$("#cmbUF_PesoINT").dropdown('set selected', ficha.Integracion_UF_Peso),
                //$('#TxtValorINT').val(ficha.Integracion_Valor),
                //$("#cmbUF_PesoBE").dropdown('set selected', ficha.Boleta_electronica_UF_Peso),
                //$('#TxtValorBE').val(ficha.Boleta_electronica_Valor),
                //$("#cmbUF_PesoPVS").dropdown('set selected', ficha.Punto_Venta_Simple_UF_Peso),
                //$('#TxtValorptv').val(ficha.Punto_Venta_Simple_Valor),


                    //Datos contratación
                    $('#TxtNumeroContra').val(ficha.Numero_Contratacion),
                    $('#txtMesesDuracion').val(ficha.Meses_Duracion),
                    $('#TxtFechaIniCon').val(ficha.Fecha_Inicio_Mostrar),
                    $('#TxtFechaTerCon').val(ficha.Fecha_Termino_Mostrar),
                    $('#TxtOrdenC').val(ficha.Numero_Oc),
                    $('#TxtFechaTermOc').val(ficha.Fecha_Termino_Oc_Mostrar),
                    $('#TxtTotalNeto').val(ficha.Total_Neto),
                    $('#txtIVA').val(ficha.Iva),
                    $('#txtBruto').val(ficha.Bruto),
                    $("#cmbBE").dropdown('set selected', ficha.Boleta_Electronica),
                    $("#cmbFRA").dropdown('set selected', ficha.Fraccionamiento),
                    $("#cmbSucursalFarmacia").dropdown('set selected', ficha.Sucursal_Farmacia),
                    $('#txtCantidadSucursalFarmacia').val(ficha.Cant_Sucursal_Farmacia),
                    $("#cmbSucursalDrogueria").dropdown('set selected', ficha.Sucursal_Drogueria),
                    $('#txtCantidadSucursalDrogueria').val(ficha.Cant_Sucursal_Drogueria),
                    $("#cmbVS").dropdown('set selected', ficha.Venta_Simple),
                    $('#txtCPTV').val(ficha.Cant_Puntos_Venta_Simple),
                    $('#txtTotalUf').val(ficha.Total_Contratado_UF),
                    $('#txtTotalPeso').val(ficha.Total_Contratado_Peso),
                    $('#txtObservación').val(ficha.Observacion),

                //Cuarta parte
                $('#txtNombreCFDP').val(ficha.FDP_Nombre),
                $('#TxtCargoCFDP').val(ficha.FDP_Cargo),
                $('#TxtCorreoCFDP').val(ficha.FDP_Correo),
                $('#TxtTeléfonoCFDP').val(ficha.FDP_Telefono),
                $('#txtNombreInfo').val(ficha.Informatica_Nombre),
                $('#TxtCargoInfo').val(ficha.Informatica_Cargo),
                $('#TxtCorreoInfo').val(ficha.Informatica_Correo),
                $('#TxtTeléfonoInfo').val(ficha.Informatica_Telefono),
                $('#TxtNombreConta').val(ficha.Contabilidad_Nombre),
                $('#TxtCargoConta').val(ficha.Contabilidad_Cargo),
                $('#TxtCorreoConta').val(ficha.Contabilidad_Correo),
                $('#TxtTeléfonoConta').val(ficha.Contabilidad_Telefono),
                $('#TxtNombreFact').val(ficha.Facturacion_Nombre),
                $('#TxtCargoFact').val(ficha.Facturacion_Cargo),
                $('#TxtCorreoFact').val(ficha.Facturacion_Correo),
                $('#TxtTeléfonoFact').val(ficha.Facturacion_Telefono),

                //Cargo combos
                setTimeout(() => { $('#cmbRegion').dropdown('set selected', ficha.Reg_Id); }, 2000);
                setTimeout(() => { $('#cmbC_D').dropdown('set selected', ficha.Entidad_Id); }, 2000);
                setTimeout(() => { $('#cmbEstado').dropdown('set selected', ficha.Estado_Id); }, 2000);
                setTimeout(() => { $('#cmbLicitacion').dropdown('set selected', ficha.Tipo_Contratacion_Id); }, 2000);
                setTimeout(() => { $('#cmbProveedor').dropdown('set selected', ficha.Prov_Be_Id); }, 2000);
                PintaEstablecimientos();
           
        },

        error: function () {
            alert('Error al cargar los datos de la ficha');
        }
    });
}
function PintaEstablecimientos() {

    $.ajax({
        url: window.urlObtenerEstablecimientos,
        type: 'POST',
        dataType: "json",
        success: function (resultado) {
            var tabla = "<table class='ui celled table table-striped'>";
            tabla = tabla + "<thead><tr><th> </th><th>Tipo sucursal</th><th>Nombre sucursal</th></tr></thead>";
            tabla = tabla + "<tbody>";
            $.each(resultado, function (value, item) {
                tabla = tabla + "<tr>";
                tabla = tabla + "<td>" + "" + "</td><td>" + item.Tipo_Sucursal + "</td><td>" + item.NombreEstablecimiento + "</td>";
                tabla = tabla + "</tr>";
            });

            $('#grdDatos').html(tabla);



        },

        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });
}
function BusquedaFiltro() {
    $('#btnBuscarFiltro').addClass("loading");
    $('#btnBuscarFiltro').addClass("disabled");

    var entity = {
        Id: $('#cmbFiltroCliente').val(),
    }
    $.ajax({
        url: window.urlBusquedaFiltro,
        type: 'POST',
        data: { entity: entity },
        success: function (data) {

            window.location.href = '/FichaCliente';

        },
        error: function () {
            showMessage('#divMensajePublicacionViaje', 'danger', 'Ocurrió un error al guardar la información. Por favor intente nuevamente.');
            //hideLoading();
        }
    });

}