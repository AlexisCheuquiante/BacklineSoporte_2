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
    public class TipoBusquedaDAL
    {
        public static List<BacklineSoporte.Entity.TipoBusqueda> ObtenerTipoBusqueda()
        {
            List<Entity.TipoBusqueda> listaTipoBusqueda = new List<Entity.TipoBusqueda>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIBU_TIPO_BUSQUEDA_LEER");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int DESCRIPCION = reader.GetOrdinal("DESCRIPCION");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.TipoBusqueda OBJ = new BacklineSoporte.Entity.TipoBusqueda();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Descripcion = (String)(!reader.IsDBNull(DESCRIPCION) ? reader.GetValue(DESCRIPCION) : string.Empty);
                    //EndFields

                    listaTipoBusqueda.Add(OBJ);
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

            return listaTipoBusqueda;

        }
    }
}
