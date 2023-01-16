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
     public class EntidadDAL
    {
        public static List<BacklineSoporte.Entity.Entidad> ObtenerEntidades(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.Entidad> listaEntidad = new List<BacklineSoporte.Entity.Entidad>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_ENTI_ENTIDAD_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int ENTIDADES = reader.GetOrdinal("ENTIDADES");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Entidad OBJ = new BacklineSoporte.Entity.Entidad();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Entidades = (String)(!reader.IsDBNull(ENTIDADES) ? reader.GetValue(ENTIDADES) : string.Empty);
                    //EndFields

                     listaEntidad.Add(OBJ);
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



            return listaEntidad;

        }
    }
}
