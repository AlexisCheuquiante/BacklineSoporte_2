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
    public class TipoArchivoDAL
    {
        public static List<BacklineSoporte.Entity.TipoArchivo> ObtenerTipoArchivo(Entity.Filtro filtro)
        {
            List<Entity.TipoArchivo> listaTiposArchivos = new List<Entity.TipoArchivo>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIAR_TIPO_ARCHIVO_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int DESCRIPCION = reader.GetOrdinal("DESCRIPCION");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.TipoArchivo OBJ = new BacklineSoporte.Entity.TipoArchivo();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Descripcion = (String)(!reader.IsDBNull(DESCRIPCION) ? reader.GetValue(DESCRIPCION) : string.Empty);
                    //EndFields

                    listaTiposArchivos.Add(OBJ);
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

            return listaTiposArchivos;

        }

        public static void GuardaTipoArchivo(BacklineSoporte.Entity.TipoArchivo tipoArchivo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIAR_TIPO_ARCHIVO_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, tipoArchivo.Id);
            db.AddInParameter(dbCommand, "DESCRIPCION", DbType.String, tipoArchivo.Descripcion);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void EliminarTipoArchivo(int idTipoArchivo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIAR_TIPO_ARCHIVO_DELETE");

            db.AddInParameter(dbCommand, "@ID", DbType.Int32, idTipoArchivo);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
