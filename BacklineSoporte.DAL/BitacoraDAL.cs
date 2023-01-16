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
    public class BitacoraDAL
    {
        public static void InsertarBitacora(BacklineSoporte.Entity.Bitacora bitacora)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_BITA_BITACORA_INS");

            db.AddInParameter(dbCommand, "USR_ID", DbType.Int32, bitacora.Usr_Id);
            db.AddInParameter(dbCommand, "FECHA", DbType.DateTime, bitacora.Fecha != DateTime.MinValue ? bitacora.Fecha : (object)null);
            db.AddInParameter(dbCommand, "DETALLE", DbType.String, bitacora.Detalle.ToUpper());
            db.AddInParameter(dbCommand, "MODULO", DbType.String, bitacora.Modulo.ToUpper());

            db.ExecuteNonQuery(dbCommand);
        }
        public static List<BacklineSoporte.Entity.Bitacora> ObtenerBitacora()
        {
            List<Entity.Bitacora> bitacora = new List<Entity.Bitacora>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_BITA_BITACORA_LEER");



            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int USR_ID = reader.GetOrdinal("USR_ID");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int FECHA = reader.GetOrdinal("FECHA");
                int DETALLE = reader.GetOrdinal("DETALLE");
                int MODULO = reader.GetOrdinal("MODULO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Bitacora OBJ = new BacklineSoporte.Entity.Bitacora();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Usr_Id = (int)(!reader.IsDBNull(USR_ID) ? reader.GetValue(USR_ID) : 0);
                    OBJ.NombreCompleto = (String)(!reader.IsDBNull(NOMBRE_COMPLETO) ? reader.GetValue(NOMBRE_COMPLETO) : string.Empty);
                    OBJ.Fecha = (DateTime)(!reader.IsDBNull(FECHA) ? reader.GetValue(FECHA) : DateTime.MinValue);
                    OBJ.Detalle = (String)(!reader.IsDBNull(DETALLE) ? reader.GetValue(DETALLE) : string.Empty);
                    OBJ.Modulo = (String)(!reader.IsDBNull(MODULO) ? reader.GetValue(MODULO) : string.Empty);
                    //EndFields

                    bitacora.Add(OBJ);
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
            
            return bitacora;

        }
    }
}
