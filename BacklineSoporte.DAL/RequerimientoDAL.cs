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
    public class RequerimientoDAL
    {
        public static List<Entity.Requerimiento> ObtenerRequerimiento_Numero(Entity.Filtro Filtro)
        {
            List<Entity.Requerimiento> listaRetorno = new List<Entity.Requerimiento>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_BUSCAR_NUMERO");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int EMP_ID = reader.GetOrdinal("EMP_ID");
                int NOMBRE_EMPRESA = reader.GetOrdinal("NOMBRE_EMPRESA");
                int USR_ID_SOLICITANTE = reader.GetOrdinal("USR_ID_SOLICITANTE");
                int NOMBRE_SOLICITANTE = reader.GetOrdinal("NOMBRE_SOLICITANTE");
                int FUNCIONALIDAD = reader.GetOrdinal("FUNCIONALIDAD");
                int PRIO_ID = reader.GetOrdinal("PRIO_ID");
                int TIPO_PRIORIDAD = reader.GetOrdinal("TIPO_PRIORIDAD");
                int DETALLE = reader.GetOrdinal("DETALLE");
                int FECHA_INGRESO = reader.GetOrdinal("FECHA_INGRESO");
                int APRUEBO = reader.GetOrdinal("APRUEBO");
                int DESAPRUEBO = reader.GetOrdinal("DESAPRUEBO");
                int CORREO = reader.GetOrdinal("CORREO");
                int REPETICION_REQUERIMIENTO = reader.GetOrdinal("REPETICION_REQUERIMIENTO");
                int MOD_ID = reader.GetOrdinal("MOD_ID");
                int MODULO = reader.GetOrdinal("MODULO");
                int CLASIFICACION = reader.GetOrdinal("CLASIFICACION");
                int TISO_ID = reader.GetOrdinal("TISO_ID");
                int SOFTWARE = reader.GetOrdinal("SOFTWARE");
                int USR_RESPONSABLE = reader.GetOrdinal("USR_RESPONSABLE");
                int FECHA_SOLUCION = reader.GetOrdinal("FECHA_SOLUCION");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int ESTADO = reader.GetOrdinal("ESTADO");
                int ESTADO_REQUE = reader.GetOrdinal("ESTADO_REQUE");
                int VISIBLE = reader.GetOrdinal("VISIBLE");


                while (reader.Read())
                {
                    Entity.Requerimiento requerimiento = new Entity.Requerimiento();
                    requerimiento.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    requerimiento.EmpId = (int)(reader.IsDBNull(EMP_ID) == false ? reader.GetValue(EMP_ID) : 0);
                    requerimiento.NombreEmpresa = (string)(reader.IsDBNull(NOMBRE_EMPRESA) == false ? reader.GetValue(NOMBRE_EMPRESA) : "");
                    requerimiento.SolicitanteId = (int)(reader.IsDBNull(USR_ID_SOLICITANTE) == false ? reader.GetValue(USR_ID_SOLICITANTE) : 0);
                    requerimiento.NombreSolicitante = (string)(reader.IsDBNull(NOMBRE_SOLICITANTE) == false ? reader.GetValue(NOMBRE_SOLICITANTE) : "");
                    requerimiento.Funcionalidad = (string)(reader.IsDBNull(FUNCIONALIDAD) == false ? reader.GetValue(FUNCIONALIDAD) : "");
                    requerimiento.PriodId = (int)(reader.IsDBNull(PRIO_ID) == false ? reader.GetValue(PRIO_ID) : "");
                    requerimiento.Prioridad = (string)(reader.IsDBNull(TIPO_PRIORIDAD) == false ? reader.GetValue(TIPO_PRIORIDAD) : "");
                    requerimiento.Detalle = (string)(reader.IsDBNull(DETALLE) == false ? reader.GetValue(DETALLE) : "");
                    requerimiento.FechaIngreso = (DateTime)(!reader.IsDBNull(FECHA_INGRESO) ? reader.GetValue(FECHA_INGRESO) : DateTime.MinValue);
                    requerimiento.Apruebo = (int)(!reader.IsDBNull(APRUEBO) ? reader.GetValue(APRUEBO) : 0);
                    requerimiento.Desapruebo = (int)(!reader.IsDBNull(DESAPRUEBO) ? reader.GetValue(DESAPRUEBO) : 0);
                    requerimiento.Correo = (string)(reader.IsDBNull(CORREO) == false ? reader.GetValue(CORREO) : "");
                    requerimiento.RepeticionRequerimiento = (bool)(reader.IsDBNull(REPETICION_REQUERIMIENTO) == false ? reader.GetValue(REPETICION_REQUERIMIENTO) : "");
                    requerimiento.ModId = (int)(reader.IsDBNull(MOD_ID) == false ? reader.GetValue(MOD_ID) : "");
                    requerimiento.Modulo = (string)(reader.IsDBNull(MODULO) == false ? reader.GetValue(MODULO) : "");
                    requerimiento.Clasificacion = (int)(reader.IsDBNull(CLASIFICACION) == false ? reader.GetValue(CLASIFICACION) : 0);
                    requerimiento.TisoId = (int)(reader.IsDBNull(TISO_ID) == false ? reader.GetValue(TISO_ID) : 0);
                    requerimiento.SoftwareStr = (string)(reader.IsDBNull(SOFTWARE) == false ? reader.GetValue(SOFTWARE) : "");
                    requerimiento.ResponsableId = (int)(reader.IsDBNull(USR_RESPONSABLE) == false ? reader.GetValue(USR_RESPONSABLE) : 0);
                    requerimiento.FechaSolucion = (DateTime)(!reader.IsDBNull(FECHA_SOLUCION) ? reader.GetValue(FECHA_SOLUCION) : DateTime.MinValue);
                    requerimiento.NombreResponsable = (string)(reader.IsDBNull(NOMBRE_COMPLETO) == false ? reader.GetValue(NOMBRE_COMPLETO) : "");
                    requerimiento.Estado = (int)(reader.IsDBNull(ESTADO) == false ? reader.GetValue(ESTADO) : 0);
                    requerimiento.Estado_Reque = (string)(reader.IsDBNull(ESTADO_REQUE) == false ? reader.GetValue(ESTADO_REQUE) : "");
                    requerimiento.Visible = (bool)(!reader.IsDBNull(VISIBLE) ? reader.GetValue(VISIBLE) : false);

                    listaRetorno.Add(requerimiento);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }
        public static List<Entity.Requerimiento> ObtenerRequerimiento(Entity.Filtro Filtro)
        {
            List<Entity.Requerimiento> listaRetorno = new List<Entity.Requerimiento>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_DESDE", DbType.DateTime, Filtro.FechaDesde != DateTime.MinValue ? Filtro.FechaDesde : (object)null);
            db.AddInParameter(dbCommand, "FECHA_HASTA", DbType.DateTime, Filtro.FechaHasta != DateTime.MinValue ? Filtro.FechaHasta : (object)null);
            db.AddInParameter(dbCommand, "TISO_ID", DbType.Int32, Filtro.Tipo_Software != 0 ? Filtro.Tipo_Software : (object)null);
            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, Filtro.EmpId != 0 ? Filtro.EmpId : (object)null);
            db.AddInParameter(dbCommand, "USR_RESPONSABLE", DbType.Int32, Filtro.Responsable != 0 ? Filtro.Responsable : (object)null);
            db.AddInParameter(dbCommand, "ESTADO", DbType.Int32, Filtro.Estado != 0 ? Filtro.Estado : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int EMP_ID = reader.GetOrdinal("EMP_ID");
                int NOMBRE_EMPRESA = reader.GetOrdinal("NOMBRE_EMPRESA");
                int USR_ID_SOLICITANTE = reader.GetOrdinal("USR_ID_SOLICITANTE");
                int NOMBRE_SOLICITANTE = reader.GetOrdinal("NOMBRE_SOLICITANTE");
                int FUNCIONALIDAD = reader.GetOrdinal("FUNCIONALIDAD");
                int PRIO_ID = reader.GetOrdinal("PRIO_ID");
                int TIPO_PRIORIDAD = reader.GetOrdinal("TIPO_PRIORIDAD");
                int DETALLE = reader.GetOrdinal("DETALLE");
                int FECHA_INGRESO = reader.GetOrdinal("FECHA_INGRESO");
                int APRUEBO = reader.GetOrdinal("APRUEBO");
                int DESAPRUEBO = reader.GetOrdinal("DESAPRUEBO");
                int CORREO = reader.GetOrdinal("CORREO");
                int REPETICION_REQUERIMIENTO = reader.GetOrdinal("REPETICION_REQUERIMIENTO");
                int MOD_ID = reader.GetOrdinal("MOD_ID");
                int MODULO = reader.GetOrdinal("MODULO");
                int CLASIFICACION = reader.GetOrdinal("CLASIFICACION");
                int TISO_ID = reader.GetOrdinal("TISO_ID");
                int SOFTWARE = reader.GetOrdinal("SOFTWARE");
                int USR_RESPONSABLE = reader.GetOrdinal("USR_RESPONSABLE");
                int FECHA_SOLUCION = reader.GetOrdinal("FECHA_SOLUCION");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int ESTADO = reader.GetOrdinal("ESTADO");
                int ESTADO_REQUE = reader.GetOrdinal("ESTADO_REQUE");
                int VISIBLE = reader.GetOrdinal("VISIBLE");


                while (reader.Read())
                {
                    Entity.Requerimiento requerimiento = new Entity.Requerimiento();
                    requerimiento.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    requerimiento.EmpId = (int)(reader.IsDBNull(EMP_ID) == false ? reader.GetValue(EMP_ID) : 0);
                    requerimiento.NombreEmpresa = (string)(reader.IsDBNull(NOMBRE_EMPRESA) == false ? reader.GetValue(NOMBRE_EMPRESA) : "");
                    requerimiento.SolicitanteId = (int)(reader.IsDBNull(USR_ID_SOLICITANTE) == false ? reader.GetValue(USR_ID_SOLICITANTE) : 0);
                    requerimiento.NombreSolicitante = (string)(reader.IsDBNull(NOMBRE_SOLICITANTE) == false ? reader.GetValue(NOMBRE_SOLICITANTE) : "");
                    requerimiento.Funcionalidad = (string)(reader.IsDBNull(FUNCIONALIDAD) == false ? reader.GetValue(FUNCIONALIDAD) : "");
                    requerimiento.PriodId = (int)(reader.IsDBNull(PRIO_ID) == false ? reader.GetValue(PRIO_ID) : "");
                    requerimiento.Prioridad = (string)(reader.IsDBNull(TIPO_PRIORIDAD) == false ? reader.GetValue(TIPO_PRIORIDAD) : "");
                    requerimiento.Detalle = (string)(reader.IsDBNull(DETALLE) == false ? reader.GetValue(DETALLE) : "");
                    requerimiento.FechaIngreso = (DateTime)(!reader.IsDBNull(FECHA_INGRESO) ? reader.GetValue(FECHA_INGRESO) : DateTime.MinValue);
                    requerimiento.Apruebo = (int)(!reader.IsDBNull(APRUEBO) ? reader.GetValue(APRUEBO) : 0);
                    requerimiento.Desapruebo = (int)(!reader.IsDBNull(DESAPRUEBO) ? reader.GetValue(DESAPRUEBO) : 0);
                    requerimiento.Correo = (string)(reader.IsDBNull(CORREO) == false ? reader.GetValue(CORREO) : "");
                    requerimiento.RepeticionRequerimiento = (bool)(reader.IsDBNull(REPETICION_REQUERIMIENTO) == false ? reader.GetValue(REPETICION_REQUERIMIENTO) : "");
                    requerimiento.ModId = (int)(reader.IsDBNull(MOD_ID) == false ? reader.GetValue(MOD_ID) : "");
                    requerimiento.Modulo = (string)(reader.IsDBNull(MODULO) == false ? reader.GetValue(MODULO) : "");
                    requerimiento.Clasificacion = (int)(reader.IsDBNull(CLASIFICACION) == false ? reader.GetValue(CLASIFICACION) : 0);
                    requerimiento.TisoId = (int)(reader.IsDBNull(TISO_ID) == false ? reader.GetValue(TISO_ID) : 0);
                    requerimiento.SoftwareStr = (string)(reader.IsDBNull(SOFTWARE) == false ? reader.GetValue(SOFTWARE) : "");
                    requerimiento.ResponsableId = (int)(reader.IsDBNull(USR_RESPONSABLE) == false ? reader.GetValue(USR_RESPONSABLE) : 0);
                    requerimiento.FechaSolucion = (DateTime)(!reader.IsDBNull(FECHA_SOLUCION) ? reader.GetValue(FECHA_SOLUCION) : DateTime.MinValue);
                    requerimiento.NombreResponsable = (string)(reader.IsDBNull(NOMBRE_COMPLETO) == false ? reader.GetValue(NOMBRE_COMPLETO) : "");
                    requerimiento.Estado = (int)(reader.IsDBNull(ESTADO) == false ? reader.GetValue(ESTADO) : 0);
                    requerimiento.Estado_Reque = (string)(reader.IsDBNull(ESTADO_REQUE) == false ? reader.GetValue(ESTADO_REQUE) : "");
                    requerimiento.Visible = (bool)(!reader.IsDBNull(VISIBLE) ? reader.GetValue(VISIBLE) : false);

                    listaRetorno.Add(requerimiento);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }

        public static List<Entity.Requerimiento> ObtenerRequerimientoVisible(Entity.Filtro Filtro)
        {
            List<Entity.Requerimiento> listaRetorno = new List<Entity.Requerimiento>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_GET_BY_VISIBLE");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int EMP_ID = reader.GetOrdinal("EMP_ID");
                int NOMBRE_EMPRESA = reader.GetOrdinal("NOMBRE_EMPRESA");
                int USR_ID_SOLICITANTE = reader.GetOrdinal("USR_ID_SOLICITANTE");
                int NOMBRE_SOLICITANTE = reader.GetOrdinal("NOMBRE_SOLICITANTE");
                int FUNCIONALIDAD = reader.GetOrdinal("FUNCIONALIDAD");
                int PRIO_ID = reader.GetOrdinal("PRIO_ID");
                int TIPO_PRIORIDAD = reader.GetOrdinal("TIPO_PRIORIDAD");
                int DETALLE = reader.GetOrdinal("DETALLE");
                int FECHA_INGRESO = reader.GetOrdinal("FECHA_INGRESO");
                int APRUEBO = reader.GetOrdinal("APRUEBO");
                int DESAPRUEBO = reader.GetOrdinal("DESAPRUEBO");
                int CORREO = reader.GetOrdinal("CORREO");
                int REPETICION_REQUERIMIENTO = reader.GetOrdinal("REPETICION_REQUERIMIENTO");
                int MOD_ID = reader.GetOrdinal("MOD_ID");
                int MODULO = reader.GetOrdinal("MODULO");
                int CLASIFICACION = reader.GetOrdinal("CLASIFICACION");
                int TISO_ID = reader.GetOrdinal("TISO_ID");
                int SOFTWARE = reader.GetOrdinal("SOFTWARE");
                int USR_RESPONSABLE = reader.GetOrdinal("USR_RESPONSABLE");
                int FECHA_SOLUCION = reader.GetOrdinal("FECHA_SOLUCION");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int ESTADO = reader.GetOrdinal("ESTADO");
                int ESTADO_REQUE = reader.GetOrdinal("ESTADO_REQUE");
                int VISIBLE = reader.GetOrdinal("VISIBLE");


                while (reader.Read())
                {
                    Entity.Requerimiento requerimiento = new Entity.Requerimiento();
                    requerimiento.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    requerimiento.EmpId = (int)(reader.IsDBNull(EMP_ID) == false ? reader.GetValue(EMP_ID) : 0);
                    requerimiento.NombreEmpresa = (string)(reader.IsDBNull(NOMBRE_EMPRESA) == false ? reader.GetValue(NOMBRE_EMPRESA) : "");
                    requerimiento.SolicitanteId = (int)(reader.IsDBNull(USR_ID_SOLICITANTE) == false ? reader.GetValue(USR_ID_SOLICITANTE) : 0);
                    requerimiento.NombreSolicitante = (string)(reader.IsDBNull(NOMBRE_SOLICITANTE) == false ? reader.GetValue(NOMBRE_SOLICITANTE) : "");
                    requerimiento.Funcionalidad = (string)(reader.IsDBNull(FUNCIONALIDAD) == false ? reader.GetValue(FUNCIONALIDAD) : "");
                    requerimiento.PriodId = (int)(reader.IsDBNull(PRIO_ID) == false ? reader.GetValue(PRIO_ID) : "");
                    requerimiento.Prioridad = (string)(reader.IsDBNull(TIPO_PRIORIDAD) == false ? reader.GetValue(TIPO_PRIORIDAD) : "");
                    requerimiento.Detalle = (string)(reader.IsDBNull(DETALLE) == false ? reader.GetValue(DETALLE) : "");
                    requerimiento.FechaIngreso = (DateTime)(!reader.IsDBNull(FECHA_INGRESO) ? reader.GetValue(FECHA_INGRESO) : DateTime.MinValue);
                    requerimiento.Apruebo = (int)(!reader.IsDBNull(APRUEBO) ? reader.GetValue(APRUEBO) : 0);
                    requerimiento.Desapruebo = (int)(!reader.IsDBNull(DESAPRUEBO) ? reader.GetValue(DESAPRUEBO) : 0);
                    requerimiento.Correo = (string)(reader.IsDBNull(CORREO) == false ? reader.GetValue(CORREO) : "");
                    requerimiento.RepeticionRequerimiento = (bool)(reader.IsDBNull(REPETICION_REQUERIMIENTO) == false ? reader.GetValue(REPETICION_REQUERIMIENTO) : "");
                    requerimiento.ModId = (int)(reader.IsDBNull(MOD_ID) == false ? reader.GetValue(MOD_ID) : "");
                    requerimiento.Modulo = (string)(reader.IsDBNull(MODULO) == false ? reader.GetValue(MODULO) : "");
                    requerimiento.Clasificacion = (int)(reader.IsDBNull(CLASIFICACION) == false ? reader.GetValue(CLASIFICACION) : 0);
                    requerimiento.TisoId = (int)(reader.IsDBNull(TISO_ID) == false ? reader.GetValue(TISO_ID) : 0);
                    requerimiento.SoftwareStr = (string)(reader.IsDBNull(SOFTWARE) == false ? reader.GetValue(SOFTWARE) : "");
                    requerimiento.ResponsableId = (int)(reader.IsDBNull(USR_RESPONSABLE) == false ? reader.GetValue(USR_RESPONSABLE) : 0);
                    requerimiento.FechaSolucion = (DateTime)(!reader.IsDBNull(FECHA_SOLUCION) ? reader.GetValue(FECHA_SOLUCION) : DateTime.MinValue);
                    requerimiento.NombreResponsable = (string)(reader.IsDBNull(NOMBRE_COMPLETO) == false ? reader.GetValue(NOMBRE_COMPLETO) : "");
                    requerimiento.Estado = (int)(reader.IsDBNull(ESTADO) == false ? reader.GetValue(ESTADO) : 0);
                    requerimiento.Estado_Reque = (string)(reader.IsDBNull(ESTADO_REQUE) == false ? reader.GetValue(ESTADO_REQUE) : "");
                    requerimiento.Visible = (bool)(reader.IsDBNull(VISIBLE) == false ? reader.GetValue(VISIBLE) : "");

                    listaRetorno.Add(requerimiento);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }
        public static BacklineSoporte.Entity.Requerimiento InsertarRequerimiento(BacklineSoporte.Entity.Requerimiento requerimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, requerimiento.Id);
            db.AddInParameter(dbCommand, "USR_ID_CREADOR", DbType.Int32, requerimiento.UsrCreador != 0 ? requerimiento.UsrCreador : (object)null);
            db.AddInParameter(dbCommand, "FECHA_INGRESO", DbType.DateTime, requerimiento.FechaIngreso != DateTime.MinValue ? requerimiento.FechaIngreso : (object)null);
            db.AddInParameter(dbCommand, "TISO_ID", DbType.Int32, requerimiento.TisoId != 0 ? requerimiento.TisoId : (object)null);
            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, requerimiento.EmpId != 0 ? requerimiento.EmpId : (object)null);
            db.AddInParameter(dbCommand, "NOMBRE_EMPRESA", DbType.String, requerimiento.NombreEmpresa != "" ? requerimiento.NombreEmpresa.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "USR_ID_SOLICITANTE", DbType.Int32, requerimiento.SolicitanteId != 0 ? requerimiento.SolicitanteId : (object)null);
            db.AddInParameter(dbCommand, "NOMBRE_SOLICITANTE", DbType.String, requerimiento.NombreSolicitante != "" ? requerimiento.NombreSolicitante.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CORREO", DbType.String, requerimiento.Correo != "" ? requerimiento.Correo.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "REPETICION_REQUERIMIENTO", DbType.Byte, requerimiento.RepeticionRequerimiento == true ? 1 : 0);
            db.AddInParameter(dbCommand, "MOD_ID", DbType.Int32, requerimiento.ModId != 0 ? requerimiento.ModId : (object)null);
            db.AddInParameter(dbCommand, "FUNCIONALIDAD", DbType.String, requerimiento.Funcionalidad != "" ? requerimiento.Funcionalidad.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CLASIFICACION", DbType.Int32, requerimiento.Clasificacion != 0 ? requerimiento.Clasificacion : (object)null);
            db.AddInParameter(dbCommand, "PRIO_ID", DbType.Int32, requerimiento.PriodId != 0 ? requerimiento.PriodId : (object)null);
            db.AddInParameter(dbCommand, "USR_RESPONSABLE", DbType.Int32, requerimiento.ResponsableId != 0 ? requerimiento.ResponsableId : (object)null);
            db.AddInParameter(dbCommand, "FECHA_SOLUCION", DbType.DateTime, requerimiento.FechaSolucion != DateTime.MinValue ? requerimiento.FechaSolucion : (object)null);
            db.AddInParameter(dbCommand, "DETALLE", DbType.String, requerimiento.Detalle != "" ? requerimiento.Detalle.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Byte, requerimiento.Eliminado == true ? 1 : 0);
            db.AddInParameter(dbCommand, "VISIBLE", DbType.Byte, requerimiento.Visible == true ? 1 : 0);
            db.AddInParameter(dbCommand, "ESTADO", DbType.Int32, requerimiento.Estado != 0 ? requerimiento.Estado : (object)null);

            requerimiento.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return requerimiento;
        }
        public static void InsertarApruebo(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_APRUEBO");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);

        }
        public static void InsertarDesapruebo(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_DESAPRUEBO");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);

        }
        public static void EliminarRequerimiento(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REQUE_REQUERIMIENTOS_DELETE");

            db.AddInParameter(dbCommand, "IDREQUERIMIENTO", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);

        }
    }
}
