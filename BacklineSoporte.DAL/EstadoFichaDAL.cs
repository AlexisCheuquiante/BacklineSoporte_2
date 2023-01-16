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
    public class EstadoFichaDAL
    {
        public static List<BacklineSoporte.Entity.EstadoFicha> ObtenerEstadoFicha(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.EstadoFicha> listaEstadoFicha = new List<BacklineSoporte.Entity.EstadoFicha>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EST_ESTADO_FICHA_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int ESTADO = reader.GetOrdinal("ESTADO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.EstadoFicha OBJ = new BacklineSoporte.Entity.EstadoFicha();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Estado = (String)(!reader.IsDBNull(ESTADO) ? reader.GetValue(ESTADO) : string.Empty);
                    //EndFields

                    listaEstadoFicha.Add(OBJ);
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



            return listaEstadoFicha;

        }
    }
}
