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
    public class InformacionDAL
    {
        public static List<Entity.Informacion> ObtenerInformacion(Entity.Informacion informacionFiltro)
        {
            List<Entity.Informacion> listaRetorno = new List<Entity.Informacion>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosInformacion");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_INFO_INFORMACION_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, informacionFiltro.Id != 0 ? informacionFiltro.Id : (object)null);
       
            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int TITULO = reader.GetOrdinal("TITULO");
                int FECHA = reader.GetOrdinal("FECHA");
                int DETALLE_INFORMACION = reader.GetOrdinal("DETALLE_INFORMACION");
                int VISIBLE = reader.GetOrdinal("VISIBLE");
                int USR_CREADOR = reader.GetOrdinal("USR_CREADOR");
                int CREADOR_INFO = reader.GetOrdinal("CREADOR_INFO");

                while (reader.Read())
                {
                    Entity.Informacion informacion = new Entity.Informacion();
                    informacion.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    informacion.Titulo = (string)(reader.IsDBNull(TITULO) == false ? reader.GetValue(TITULO) : "");
                    informacion.Fecha = (DateTime)(reader.IsDBNull(FECHA) == false ? reader.GetValue(FECHA) : null);
                    informacion.Detalle_Informacion = (string)(reader.IsDBNull(DETALLE_INFORMACION) == false ? reader.GetValue(DETALLE_INFORMACION) : "");
                    informacion.Visible = (bool)( reader.IsDBNull(VISIBLE) == false ? reader.GetValue(VISIBLE) : null);
                    informacion.UsrCreador = (int)(reader.IsDBNull(USR_CREADOR) == false ? reader.GetValue(USR_CREADOR) : 0);
                    informacion.CreadorInformacion = (string)(reader.IsDBNull(CREADOR_INFO) == false ? reader.GetValue(CREADOR_INFO) : "");

                    listaRetorno.Add(informacion);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }
        public static List<Entity.Informacion> ObtenerInformacionCliente(Entity.Informacion informacionFiltro)
        {
            List<Entity.Informacion> listaRetorno = new List<Entity.Informacion>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosInformacion");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_INFO_INFORMACIONES_LEER_CLIENTE");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, informacionFiltro.Id != 0 ? informacionFiltro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int TITULO = reader.GetOrdinal("TITULO");
                int FECHA = reader.GetOrdinal("FECHA");
                int DETALLE_INFORMACION = reader.GetOrdinal("DETALLE_INFORMACION");
                int VISIBLE = reader.GetOrdinal("VISIBLE");
                int USR_CREADOR = reader.GetOrdinal("USR_CREADOR");
                int CREADOR_INFO = reader.GetOrdinal("CREADOR_INFO");

                while (reader.Read())
                {
                    Entity.Informacion informacion = new Entity.Informacion();
                    informacion.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    informacion.Titulo = (string)(reader.IsDBNull(TITULO) == false ? reader.GetValue(TITULO) : "");
                    informacion.Fecha = (DateTime)(reader.IsDBNull(FECHA) == false ? reader.GetValue(FECHA) : null);
                    informacion.Detalle_Informacion = (string)(reader.IsDBNull(DETALLE_INFORMACION) == false ? reader.GetValue(DETALLE_INFORMACION) : "");
                    informacion.Visible = (bool)(reader.IsDBNull(VISIBLE) == false ? reader.GetValue(VISIBLE) : null);
                    informacion.UsrCreador = (int)(reader.IsDBNull(USR_CREADOR) == false ? reader.GetValue(USR_CREADOR) : 0);
                    informacion.CreadorInformacion = (string)(reader.IsDBNull(CREADOR_INFO) == false ? reader.GetValue(CREADOR_INFO) : "");

                    listaRetorno.Add(informacion);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }

        public static void GuardaInformacion(BacklineSoporte.Entity.Informacion informacion)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosInformacion");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_INFO_INFORMACION_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, informacion.Id);
            db.AddInParameter(dbCommand, "TITULO", DbType.String, informacion.Titulo.ToUpper());
            db.AddInParameter(dbCommand, "FECHA", DbType.DateTime, informacion.Fecha);
            db.AddInParameter(dbCommand, "DETALLE_INFORMACION", DbType.String, informacion.Detalle_Informacion.ToUpper());
            db.AddInParameter(dbCommand, "VISIBLE", DbType.Byte, informacion.Visible == true ? 1 : 0);
            db.AddInParameter(dbCommand, "USR_CREADOR", DbType.Int32, informacion.UsrCreador);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void EliminarInformacion(int idInformacion)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosInformacion");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_INFO_INFORMACION_DELETE");


            db.AddInParameter(dbCommand, "IDINFORMACION", DbType.Int32, idInformacion);



            db.ExecuteNonQuery(dbCommand);
        }

    }
}
