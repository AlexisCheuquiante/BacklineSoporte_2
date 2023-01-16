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
    public class RegionDAL
    {
        public static List<BacklineSoporte.Entity.Regiones> ObtenerRegiones(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.Regiones> listaRegion = new List<BacklineSoporte.Entity.Regiones>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REG_REGION_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int REGION = reader.GetOrdinal("REGION");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Regiones OBJ = new BacklineSoporte.Entity.Regiones();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Region = (String)(!reader.IsDBNull(REGION) ? reader.GetValue(REGION) : string.Empty);
                    //EndFields

                    listaRegion.Add(OBJ);
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



            return listaRegion;

        }
    }
}
