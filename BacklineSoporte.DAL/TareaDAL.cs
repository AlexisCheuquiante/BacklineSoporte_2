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
    public class TareaDAL
    {

        public static List<Entity.Tarea> ObtenerTarea(Entity.Filtro Filtro)
        {
            List<Entity.Tarea> listaRetorno = new List<Entity.Tarea>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TAR_TAREA_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_DESDE", DbType.DateTime, Filtro.FechaDesde != DateTime.MinValue ? Filtro.FechaDesde : (object)null);
            db.AddInParameter(dbCommand, "FECHA_HASTA", DbType.DateTime, Filtro.FechaHasta != DateTime.MinValue ? Filtro.FechaHasta : (object)null);


            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int FECHA_INGRESO_TAREA = reader.GetOrdinal("FECHA_INGRESO_TAREA");
                int FECHA_INICIO_TAREA = reader.GetOrdinal("FECHA_INICIO_TAREA");
                int FECHA_TERMINO_TAREA = reader.GetOrdinal("FECHA_TERMINO_TAREA");
                int DETALLE = reader.GetOrdinal("DETALLE");
                int TIPO_TAREA_ID = reader.GetOrdinal("TIPO_TAREA_ID");
                int PRIORIDAD_ID = reader.GetOrdinal("PRIORIDAD_ID");          
                int USR_CREADOR_ID = reader.GetOrdinal("USR_CREADOR_ID");
                int REALIZADA = reader.GetOrdinal("REALIZADA");
                int PRIORIDAD = reader.GetOrdinal("PRIORIDAD");
                int TIPO_TAREA = reader.GetOrdinal("TIPO_TAREA");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                


                while (reader.Read())
                {
                    Entity.Tarea tarea = new Entity.Tarea();
                    tarea.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    tarea.Fecha_Ingreso = (DateTime)(!reader.IsDBNull(FECHA_INGRESO_TAREA) ? reader.GetValue(FECHA_INGRESO_TAREA) : DateTime.MinValue);
                    tarea.Fecha_Inicio_Tarea = (DateTime)(!reader.IsDBNull(FECHA_INICIO_TAREA) ? reader.GetValue(FECHA_INICIO_TAREA) : DateTime.MinValue);
                    tarea.Fecha_Termino_Tarea = (DateTime)(!reader.IsDBNull(FECHA_TERMINO_TAREA) ? reader.GetValue(FECHA_TERMINO_TAREA) : DateTime.MinValue);
                    tarea.Prioridad_Id = (int)(reader.IsDBNull(PRIORIDAD_ID) == false ? reader.GetValue(PRIORIDAD_ID) : 0);
                    tarea.Detalle = (string)(reader.IsDBNull(DETALLE) == false ? reader.GetValue(DETALLE) : "");
                    tarea.Tipo_Tarea_Id = (int)(reader.IsDBNull(TIPO_TAREA_ID) == false ? reader.GetValue(TIPO_TAREA_ID) : 0);
                    tarea.Realizada = (bool)(!reader.IsDBNull(REALIZADA) ? reader.GetValue(REALIZADA) : false);
                    tarea.Prioridad = (string)(reader.IsDBNull(PRIORIDAD) == false ? reader.GetValue(PRIORIDAD) : "");
                    tarea.Tipo_Tarea = (string)(reader.IsDBNull(TIPO_TAREA) == false ? reader.GetValue(TIPO_TAREA) : "");
                    tarea.Nombre_Completo = (string)(reader.IsDBNull(NOMBRE_COMPLETO) == false ? reader.GetValue(NOMBRE_COMPLETO) : "");

                    listaRetorno.Add(tarea);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }

            if (Filtro.TraeUsuario == true)
            {
                foreach (var d in listaRetorno)
                {
                    Filtro.Tar_Id = d.Id;
                    d.ListaUsuariosAsignados = DAL.RlTareaUsuarioDAL.ObtenerRlUsuarioTarea(Filtro);
                }
            }

            return listaRetorno;
        }


        public static BacklineSoporte.Entity.Tarea InsertarTarea(BacklineSoporte.Entity.Tarea tarea)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TAR_TAREA_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, tarea.Id);
            db.AddInParameter(dbCommand, "FECHA_INICIO_TAREA", DbType.DateTime, tarea.Fecha_Inicio_Tarea != DateTime.MinValue ? tarea.Fecha_Inicio_Tarea : (object)null);
            db.AddInParameter(dbCommand, "FECHA_TERMINO_TAREA", DbType.DateTime, tarea.Fecha_Termino_Tarea != DateTime.MinValue ? tarea.Fecha_Termino_Tarea : (object)null);
            db.AddInParameter(dbCommand, "DETALLE", DbType.String, tarea.Detalle != "" ? tarea.Detalle : (object)null);
            db.AddInParameter(dbCommand, "TIPO_TAREA_ID", DbType.Int32, tarea.Tipo_Tarea_Id != 0 ? tarea.Tipo_Tarea_Id : (object)null);
            db.AddInParameter(dbCommand, "PRIORIDAD_ID", DbType.Int32, tarea.Prioridad_Id != 0 ? tarea.Prioridad_Id : (object)null);
            db.AddInParameter(dbCommand, "USUARIO_CREADOR_ID", DbType.Int32, tarea.Usr_Creador_Id != 0 ? tarea.Usr_Creador_Id : (object)null);
            
           

            tarea.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return tarea;
        }

        public static void TareaRealizada(BacklineSoporte.Entity.Tarea tarea, int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TAR_TAREA_REALIZADA_INS");

            db.AddInParameter(dbCommand, "IDTAREA", DbType.Int32, id);

            db.AddInParameter(dbCommand, "REALIZADA", DbType.Byte, tarea.Realizada == true ? 1 : 0);
            

            db.ExecuteNonQuery(dbCommand);

        }

        public static void EliminarTarea(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TAR_TAREA_DELETE");

            db.AddInParameter(dbCommand, "IDTAREA", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);

        }
    }
}
