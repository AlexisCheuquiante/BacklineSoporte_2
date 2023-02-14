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
    public class ModalidadTareaDAL
    {
        public static List<BacklineSoporte.Entity.ModalidadTarea> ObtenerModalidadTarea()
        {
            List<Entity.ModalidadTarea> listaModalidadTarea = new List<Entity.ModalidadTarea>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_MODA_MODALIDAD_LEER");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int MODALIDAD = reader.GetOrdinal("MODALIDAD");

                while (reader.Read())
                {
                    Entity.ModalidadTarea OBJ = new Entity.ModalidadTarea();
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Modalidad = (String)(!reader.IsDBNull(MODALIDAD) ? reader.GetValue(MODALIDAD) : string.Empty);

                    listaModalidadTarea.Add(OBJ);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally{
                reader.Close();
            }

            return listaModalidadTarea;
            
        }
    }
}
