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
    public class ProductoFacturadoDAL
    {
        public static List<BacklineSoporte.Entity.ProductoFacturado> ObtenerProductoFacturado(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.ProductoFacturado> listaProductoFacturado = new List<BacklineSoporte.Entity.ProductoFacturado>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_PROD_FAC_PRODUCTO_FACTURADO");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int PRODUCTO_FACTURADO = reader.GetOrdinal("PRODUCTO_FACTURADO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.ProductoFacturado OBJ = new BacklineSoporte.Entity.ProductoFacturado();
                    //BeginFields
                    OBJ.ID = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Producto_Facturado = (String)(!reader.IsDBNull(PRODUCTO_FACTURADO) ? reader.GetValue(PRODUCTO_FACTURADO) : string.Empty);
                    //EndFields

                    listaProductoFacturado.Add(OBJ);
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



            return listaProductoFacturado;

        }
    }
}
