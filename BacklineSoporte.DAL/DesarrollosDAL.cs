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
    public class DesarrollosDAL
    {
        public static void InsertarDesarrollo(Entity.Desarrollo desarrollo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DESA_DESARROLLO_INS");
            db.AddInParameter(dbCommand, "ID", DbType.Int32, desarrollo.Id );
            db.AddInParameter(dbCommand, "MODULO", DbType.String, desarrollo.Modulo);
            db.AddInParameter(dbCommand, "REQUERIMIENTO", DbType.String, desarrollo.Requerimiento);
            db.AddInParameter(dbCommand, "DETALLE_REQUERIMIENTO", DbType.String, desarrollo.Detalle_Requerimiento);
            db.AddInParameter(dbCommand, "FECHA_INICIO", DbType.DateTime, desarrollo.Fecha_Inicio);
            db.AddInParameter(dbCommand, "FECHA_TERMINO", DbType.DateTime, desarrollo.Fecha_Termino);
            db.AddInParameter(dbCommand, "ESTADO_ID", DbType.Int32, desarrollo.Estado_Id);
            db.AddInParameter(dbCommand, "USR_RESPONSABLE_ID", DbType.Int32, desarrollo.Usuario_Responsable_Id);

            db.ExecuteNonQuery(dbCommand);
           
        }

        public static List<Entity.Desarrollo> ObtenerDesarrollos(Entity.Filtro filtro)
        {
            List<Entity.Desarrollo> listaRetorno = new List<Entity.Desarrollo>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DESA_DESAROLLOS_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_DESDE", DbType.DateTime, filtro.FechaDesde != DateTime.MinValue ? filtro.FechaDesde : (object)null);
            db.AddInParameter(dbCommand, "FECHA_HASTA", DbType.DateTime, filtro.FechaHasta != DateTime.MinValue ? filtro.FechaHasta : (object)null);
            db.AddInParameter(dbCommand, "USR_RESPONSABLE_ID", DbType.Int32, filtro.Usr_Responsable_Id != 0 ? filtro.Usr_Responsable_Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int MODULO = reader.GetOrdinal("MODULO");
                int FECHA_INICIO = reader.GetOrdinal("FECHA_INICIO");
                int FECHA_TERMINO = reader.GetOrdinal("FECHA_TERMINO");
                int REQUERIMIENTO = reader.GetOrdinal("REQUERIMIENTO");
                int DETALLE_REQUERIMIENTO = reader.GetOrdinal("DETALLE_REQUERIMIENTO");
                int ESTADO_ID = reader.GetOrdinal("ESTADO_ID");
                int DIFERENCIAFECHA = reader.GetOrdinal("DIFERENCIAFECHA");
                int NOMBRECOMPLETO = reader.GetOrdinal("NOMBRECOMPLETO");
                int USR_RESPONSABLE_ID = reader.GetOrdinal("USR_RESPONSABLE_ID");
                int TIEMPO_ATRASO = reader.GetOrdinal("TIEMPO_ATRASO");
               

                while (reader.Read())
                {
                    Entity.Desarrollo desarrollo = new Entity.Desarrollo();
                    desarrollo.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    desarrollo.Usuario_Responsable_Id = (int)(reader.IsDBNull(USR_RESPONSABLE_ID) == false ? reader.GetValue(USR_RESPONSABLE_ID) : 0);
                    desarrollo.NombreCompleto = (string)(reader.IsDBNull(NOMBRECOMPLETO) == false ? reader.GetValue(NOMBRECOMPLETO) : "");
                    desarrollo.Modulo = (string)(reader.IsDBNull(MODULO) == false ? reader.GetValue(MODULO) : "");
                    desarrollo.Fecha_Inicio = (DateTime)(reader.IsDBNull(FECHA_INICIO) == false ? reader.GetValue(FECHA_INICIO) : null);
                    desarrollo.Fecha_Termino = (DateTime)(reader.IsDBNull(FECHA_TERMINO) == false ? reader.GetValue(FECHA_TERMINO) : null);
                    desarrollo.Requerimiento = (string)(reader.IsDBNull(REQUERIMIENTO) == false ? reader.GetValue(REQUERIMIENTO) : "");
                    desarrollo.Detalle_Requerimiento = (string)(reader.IsDBNull(DETALLE_REQUERIMIENTO) == false ? reader.GetValue(DETALLE_REQUERIMIENTO) : "");
                    desarrollo.Estado_Id = (int)(reader.IsDBNull(ESTADO_ID) == false ? reader.GetValue(ESTADO_ID) : 0);
                    desarrollo.DiferenciaFecha = (int)(reader.IsDBNull(DIFERENCIAFECHA) == false ? reader.GetValue(DIFERENCIAFECHA) : 0);
                    desarrollo.Tiempo_Atraso = (int)(reader.IsDBNull(TIEMPO_ATRASO) == false ? reader.GetValue(TIEMPO_ATRASO) : 0);

                    listaRetorno.Add(desarrollo);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }
        public static void EliminarDesarrollo( int idDesarrollo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DESA_DESARROLLO_DELETE");

            db.AddInParameter(dbCommand, "IDDESARROLLO", DbType.Int32, idDesarrollo);

            db.ExecuteNonQuery(dbCommand);


        }
    }

}
