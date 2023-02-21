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
    public class FacturaDAL
    {
        public static List<Entity.Factura> ObtenerFactura(Entity.Filtro filtro)
        {
            List<Entity.Factura> lista = new List<Entity.Factura>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FACT_FACTURAS_LEER_COMPLETAR");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Fact_Id != 0 ? filtro.Fact_Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int USR_ID_CAJA = reader.GetOrdinal("USR_ID_CAJA");
                int FECHA_INGRESO = reader.GetOrdinal("FECHA_INGRESO");
                int CONT_ID = reader.GetOrdinal("CONT_ID");
                int PACIENTE = reader.GetOrdinal("PACIENTE");
                int RUT = reader.GetOrdinal("RUT");
                int NUMERO = reader.GetOrdinal("NUMERO");

                while (reader.Read())
                {
                    Entity.Factura OBJ = new Entity.Factura();
                    //BeginFields
                    OBJ.Usr_Id = (int)(!reader.IsDBNull(USR_ID_CAJA) ? reader.GetValue(USR_ID_CAJA) : 0);
                    OBJ.FechaMovimiento = (DateTime)(!reader.IsDBNull(FECHA_INGRESO) ? reader.GetValue(FECHA_INGRESO) : DateTime.MinValue);
                    OBJ.Cont_Id = (int)(!reader.IsDBNull(CONT_ID) ? reader.GetValue(CONT_ID) : 0);
                    OBJ.Paciente = (String)(!reader.IsDBNull(PACIENTE) ? reader.GetValue(PACIENTE) : string.Empty);
                    OBJ.RutPaciente = (String)(!reader.IsDBNull(RUT) ? reader.GetValue(RUT) : string.Empty);
                    OBJ.NumeroVenta = (int)(!reader.IsDBNull(NUMERO) ? reader.GetValue(NUMERO) : 0);
                    //EndFields

                    lista.Add(OBJ);
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

            return lista;

        }
    }
}
