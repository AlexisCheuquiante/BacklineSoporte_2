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
    public class DetalleCotizacionDAL
    {
        public static List<BacklineSoporte.Entity.DetalleCotizacion> ObtenerDetalleCotizacion(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.DetalleCotizacion> listaDetalleCotizacion = new List<BacklineSoporte.Entity.DetalleCotizacion>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DET_DETALLE_COTIZACION_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int DETALLE_COTIZACION = reader.GetOrdinal("DETALLE_COTIZACION");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.DetalleCotizacion OBJ = new BacklineSoporte.Entity.DetalleCotizacion();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Detalle_Cotizacion = (String)(!reader.IsDBNull(DETALLE_COTIZACION) ? reader.GetValue(DETALLE_COTIZACION) : string.Empty);
                    //EndFields

                    listaDetalleCotizacion.Add(OBJ);
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



            return listaDetalleCotizacion;

        }

    }
}
