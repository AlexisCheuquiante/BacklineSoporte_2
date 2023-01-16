using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace BacklineSoporte.DAL
{
    public class FichaClienteDAL
    {
        public static List<Entity.FichaCliente> ObtenerFicha(Entity.Filtro filtro)
        {
            List<Entity.FichaCliente> listaRetorno = new List<Entity.FichaCliente>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FICH_FICHA_CLIENTE_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int REG_ID = reader.GetOrdinal("REG_ID");
                int COMUNA = reader.GetOrdinal("COMUNA");
                int RAZON_SOCIAL = reader.GetOrdinal("RAZON_SOCIAL");
                int RUT = reader.GetOrdinal("RUT");
                int DIRECCION = reader.GetOrdinal("DIRECCION");
                int ENTIDAD_ID = reader.GetOrdinal("ENTIDAD_ID");
                int ESTADO_ID = reader.GetOrdinal("ESTADO_ID");
                int REGION = reader.GetOrdinal("REGION");
                int ENTIDADES = reader.GetOrdinal("ENTIDADES");                
                int TIPO_CONTRATACION_ID = reader.GetOrdinal("TIPO_CONTRATACION_ID");               
                //Segunda parte
                int NUMERO_COTIZACION = reader.GetOrdinal("NUMERO_COTIZACION");
                int FECHA_INGRESO = reader.GetOrdinal("FECHA_INGRESO");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int CORREO = reader.GetOrdinal("CORREO");
                int TELEFONO = reader.GetOrdinal("TELEFONO");
                int FECHA_VIGENCIA = reader.GetOrdinal("FECHA_VIGENCIA");
                int IMPLEMENTACION_UF_PESO = reader.GetOrdinal("IMPLEMENTACION_UF_PESO");
                int IMPLEMENTACION_VALOR = reader.GetOrdinal("IMPLEMENTACION_VALOR");
                int ADAPTACION_UF_PESO = reader.GetOrdinal("ADAPTACION_UF_PESO");
                int ADAPTACION_VALOR = reader.GetOrdinal("ADAPTACION_VALOR");
                int TARIFA_USO_UF_PESO = reader.GetOrdinal("TARIFA_USO_UF_PESO");
                int TARIFA_USO_VALOR = reader.GetOrdinal("TARIFA_USO_VALOR");
                int USUARIO_UF_PESO = reader.GetOrdinal("USUARIO_UF_PESO");
                int USUARIO_VALOR = reader.GetOrdinal("USUARIO_VALOR");
                int FRACCIONAMIENTO_UF_PESO = reader.GetOrdinal("FRACCIONAMIENTO_UF_PESO");
                int FRACCIONAMIENTO_VALOR = reader.GetOrdinal("FRACCIONAMIENTO_VALOR");
                int INTEGRACION_UF_PESO = reader.GetOrdinal("INTEGRACION_UF_PESO");
                int INTEGRACION_VALOR = reader.GetOrdinal("INTEGRACION_VALOR");
                int BOLETA_ELECTRONICA_UF_PESO = reader.GetOrdinal("BOLETA_ELECTRONICA_UF_PESO");
                int BOLETA_ELECTRONICA_VALOR = reader.GetOrdinal("BOLETA_ELECTRONICA_VALOR");
                int PUNTO_VENT_SIMPLE_UF_PESO = reader.GetOrdinal("PUNTO_VENT_SIMPLE_UF_PESO");
                int PUNTO_VENT_SIMPLE_VALOR = reader.GetOrdinal("PUNTO_VENT_SIMPLE_VALOR");
                //TERCERA PARTE
                int PROV_BE_ID = reader.GetOrdinal("PROV_BE_ID");
                int NUMERO_CONTRATACION = reader.GetOrdinal("NUMERO_CONTRATACION");
                int MESES_DURACION = reader.GetOrdinal("MESES_DURACION");
                int FECHA_INICIO = reader.GetOrdinal("FECHA_INICIO");
                int FECHA_TERMINO = reader.GetOrdinal("FECHA_TERMINO");
                int NUMERO_OC = reader.GetOrdinal("NUMERO_OC");
                int FECHA_TERMINO_OC = reader.GetOrdinal("FECHA_TERMINO_OC");
                int TOTAL_NETO = reader.GetOrdinal("TOTAL_NETO");
                int IVA = reader.GetOrdinal("IVA");
                int BRUTO = reader.GetOrdinal("BRUTO");
                int BOLETA_ELECTRONICA = reader.GetOrdinal("BOLETA_ELECTRONICA");
                int FRACCIONAMIENTO = reader.GetOrdinal("FRACCIONAMIENTO");
                int VENTA_SIMPLE = reader.GetOrdinal("VENTA_SIMPLE");
                int CANT_PUNTOS_VENTA_SIMPLE = reader.GetOrdinal("CANT_PUNTOS_VENTA_SIMPLE");
                int NOMBRE_ESTABLECIMIENTO = reader.GetOrdinal("NOMBRE_ESTABLECIMIENTO");
                int BE_IVA = reader.GetOrdinal("BE_IVA");
                int TOTAL_CONTRATADO_UF = reader.GetOrdinal("TOTAL_CONTRATADO_UF");
                int TOTAL_CONTRATADO_PESO = reader.GetOrdinal("TOTAL_CONTRATADO_PESO");
                int OBSERVACION = reader.GetOrdinal("OBSERVACION");
                //Cuarta Parte
                int FDP_NOMBRE = reader.GetOrdinal("FDP_NOMBRE");
                int FDP_CARGO = reader.GetOrdinal("FDP_CARGO");
                int FDP_CORREO = reader.GetOrdinal("FDP_CORREO");
                int FDP_TELEFONO = reader.GetOrdinal("FDP_TELEFONO");
                int INFORMATICA_NOMBRE = reader.GetOrdinal("INFORMATICA_NOMBRE");
                int INFORMATICA_CARGO = reader.GetOrdinal("INFORMATICA_CARGO");
                int INFORMATICA_CORREO = reader.GetOrdinal("INFORMATICA_CORREO");
                int INFORMATICA_TELEFONO = reader.GetOrdinal("INFORMATICA_TELEFONO");
                int CONTABILIDAD_NOMBRE = reader.GetOrdinal("CONTABILIDAD_NOMBRE");
                int CONTABILIDAD_CARGO = reader.GetOrdinal("CONTABILIDAD_CARGO");
                int CONTABILIDAD_CORREO = reader.GetOrdinal("CONTABILIDAD_CORREO");
                int CONTABILIDAD_TELEFONO = reader.GetOrdinal("CONTABILIDAD_TELEFONO");
                int FACTURACION_NOMBRE = reader.GetOrdinal("FACTURACION_NOMBRE");
                int FACTURACION_CARGO = reader.GetOrdinal("FACTURACION_CARGO");
                int FACTURACION_CORREO = reader.GetOrdinal("FACTURACION_CORREO");
                int FACTURACION_TELEFONO = reader.GetOrdinal("FACTURACION_TELEFONO");


                while (reader.Read())
                {
                    Entity.FichaCliente fichaCliente = new Entity.FichaCliente();
                    fichaCliente.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    fichaCliente.Reg_Id = (int)(reader.IsDBNull(REG_ID) == false ? reader.GetValue(REG_ID) : "");
                    fichaCliente.Comuna = (string)(reader.IsDBNull(COMUNA) == false ? reader.GetValue(COMUNA) : "");
                    fichaCliente.Razon_Social = (string)(reader.IsDBNull(RAZON_SOCIAL) == false ? reader.GetValue(RAZON_SOCIAL) : "");
                    fichaCliente.Rut = (string)(reader.IsDBNull(RUT) == false ? reader.GetValue(RUT) : "");
                    fichaCliente.Entidad_Id = (int)(reader.IsDBNull(ENTIDAD_ID) == false ? reader.GetValue(ENTIDAD_ID) : "");
                    fichaCliente.Estado_Id = (int)(reader.IsDBNull(ESTADO_ID) == false ? reader.GetValue(ESTADO_ID) : "");
                    fichaCliente.Entidades = (string)(reader.IsDBNull(ENTIDADES) == false ? reader.GetValue(ENTIDADES) : "");
                    fichaCliente.Region = (string)(reader.IsDBNull(REGION) == false ? reader.GetValue(REGION) : "");                    
                    fichaCliente.Direccion = (string)(reader.IsDBNull(DIRECCION) == false ? reader.GetValue(DIRECCION) : "");

                    //Segunda parte
                    fichaCliente.NumeroCotizacion = (int)(reader.IsDBNull(NUMERO_COTIZACION) == false ? reader.GetValue(NUMERO_COTIZACION) : 0);
                    fichaCliente.Fecha_Ingreso_Coti = (DateTime)(!reader.IsDBNull(FECHA_INGRESO) ? reader.GetValue(FECHA_INGRESO) : DateTime.MinValue);
                    fichaCliente.NombreCompletoCoti = (string)(reader.IsDBNull(NOMBRE_COMPLETO) == false ? reader.GetValue(NOMBRE_COMPLETO) : "");
                    fichaCliente.CorreoCoti = (string)(reader.IsDBNull(CORREO) == false ? reader.GetValue(CORREO) : "");
                    fichaCliente.TelefonoCoti = (int)(reader.IsDBNull(TELEFONO) == false ? reader.GetValue(TELEFONO) : 0);
                    fichaCliente.FechaVigenciaCoti = (DateTime)(!reader.IsDBNull(FECHA_VIGENCIA) ? reader.GetValue(FECHA_VIGENCIA) : DateTime.MinValue);
                    fichaCliente.Implementacion_UF_Peso = (int)(reader.IsDBNull(IMPLEMENTACION_UF_PESO) == false ? reader.GetValue(IMPLEMENTACION_UF_PESO) : 0);
                    fichaCliente.Implementacion_Valor = (int)(reader.IsDBNull(IMPLEMENTACION_VALOR) == false ? reader.GetValue(IMPLEMENTACION_VALOR) : 0);
                    fichaCliente.Adaptacion_UF_Peso = (int)(reader.IsDBNull(ADAPTACION_UF_PESO) == false ? reader.GetValue(ADAPTACION_UF_PESO) : 0);
                    fichaCliente.Adaptacion_Valor = (int)(reader.IsDBNull(ADAPTACION_VALOR) == false ? reader.GetValue(ADAPTACION_VALOR) : 0);
                    fichaCliente.Tarifa_Uso_UF_Peso = (int)(reader.IsDBNull(TARIFA_USO_UF_PESO) == false ? reader.GetValue(TARIFA_USO_UF_PESO) : 0);
                    fichaCliente.Tarifa_Uso_Valor = (int)(reader.IsDBNull(TARIFA_USO_VALOR) == false ? reader.GetValue(TARIFA_USO_VALOR) : 0);
                    fichaCliente.Usuario_UF_peso = (int)(reader.IsDBNull(USUARIO_UF_PESO) == false ? reader.GetValue(USUARIO_UF_PESO) : 0);
                    fichaCliente.Usuario_Valor = (int)(reader.IsDBNull(USUARIO_VALOR) == false ? reader.GetValue(USUARIO_VALOR) : 0);
                    fichaCliente.Fraccionamiento_UF_Peso = (int)(reader.IsDBNull(FRACCIONAMIENTO_UF_PESO) == false ? reader.GetValue(FRACCIONAMIENTO_UF_PESO) : 0);
                    fichaCliente.Fraccionamiento_Valor = (int)(reader.IsDBNull(FRACCIONAMIENTO_VALOR) == false ? reader.GetValue(FRACCIONAMIENTO_VALOR) : 0);
                    fichaCliente.Integracion_UF_Peso = (int)(reader.IsDBNull(INTEGRACION_UF_PESO) == false ? reader.GetValue(INTEGRACION_UF_PESO) : 0);
                    fichaCliente.Integracion_Valor = (int)(reader.IsDBNull(INTEGRACION_VALOR) == false ? reader.GetValue(INTEGRACION_VALOR) : 0);
                    fichaCliente.Boleta_electronica_UF_Peso = (int)(reader.IsDBNull(BOLETA_ELECTRONICA_UF_PESO) == false ? reader.GetValue(BOLETA_ELECTRONICA_UF_PESO) : 0);
                    fichaCliente.Boleta_electronica_Valor = (int)(reader.IsDBNull(BOLETA_ELECTRONICA_VALOR) == false ? reader.GetValue(BOLETA_ELECTRONICA_VALOR) : 0);
                    fichaCliente.Punto_Venta_Simple_UF_Peso = (int)(reader.IsDBNull(PUNTO_VENT_SIMPLE_UF_PESO) == false ? reader.GetValue(PUNTO_VENT_SIMPLE_UF_PESO) : 0);
                    fichaCliente.Punto_Venta_Simple_Valor = (int)(reader.IsDBNull(PUNTO_VENT_SIMPLE_VALOR) == false ? reader.GetValue(PUNTO_VENT_SIMPLE_VALOR) : 0);

                    //TERCERA PARTE
                    fichaCliente.Prov_Be_Id = (int)(reader.IsDBNull(PROV_BE_ID) == false ? reader.GetValue(PROV_BE_ID) : -1);
                    fichaCliente.Numero_Contratacion = (string)(reader.IsDBNull(NUMERO_CONTRATACION) == false ? reader.GetValue(NUMERO_CONTRATACION) : "");
                    fichaCliente.Meses_Duracion = (int)(reader.IsDBNull(MESES_DURACION) == false ? reader.GetValue(MESES_DURACION) : 0);
                    fichaCliente.Fecha_Inicio = (DateTime)(!reader.IsDBNull(FECHA_INICIO) ? reader.GetValue(FECHA_INICIO) : DateTime.MinValue);
                    fichaCliente.Fecha_Termino = (DateTime)(!reader.IsDBNull(FECHA_TERMINO) ? reader.GetValue(FECHA_TERMINO) : DateTime.MinValue);
                    fichaCliente.Numero_Oc = (string)(reader.IsDBNull(NUMERO_OC) == false ? reader.GetValue(NUMERO_OC) : "");
                    fichaCliente.Fecha_Termino_Oc = (DateTime)(!reader.IsDBNull(FECHA_TERMINO_OC) ? reader.GetValue(FECHA_TERMINO_OC) : DateTime.MinValue);
                    fichaCliente.Total_Neto = (int)(reader.IsDBNull(TOTAL_NETO) == false ? reader.GetValue(TOTAL_NETO) : 0);
                    fichaCliente.Iva = (int)(reader.IsDBNull(IVA) == false ? reader.GetValue(IVA) : 0);
                    fichaCliente.Bruto = (int)(reader.IsDBNull(BRUTO) == false ? reader.GetValue(BRUTO) : 0);
                    fichaCliente.Boleta_Electronica = (bool)(reader.IsDBNull(BOLETA_ELECTRONICA) == false ? reader.GetValue(BOLETA_ELECTRONICA) : false);
                    fichaCliente.Fraccionamiento = (bool)(reader.IsDBNull(FRACCIONAMIENTO) == false ? reader.GetValue(FRACCIONAMIENTO) : false);
                    fichaCliente.Venta_Simple = (bool)(reader.IsDBNull(VENTA_SIMPLE) == false ? reader.GetValue(VENTA_SIMPLE) : false);
                    fichaCliente.Cant_Puntos_Venta_Simple = (int)(reader.IsDBNull(CANT_PUNTOS_VENTA_SIMPLE) == false ? reader.GetValue(CANT_PUNTOS_VENTA_SIMPLE) : 0);
                    fichaCliente.Total_Contratado_UF = (int)(reader.IsDBNull(TOTAL_CONTRATADO_UF) == false ? reader.GetValue(TOTAL_CONTRATADO_UF) : 0);
                    fichaCliente.Total_Contratado_Peso = (int)(reader.IsDBNull(TOTAL_CONTRATADO_PESO) == false ? reader.GetValue(TOTAL_CONTRATADO_PESO) : 0);
                    fichaCliente.Observacion = (string)(reader.IsDBNull(OBSERVACION) == false ? reader.GetValue(OBSERVACION) : "");
                    fichaCliente.Tipo_Contratacion_Id = (int)(reader.IsDBNull(TIPO_CONTRATACION_ID) == false ? reader.GetValue(TIPO_CONTRATACION_ID) : 0);
                    //Cuarta Parte
                    fichaCliente.FDP_Nombre = (string)(reader.IsDBNull(FDP_NOMBRE) == false ? reader.GetValue(FDP_NOMBRE) : "");
                    fichaCliente.FDP_Cargo = (string)(reader.IsDBNull(FDP_CARGO) == false ? reader.GetValue(FDP_CARGO) : "");
                    fichaCliente.FDP_Correo = (string)(reader.IsDBNull(FDP_CORREO) == false ? reader.GetValue(FDP_CORREO) : "");
                    fichaCliente.FDP_Telefono = (int)(reader.IsDBNull(FDP_TELEFONO) == false ? reader.GetValue(FDP_TELEFONO) : 0);
                    fichaCliente.Informatica_Nombre = (string)(reader.IsDBNull(INFORMATICA_NOMBRE) == false ? reader.GetValue(INFORMATICA_NOMBRE) : "");
                    fichaCliente.Informatica_Cargo = (string)(reader.IsDBNull(INFORMATICA_CARGO) == false ? reader.GetValue(INFORMATICA_CARGO) : "");
                    fichaCliente.Informatica_Correo = (string)(reader.IsDBNull(INFORMATICA_CORREO) == false ? reader.GetValue(INFORMATICA_CORREO) : "");
                    fichaCliente.Informatica_Telefono = (int)(reader.IsDBNull(INFORMATICA_TELEFONO) == false ? reader.GetValue(INFORMATICA_TELEFONO) : 0);
                    fichaCliente.Contabilidad_Nombre = (string)(reader.IsDBNull(CONTABILIDAD_NOMBRE) == false ? reader.GetValue(CONTABILIDAD_NOMBRE) : "");
                    fichaCliente.Contabilidad_Cargo = (string)(reader.IsDBNull(CONTABILIDAD_CARGO) == false ? reader.GetValue(CONTABILIDAD_CARGO) : "");
                    fichaCliente.Contabilidad_Correo = (string)(reader.IsDBNull(CONTABILIDAD_CORREO) == false ? reader.GetValue(CONTABILIDAD_CORREO) : "");
                    fichaCliente.Contabilidad_Telefono = (int)(reader.IsDBNull(CONTABILIDAD_TELEFONO) == false ? reader.GetValue(CONTABILIDAD_TELEFONO) : 0);
                    fichaCliente.Facturacion_Nombre = (string)(reader.IsDBNull(FACTURACION_NOMBRE) == false ? reader.GetValue(FACTURACION_NOMBRE) : "");
                    fichaCliente.Facturacion_Cargo = (string)(reader.IsDBNull(FACTURACION_CARGO) == false ? reader.GetValue(FACTURACION_CARGO) : "");
                    fichaCliente.Facturacion_Correo = (string)(reader.IsDBNull(FACTURACION_CORREO) == false ? reader.GetValue(FACTURACION_CORREO) : "");
                    fichaCliente.Facturacion_Telefono = (int)(reader.IsDBNull(FACTURACION_TELEFONO) == false ? reader.GetValue(FACTURACION_TELEFONO) : 0);

                    listaRetorno.Add(fichaCliente);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }

        public static BacklineSoporte.Entity.FichaCliente GuardaFicha(BacklineSoporte.Entity.FichaCliente fichaCliente)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FICH_FICHA_CLIENTE_INS");


            db.AddInParameter(dbCommand, "ID", DbType.Int32, fichaCliente.Id);
            db.AddInParameter(dbCommand, "USR_ID", DbType.Int32, fichaCliente.Usr_Id != 0 ? fichaCliente.Usr_Id : (object)null);
            db.AddInParameter(dbCommand, "REG_ID", DbType.Int32, fichaCliente.Reg_Id != 0 ? fichaCliente.Reg_Id : (object)null);
            db.AddInParameter(dbCommand, "COMUNA", DbType.String, fichaCliente.Comuna.ToUpper() != "" ? fichaCliente.Comuna : (object)null); 
            db.AddInParameter(dbCommand, "RAZON_SOCIAL", DbType.String, fichaCliente.Razon_Social.ToUpper() != "" ? fichaCliente.Razon_Social : (object)null);
            db.AddInParameter(dbCommand, "DIRECCION", DbType.String, fichaCliente.Direccion.ToUpper() != "" ? fichaCliente.Razon_Social : (object)null);
            db.AddInParameter(dbCommand, "RUT", DbType.String, fichaCliente.Rut.ToUpper() != "" ? fichaCliente.Rut : (object)null);
            db.AddInParameter(dbCommand, "ENTIDAD_ID", DbType.Int32, fichaCliente.Entidad_Id != 0 ? fichaCliente.Entidad_Id : (object)null);
            db.AddInParameter(dbCommand, "ESTADO_ID", DbType.Int32, fichaCliente.Estado_Id != 0 ? fichaCliente.Estado_Id : (object)null);
            db.AddInParameter(dbCommand, "EDITADA", DbType.Byte, fichaCliente.Editar == true ? 1 : 0);

            fichaCliente.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return fichaCliente;
        }
        public static BacklineSoporte.Entity.FichaCliente InsertarDatosCotizacion(BacklineSoporte.Entity.FichaCliente segundaParte)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DAT_COTI_DATOS_COTIZACION_INS");

            db.AddInParameter(dbCommand, "FICHA_CLIENTE_ID", DbType.Int32, segundaParte.Id);
            db.AddInParameter(dbCommand, "EDITADA", DbType.Byte, segundaParte.Editar == true ? 1 : 0);
            db.AddInParameter(dbCommand, "NUMERO_COTIZACION", DbType.Int32, segundaParte.NumeroCotizacion != 0 ? segundaParte.NumeroCotizacion : (object)null);
            db.AddInParameter(dbCommand, "FECHA_INGRESO", DbType.DateTime, segundaParte.Fecha_Ingreso_Coti != DateTime.MinValue ? segundaParte.Fecha_Ingreso_Coti : (object)null);
            db.AddInParameter(dbCommand, "NOMBRE_COMPLETO", DbType.String, segundaParte.NombreCompletoCoti != "" ? segundaParte.NombreCompletoCoti.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CORREO", DbType.String, segundaParte.CorreoCoti != "" ? segundaParte.CorreoCoti : (object)null);
            db.AddInParameter(dbCommand, "TELEFONO", DbType.Int32, segundaParte.TelefonoCoti != 0 ? segundaParte.TelefonoCoti : (object)null);
            db.AddInParameter(dbCommand, "FECHA_VIGENCIA", DbType.DateTime, segundaParte.FechaVigenciaCoti != DateTime.MinValue ? segundaParte.FechaVigenciaCoti : (object)null);
            db.AddInParameter(dbCommand, "IMPLEMENTACION_UF_PESO", DbType.Int32, segundaParte.Implementacion_UF_Peso != 0 ? segundaParte.Implementacion_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "IMPLEMENTACION_VALOR", DbType.Int32, segundaParte.Implementacion_Valor != 0 ? segundaParte.Implementacion_Valor : (object)null);
            db.AddInParameter(dbCommand, "ADAPTACION_UF_PESO", DbType.Int32, segundaParte.Adaptacion_UF_Peso != 0 ? segundaParte.Adaptacion_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "ADAPTACION_VALOR", DbType.Int32, segundaParte.Adaptacion_Valor != 0 ? segundaParte.Adaptacion_Valor : (object)null);
            db.AddInParameter(dbCommand, "TARIFA_USO_UF_PESO", DbType.Int32, segundaParte.Tarifa_Uso_UF_Peso != 0 ? segundaParte.Tarifa_Uso_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "TARIFA_USO_VALOR", DbType.Int32, segundaParte.Tarifa_Uso_Valor != 0 ? segundaParte.Tarifa_Uso_Valor : (object)null);
            db.AddInParameter(dbCommand, "USUARIO_UF_PESO", DbType.Int32, segundaParte.Usuario_UF_peso != 0 ? segundaParte.Usuario_UF_peso : (object)null);
            db.AddInParameter(dbCommand, "USUARIO_VALOR", DbType.Int32, segundaParte.Usuario_Valor != 0 ? segundaParte.Usuario_Valor : (object)null);
            db.AddInParameter(dbCommand, "FRACCIONAMIENTO_UF_PESO", DbType.Int32, segundaParte.Fraccionamiento_UF_Peso != 0 ? segundaParte.Fraccionamiento_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "FRACCIONAMIENTO_VALOR", DbType.Int32, segundaParte.Fraccionamiento_Valor != 0 ? segundaParte.Fraccionamiento_Valor : (object)null);
            db.AddInParameter(dbCommand, "INTEGRACION_UF_PESO", DbType.Int32, segundaParte.Integracion_UF_Peso != 0 ? segundaParte.Integracion_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "INTEGRACION_VALOR", DbType.Int32, segundaParte.Integracion_Valor != 0 ? segundaParte.Integracion_Valor : (object)null);
            db.AddInParameter(dbCommand, "BOLETA_ELECTRONICA_UF_PESO", DbType.Int32, segundaParte.Boleta_electronica_UF_Peso != 0 ? segundaParte.Boleta_electronica_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "BOLETA_ELECTRONICA_VALOR", DbType.Int32, segundaParte.Boleta_electronica_Valor != 0 ? segundaParte.Boleta_electronica_Valor : (object)null);
            db.AddInParameter(dbCommand, "PUNTO_VENT_SIMPLE_UF_PESO", DbType.Int32, segundaParte.Punto_Venta_Simple_UF_Peso != 0 ? segundaParte.Punto_Venta_Simple_UF_Peso : (object)null);
            db.AddInParameter(dbCommand, "PUNTO_VENT_SIMPLE_VALOR", DbType.Int32, segundaParte.Punto_Venta_Simple_Valor != 0 ? segundaParte.Punto_Venta_Simple_Valor : (object)null);

            db.ExecuteNonQuery(dbCommand);

            return segundaParte;
        }
        public static BacklineSoporte.Entity.FichaCliente InsertarDatosContratacion(BacklineSoporte.Entity.FichaCliente terceraParte)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DATCO_DATOS_CONTRATACION_INS");

            db.AddInParameter(dbCommand, "FICHA_CLIENTE_ID", DbType.Int32, terceraParte.Id);
            db.AddInParameter(dbCommand, "EDITADA", DbType.Byte, terceraParte.Editar == true ? 1 : 0);
            db.AddInParameter(dbCommand, "PROV_BE_ID", DbType.Int32, terceraParte.Prov_Be_Id != 0 ? terceraParte.Prov_Be_Id : (object)null);
            db.AddInParameter(dbCommand, "TIPO_CONTRATACION_ID", DbType.Int32, terceraParte.Tipo_Contratacion_Id != 0 ? terceraParte.Tipo_Contratacion_Id : (object)null);
            db.AddInParameter(dbCommand, "NUMERO_CONTRATACION", DbType.String, terceraParte.Numero_Contratacion != "" ? terceraParte.Numero_Contratacion : (object)null);
            db.AddInParameter(dbCommand, "MESES_DURACION", DbType.Int32, terceraParte.Meses_Duracion != 0 ? terceraParte.Meses_Duracion : (object)null);
            db.AddInParameter(dbCommand, "FECHA_INICIO", DbType.DateTime, terceraParte.Fecha_Inicio != DateTime.MinValue ? terceraParte.Fecha_Inicio : (object)null);
            db.AddInParameter(dbCommand, "FECHA_TERMINO", DbType.DateTime, terceraParte.Fecha_Termino != DateTime.MinValue ? terceraParte.Fecha_Termino : (object)null);
            db.AddInParameter(dbCommand, "NUMERO_OC", DbType.String, terceraParte.Numero_Oc != "" ? terceraParte.Numero_Oc : (object)null);
            db.AddInParameter(dbCommand, "FECHA_TERMINO_OC", DbType.DateTime, terceraParte.Fecha_Termino_Oc != DateTime.MinValue ? terceraParte.Fecha_Termino_Oc : (object)null);
            db.AddInParameter(dbCommand, "TOTAL_NETO", DbType.Int32, terceraParte.Total_Neto != 0 ? terceraParte.Total_Neto : (object)null);
            db.AddInParameter(dbCommand, "IVA", DbType.Int32, terceraParte.Iva != 0 ? terceraParte.Iva : (object)null);
            db.AddInParameter(dbCommand, "BRUTO", DbType.Int32, terceraParte.Bruto != 0 ? terceraParte.Bruto : (object)null);
            db.AddInParameter(dbCommand, "BOLETA_ELECTRONICA", DbType.Byte, terceraParte.Boleta_Electronica == true ? 1 : 0);
            db.AddInParameter(dbCommand, "FRACCIONAMIENTO", DbType.Byte, terceraParte.Fraccionamiento == true ? 1 : 0);
            db.AddInParameter(dbCommand, "VENTA_SIMPLE", DbType.Byte, terceraParte.Venta_Simple == true ? 1 : 0);
            db.AddInParameter(dbCommand, "CANT_PUNTOS_vENTA_SIMPLE", DbType.Int32, terceraParte.Cant_Puntos_Venta_Simple != 0 ? terceraParte.Cant_Puntos_Venta_Simple : (object)null);
            db.AddInParameter(dbCommand, "NOMBRE_ESTABLECIMIENTO", DbType.String, terceraParte.Nombre_Establecimiento != "" ? terceraParte.Nombre_Establecimiento : (object)null);
            db.AddInParameter(dbCommand, "BE_IVA", DbType.Byte, terceraParte.Be_Iva == true ? 1 : 0);
            db.AddInParameter(dbCommand, "TOTAL_CONTRATADO_UF", DbType.Int32, terceraParte.Total_Contratado_UF != 0 ? terceraParte.Total_Contratado_UF : (object)null);
            db.AddInParameter(dbCommand, "TOTAL_CONTRATADO_PESO", DbType.Int32, terceraParte.Total_Contratado_Peso != 0 ? terceraParte.Total_Contratado_Peso : (object)null);
            db.AddInParameter(dbCommand, "OBSERVACION", DbType.String, terceraParte.Observacion != "" ? terceraParte.Observacion : (object)null);

            db.ExecuteNonQuery(dbCommand);

            return terceraParte;
        }
        public static BacklineSoporte.Entity.FichaCliente InsertarDatosContacto(BacklineSoporte.Entity.FichaCliente cuartaParte)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DAT_CONTA_DATOS_CONTACTO_INS");

            db.AddInParameter(dbCommand, "FICHA_CLIENTE_ID", DbType.Int32, cuartaParte.Id);
            db.AddInParameter(dbCommand, "EDITADA", DbType.Byte, cuartaParte.Editar == true ? 1 : 0);
            db.AddInParameter(dbCommand, "FDP_NOMBRE", DbType.String, cuartaParte.FDP_Nombre != null ? cuartaParte.FDP_Nombre.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FDP_CARGO", DbType.String, cuartaParte.FDP_Cargo != null ? cuartaParte.FDP_Cargo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FDP_CORREO", DbType.String, cuartaParte.FDP_Correo != null ? cuartaParte.FDP_Correo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FDP_TELEFONO", DbType.Int32, cuartaParte.FDP_Telefono != 0 ? cuartaParte.FDP_Telefono : (object)null);
            db.AddInParameter(dbCommand, "INFORMATICA_NOMBRE", DbType.String, cuartaParte.Informatica_Nombre != null ? cuartaParte.Informatica_Nombre.ToUpper() : (object)null);;
            db.AddInParameter(dbCommand, "INFORMATICA_CARGO", DbType.String, cuartaParte.Informatica_Cargo != null ? cuartaParte.Informatica_Cargo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "INFORMATICA_CORREO", DbType.String, cuartaParte.Informatica_Correo != null ? cuartaParte.Informatica_Correo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "INFORMATICA_TELEFONO", DbType.Int32, cuartaParte.Informatica_Telefono != 0 ? cuartaParte.Informatica_Telefono : (object)null);
            db.AddInParameter(dbCommand, "CONTABILIDAD_NOMBRE", DbType.String, cuartaParte.Contabilidad_Nombre != null ? cuartaParte.Contabilidad_Nombre.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CONTABILIDAD_CARGO", DbType.String, cuartaParte.Contabilidad_Cargo != null ? cuartaParte.Contabilidad_Cargo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CONTABILIDAD_CORREO", DbType.String, cuartaParte.Contabilidad_Correo != null ? cuartaParte.Contabilidad_Correo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CONTABILIDAD_TELEFONO", DbType.Int32, cuartaParte.Contabilidad_Telefono != 0 ? cuartaParte.Contabilidad_Telefono : (object)null);
            db.AddInParameter(dbCommand, "FACTURACION_NOMBRE", DbType.String, cuartaParte.Facturacion_Nombre != null ? cuartaParte.Facturacion_Nombre.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FACTURACION_CARGO", DbType.String, cuartaParte.Facturacion_Cargo != null ? cuartaParte.Facturacion_Cargo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FACTURACION_CORREO", DbType.String, cuartaParte.Facturacion_Correo != null ? cuartaParte.Facturacion_Correo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FACTURACION_TELEFONO", DbType.Int32, cuartaParte.Facturacion_Telefono != 0 ? cuartaParte.Facturacion_Telefono : (object)null);

            db.ExecuteNonQuery(dbCommand);

            return cuartaParte;
        }

        public static void EliminarFicha(int idFicha)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FICH_FICHA_CLIENTE_DELETE");


            db.AddInParameter(dbCommand, "IDFICHA", DbType.Int32, idFicha);



            db.ExecuteNonQuery(dbCommand);
        }
        public static List<BacklineSoporte.Entity.FichaCliente> ObtenerEditarFicha(Entity.Filtro filtro)
        {
            List<BacklineSoporte.Entity.FichaCliente> editarFicha = new List<BacklineSoporte.Entity.FichaCliente>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FICH_FICHA_EDITAR_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Ficha_Cliente_Id != 0 ? filtro.Ficha_Cliente_Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int EDITADA = reader.GetOrdinal("EDITADA");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.FichaCliente OBJ = new BacklineSoporte.Entity.FichaCliente();
                    //BeginFields
                    OBJ.Editar = (bool)(reader.IsDBNull(EDITADA) == false ? reader.GetValue(EDITADA) : null);

                    //EndFields

                    editarFicha.Add(OBJ);
                }
            }
            catch (Exception ex)
            {
                //GlobalesDAO.InsertErrores(ex);
                throw ex;
            }
            finally
            {
                reader.Close();
            }



            return editarFicha;

        }
    }
}
