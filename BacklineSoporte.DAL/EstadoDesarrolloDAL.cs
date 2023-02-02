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
    public class EstadoDesarrolloDAL
    {
        public static List<BacklineSoporte.Entity.EstadoDesarrollo> ObtenerEstadoDesarrollo()
        {
            List<BacklineSoporte.Entity.EstadoDesarrollo> listaEstadoDesarrollo = new List<BacklineSoporte.Entity.EstadoDesarrollo>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EST_ESTADO_DESARROLLO_LEER");


            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int ESTADO_DESARROLLO = reader.GetOrdinal("ESTADO_DESARROLLO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.EstadoDesarrollo OBJ = new BacklineSoporte.Entity.EstadoDesarrollo();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.EstadoStr = (String)(!reader.IsDBNull(ESTADO_DESARROLLO) ? reader.GetValue(ESTADO_DESARROLLO) : string.Empty);
                    //EndFields

                    listaEstadoDesarrollo.Add(OBJ);
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



            return listaEstadoDesarrollo;

        }
    }
}
