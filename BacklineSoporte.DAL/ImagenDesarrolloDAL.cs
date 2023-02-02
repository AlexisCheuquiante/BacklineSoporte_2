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
    public class ImagenDesarrolloDAL
    {
        public static void InsertarImagenDesarrollo(Entity.ImagenDesarrollo entity)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_DESA_IMAGEN_INS");

            db.AddInParameter(dbCommand, "DESARROLLO_ID", DbType.Int32, entity.Desarrollo_Id);
            db.AddInParameter(dbCommand, "RUTA", DbType.String, entity.RUTA_IMAGEN);

            db.ExecuteNonQuery(dbCommand);

        }

        public static List<Entity.ImagenDesarrollo> ObtenerImagenesDesarrollo(Entity.Filtro filtro)
        {
            List<BacklineSoporte.Entity.ImagenDesarrollo> listaRetorno = new List<BacklineSoporte.Entity.ImagenDesarrollo>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_DESA_IMAGEN_LEER ");


            db.AddInParameter(dbCommand, "DESARROLLO_ID", DbType.Int32, filtro.Desarrollo_Id);
            //db.AddInParameter(dbCommand, "TIPO_FORMULARIO", DbType.Int32, filtro.TipoFormulario);


            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int DESARROLLO_ID = reader.GetOrdinal("DESARROLLO_ID");
                int RUTA = reader.GetOrdinal("RUTA");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.ImagenDesarrollo obj = new BacklineSoporte.Entity.ImagenDesarrollo();
                    //BeginFields
                    obj.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    obj.Desarrollo_Id = (int)(!reader.IsDBNull(DESARROLLO_ID) ? reader.GetValue(DESARROLLO_ID) : 0);
                    obj.RUTA_IMAGEN = (String)(!reader.IsDBNull(RUTA) ? reader.GetValue(RUTA) : string.Empty);
                    //EndFields

                    listaRetorno.Add(obj);
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

            return listaRetorno;

        }
    }
}
