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
    public class TiempoDAL
    {
        public static List<BacklineSoporte.Entity.Tiempo> ObtenerIntervaloTiempo()
        {
            List<Entity.Tiempo> listaTiempos = new List<Entity.Tiempo>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_INTI_INTERVALO_TIEMPO_LEER");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int INTERVALO_TIEMPO = reader.GetOrdinal("INTERVALO_TIEMPO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Tiempo OBJ = new BacklineSoporte.Entity.Tiempo();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.IntervaloTiempo = (int)(!reader.IsDBNull(INTERVALO_TIEMPO) ? reader.GetValue(INTERVALO_TIEMPO) : 0);
                    //EndFields

                    listaTiempos.Add(OBJ);
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

            return listaTiempos;

        }
    }
}
