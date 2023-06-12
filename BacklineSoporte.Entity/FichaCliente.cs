using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class FichaCliente
    {
        //Primera parte
        public int Id { get; set; }
        public int Reg_Id { get; set; }
        public int Usr_Id { get; set; }
        public string Comuna { get; set; }
        public string Razon_Social { get; set; }
        public string Direccion { get; set; }
        public string Rut { get; set; }
        public int Entidad_Id { get; set; }
        public int Estado_Id { get; set; }
        public bool Eliminada { get; set; }
        public string Region { get; set; }
        public string Entidades { get; set; }

        //Segunda Parte
        public int NumeroCotizacion { get; set; }
        public DateTime Fecha_Ingreso_Coti { get; set; }

        public string Observacion_cotizacion { get; set; }
        public int Detalle_Cotizacion_Id { get; set; }
      


        public string Fecha_Ingreso_Coti_Mostrar
        {
            get
            {
                var dd = Fecha_Ingreso_Coti.Day.ToString("00");
                var mm = Fecha_Ingreso_Coti.Month.ToString("00");
                var yy = Fecha_Ingreso_Coti.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public string NombreCompletoCoti { get; set; }
        public string CorreoCoti { get; set; }
        public int TelefonoCoti { get; set; }
        public DateTime FechaVigenciaCoti { get; set; }
        public string Fecha_Vigencia_Coti_Mostrar
        {
            get
            {
                var dd = FechaVigenciaCoti.Day.ToString("00");
                var mm = FechaVigenciaCoti.Month.ToString("00");
                var yy = FechaVigenciaCoti.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public int Implementacion_UF_Peso { get; set; }
        public int Implementacion_Valor { get; set; }
        public int Adaptacion_UF_Peso { get; set; }
        public int Adaptacion_Valor { get; set; }
        public int Tarifa_Uso_UF_Peso { get; set; }
        public int Tarifa_Uso_Valor { get; set; }
        public int Usuario_UF_peso { get; set; }
        public int Usuario_Valor { get; set; }
        public int Fraccionamiento_UF_Peso { get; set; }
        public int Fraccionamiento_Valor { get; set; }
        public int Integracion_UF_Peso { get; set; }
        public int Integracion_Valor { get; set; }
        public int Boleta_electronica_UF_Peso { get; set; }
        public int Boleta_electronica_Valor { get; set; }
        public int Punto_Venta_Simple_UF_Peso { get; set; }
        public int Punto_Venta_Simple_Valor { get; set; }

        //Tercera parte
        public int Prov_Be_Id { get; set; }

        public bool Afecta_Iva { get; set; }
        public int Tipo_Contratacion_Id { get; set; }
        public string Numero_Contratacion { get; set; }
        public int Meses_Duracion { get; set; }
        public DateTime Fecha_Inicio { get; set; }

        public string Fecha_Inicio_Mostrar
        {
            get
            {
                var dd = Fecha_Inicio.Day.ToString("00");
                var mm = Fecha_Inicio.Month.ToString("00");
                var yy = Fecha_Inicio.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }

        public DateTime Fecha_Termino { get; set; }

        public string Fecha_Termino_Mostrar
        {
            get
            {
                var dd = Fecha_Termino.Day.ToString("00");
                var mm = Fecha_Termino.Month.ToString("00");
                var yy = Fecha_Termino.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public string Numero_Oc { get; set; }
        public DateTime Fecha_Termino_Oc { get; set; }

        public string Fecha_Termino_Oc_Mostrar
        {
            get
            {
                var dd = Fecha_Termino_Oc.Day.ToString("00");
                var mm = Fecha_Termino_Oc.Month.ToString("00");
                var yy = Fecha_Termino_Oc.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }


        public int Total_Neto { get; set; }
        public int Iva { get; set; }
        public int Bruto { get; set; }
        public bool Boleta_Electronica { get; set; }
        public bool Fraccionamiento { get; set; }
        public bool Venta_Simple { get; set; }
        public int Cant_Puntos_Venta_Simple { get; set; }
        public string Nombre_Establecimiento { get; set; }
        public bool Be_Iva { get; set; }
        public int Total_Contratado_UF { get; set; }
        public int Total_Contratado_Peso { get; set; }
        public string Observacion { get; set; }

        //Cuarta parte
        public string FDP_Nombre { get; set; }
        public string FDP_Cargo { get; set; }
        public string FDP_Correo { get; set; }
        public int FDP_Telefono { get; set; }
        public string Informatica_Nombre { get; set; }
        public string Informatica_Cargo { get; set; }
        public string Informatica_Correo { get; set; }
        public int Informatica_Telefono { get; set; }
        public string Contabilidad_Nombre { get; set; }
        public string Contabilidad_Cargo { get; set; }
        public string Contabilidad_Correo { get; set; }
        public int Contabilidad_Telefono { get; set; }
        public string Facturacion_Nombre { get; set; }
        public string Facturacion_Cargo { get; set; }
        public string Facturacion_Correo { get; set; }
        public int Facturacion_Telefono { get; set; }
        public bool Editar { get; set; }

        //Quinta Parte
        public int Id_Ultimo_Contacto { get; set; }
        public DateTime FechaContacto { get; set; }
        public string Fecha_Contacto_Mostrar
        {
            get
            {
                var dd = FechaContacto.Day.ToString("00");
                var mm = FechaContacto.Month.ToString("00");
                var yy = FechaContacto.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public int Motivo_Contacto_Id {get; set;}
        public string Motivo_Contacto { get; set; }
        public string Detalle_Contacto { get; set; }
        public int Estado_Contacto { get; set; }
        public string Persona_Contactada { get; set; }
        public string Correo_Contacto { get; set; }
        public string MotivoContactoStr { get; set; }
        public string EstadoContactoStr { get; set; }
    }
}
