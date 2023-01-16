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
    public class TipoContratacionDAL
    {
        public static List<BacklineSoporte.Entity.TipoContratacion> ObtenerTipoContratacion(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.TipoContratacion> listaTipoContratacion = new List<BacklineSoporte.Entity.TipoContratacion>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIPO_TIPO_CONTRATACION_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int TIPO = reader.GetOrdinal("TIPO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.TipoContratacion OBJ = new BacklineSoporte.Entity.TipoContratacion();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Tipo = (String)(!reader.IsDBNull(TIPO) ? reader.GetValue(TIPO) : string.Empty);
                    //EndFields

                    listaTipoContratacion.Add(OBJ);
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



            return listaTipoContratacion;

        }
    }
}
