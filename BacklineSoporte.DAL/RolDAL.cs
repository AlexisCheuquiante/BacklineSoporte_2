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
    public class RolDAL
    {
        public static List<BacklineSoporte.Entity.Rol> ObtenerRoles()
        {
            List<Entity.Rol> listaRoles = new List<Entity.Rol>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_ROL_ROLES_LEER");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int DESCRIPCION = reader.GetOrdinal("DESCRIPCION");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Rol OBJ = new BacklineSoporte.Entity.Rol();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Descripcion = (String)(!reader.IsDBNull(DESCRIPCION) ? reader.GetValue(DESCRIPCION) : string.Empty);
                    //EndFields

                    listaRoles.Add(OBJ);
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

            return listaRoles;

        }
    }
}
