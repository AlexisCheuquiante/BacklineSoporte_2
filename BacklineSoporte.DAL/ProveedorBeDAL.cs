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
    public class ProveedorBeDAL
    {
        public static List<BacklineSoporte.Entity.ProveedorBE> ObtenerProveedorBE(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.ProveedorBE> listaProveedor = new List<BacklineSoporte.Entity.ProveedorBE>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_PROV_BE_PROVEEDOR_BE_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int PROVEEDOR = reader.GetOrdinal("PROVEEDOR");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.ProveedorBE OBJ = new BacklineSoporte.Entity.ProveedorBE();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Proveedor = (String)(!reader.IsDBNull(PROVEEDOR) ? reader.GetValue(PROVEEDOR) : string.Empty);
                    //EndFields

                    listaProveedor.Add(OBJ);
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



            return listaProveedor;

        }
    }
}
