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
    public class ImagenDAL
    {
        public static void InsertarImagenRequerimiento(Entity.Imagen imagen)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_REQUE_IMAGEN_INS");

            db.AddInParameter(dbCommand, "REQUE_ID", DbType.Int32, imagen.RequeId);
            db.AddInParameter(dbCommand, "RUTA", DbType.String, imagen.RUTA_IMAGEN);

            db.ExecuteNonQuery(dbCommand);

        }
        public static List<Entity.Imagen> ObtenerImagenes(Entity.Filtro filtro)
        {
            List<BacklineSoporte.Entity.Imagen> listaRetorno = new List<BacklineSoporte.Entity.Imagen>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("RL_REQUE_IMAGEN_LEER ");


            db.AddInParameter(dbCommand, "REQUE_ID", DbType.Int32, filtro.RequeId);
            //db.AddInParameter(dbCommand, "TIPO_FORMULARIO", DbType.Int32, filtro.TipoFormulario);


            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int REQUE_ID = reader.GetOrdinal("REQUE_ID");
                int RUTA = reader.GetOrdinal("RUTA");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Imagen obj = new BacklineSoporte.Entity.Imagen();
                    //BeginFields
                    obj.ID = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    obj.RequeId = (int)(!reader.IsDBNull(REQUE_ID) ? reader.GetValue(REQUE_ID) : 0);
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
