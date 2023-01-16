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
    public class ArchivoDAL
    {
        public static BacklineSoporte.Entity.Archivo InsertarArchivo(BacklineSoporte.Entity.Archivo archivo)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_ARCH_ARCHIVO_INS");

            db.AddInParameter(dbCommand, "FICH_ID", DbType.Int32, archivo.FichId != 0 ? archivo.FichId : (object)null);
            db.AddInParameter(dbCommand, "TIAR_ID", DbType.Int32, archivo.TiarId != 0 ? archivo.TiarId : (object)null);
            db.AddInParameter(dbCommand, "OBSERVACION", DbType.String, archivo.Observacion != "" ? archivo.Observacion.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "NOMBRE", DbType.String, archivo.Nombre != "" ? archivo.Nombre : (object)null);
            db.AddInParameter(dbCommand, "RUTA", DbType.String, archivo.Ruta != "" ? archivo.Ruta : (object)null);
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Byte, archivo.Eliminado == true ? 1 : 0);

            db.ExecuteNonQuery(dbCommand);

            return archivo;
        }
        public static List<Entity.Archivo> ObtenerArchivo(Entity.Filtro Filtro)
        {
            List<Entity.Archivo> listaRetorno = new List<Entity.Archivo>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_ARCH_ARCHIVO_LEER");

            db.AddInParameter(dbCommand, "FICH_ID", DbType.Int32, Filtro.Ficha_Cliente_Id != 0 ? Filtro.Ficha_Cliente_Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int FICH_ID = reader.GetOrdinal("FICH_ID");
                int TIAR_ID = reader.GetOrdinal("TIAR_ID");
                int TIPO_ARCHIVO = reader.GetOrdinal("TIPO_ARCHIVO");
                int NOMBRE = reader.GetOrdinal("NOMBRE");
                int RUTA = reader.GetOrdinal("RUTA");
                int OBSERVACION = reader.GetOrdinal("OBSERVACION");

                while (reader.Read())
                {
                    Entity.Archivo archivo = new Entity.Archivo();
                    archivo.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    archivo.FichId = (int)(reader.IsDBNull(FICH_ID) == false ? reader.GetValue(FICH_ID) : 0);
                    archivo.TiarId = (int)(reader.IsDBNull(TIAR_ID) == false ? reader.GetValue(TIAR_ID) : 0);
                    archivo.TipoArchivo = (string)(reader.IsDBNull(TIPO_ARCHIVO) == false ? reader.GetValue(TIPO_ARCHIVO) : "");
                    archivo.Nombre = (string)(reader.IsDBNull(NOMBRE) == false ? reader.GetValue(NOMBRE) : "");
                    archivo.Ruta = (string)(reader.IsDBNull(RUTA) == false ? reader.GetValue(RUTA) : "");
                    archivo.Observacion = (string)(reader.IsDBNull(OBSERVACION) == false ? reader.GetValue(OBSERVACION) : "");

                    listaRetorno.Add(archivo);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }
    }
}
