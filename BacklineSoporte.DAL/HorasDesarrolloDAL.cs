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
    public class HorasDesarrolloDAL
    {
        public static Entity.HorasDesarrollo InsertarHoras(Entity.HorasDesarrollo entity)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_HODA_HORAS_DESARROLLOS_INS");


            db.AddInParameter(dbCommand, "ID", DbType.Int32, entity.Id);
            db.AddInParameter(dbCommand, "DESA_ID", DbType.Int32, entity.Desa_Id != 0 ? entity.Desa_Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_INICIO", DbType.DateTime, entity.Fecha_Inicio != DateTime.MinValue ? entity.Fecha_Inicio : (object)null);
            db.AddInParameter(dbCommand, "USR_ID", DbType.Int32, entity.Usr_Desarrollador_Id != 0 ? entity.Usr_Desarrollador_Id : (object)null);
            db.AddInParameter(dbCommand, "OBSERVACION", DbType.String, entity.Observacion != "" ? entity.Observacion : (object)null);
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Byte, entity.Eliminada == true ? 1 : 0);

            entity.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return entity;
        }
        public static List<Entity.HorasDesarrollo> ObtenerHorasDesarollo(Entity.Filtro filtro)
        {
            List<Entity.HorasDesarrollo> lista = new List<Entity.HorasDesarrollo>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_HODA_HORAS_DESARROLLOS_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);
            db.AddInParameter(dbCommand, "DESA_ID", DbType.Int32, filtro.Desa_Id != 0 ? filtro.Desa_Id : (object)null);
            db.AddInParameter(dbCommand, "USR_ID", DbType.Int32, filtro.Usr_Responsable_Id != 0 ? filtro.Usr_Responsable_Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_DESDE", DbType.DateTime, filtro.FechaDesde != DateTime.MinValue ? filtro.FechaDesde : (object)null);
            db.AddInParameter(dbCommand, "FECHA_HASTA", DbType.DateTime, filtro.FechaHasta != DateTime.MinValue ? filtro.FechaHasta : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int DESA_ID = reader.GetOrdinal("DESA_ID");
                int FECHA_INICIO = reader.GetOrdinal("FECHA_INICIO");
                int FECHA_TERMINO = reader.GetOrdinal("FECHA_TERMINO");
                int USR_ID = reader.GetOrdinal("USR_ID");
                int NOMBRE_USUARIO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int OBSERVACION = reader.GetOrdinal("OBSERVACION");
                int FINALIZADO = reader.GetOrdinal("FINALIZADO");
                int REQUERIMIENTO = reader.GetOrdinal("REQUERIMIENTO");

                while (reader.Read())
                {
                    Entity.HorasDesarrollo obj = new Entity.HorasDesarrollo();
                    obj.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    obj.Desa_Id = (int)(reader.IsDBNull(DESA_ID) == false ? reader.GetValue(DESA_ID) : "");
                    obj.Fecha_Inicio = (DateTime)(!reader.IsDBNull(FECHA_INICIO) ? reader.GetValue(FECHA_INICIO) : DateTime.MinValue);
                    obj.Fecha_Termino = (DateTime)(!reader.IsDBNull(FECHA_TERMINO) ? reader.GetValue(FECHA_TERMINO) : DateTime.MinValue);
                    obj.Usr_Desarrollador_Id = (int)(reader.IsDBNull(USR_ID) == false ? reader.GetValue(USR_ID) : "");
                    obj.Desarrollador = (string)(reader.IsDBNull(NOMBRE_USUARIO) == false ? reader.GetValue(NOMBRE_USUARIO) : "");
                    obj.Observacion = (string)(reader.IsDBNull(OBSERVACION) == false ? reader.GetValue(OBSERVACION) : "");
                    obj.Finalizado = (bool)(reader.IsDBNull(FINALIZADO) == false ? reader.GetValue(FINALIZADO) : false);
                    obj.Desarrollo = (string)(reader.IsDBNull(REQUERIMIENTO) == false ? reader.GetValue(REQUERIMIENTO) : "");

                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return lista;
        }
        public static void CerrarHora(Entity.HorasDesarrollo entity)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_HODA_HORAS_DESARROLLOS_STOP");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, entity.Id);

            db.ExecuteNonQuery(dbCommand);
        }
        public static void Eliminar(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_HODA_HORAS_DESARROLLOS_DEL");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);
        }
        public static void EditarObservacion(Entity.HorasDesarrollo entity)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_HODA_HORAS_DESARROLLOS_EDITAR");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, entity.Id);
            db.AddInParameter(dbCommand, "OBSERVACION", DbType.String, entity.Observacion != "" ? entity.Observacion : (object)null);

            db.ExecuteNonQuery(dbCommand);
        }
        
    }
}
